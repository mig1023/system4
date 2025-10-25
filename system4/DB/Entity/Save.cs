using static system4.DB.Entity.Contextcs;

namespace system4.DB.Entity
{
    public class Save
    {
        public static int Appointment(Appointment appointment, List<AppData> appData)
        {
            using (var db = new EntityContext())
            {
                var appId = 0;

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        appointment.AppNum = DAL.Numbering.Appointment(appointment.AppDate, appointment.CenterId);

                        db.Appointments.Add(appointment);
                        db.SaveChanges();

                        appId = appointment.Id;

                        foreach (var app in appData)
                        {
                            app.AppId = appId;
                        }

                        db.AppData.AddRange(appData);
                        db.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                }

                return appId;
            }
        }

        public static int DocPack(DocPack doc, DocPackInfo docInfo, List<DocPackList> docPackLists,
            FoxShippment shippment, List<DocPackService> services, List<ServiceFieldValuesINT> servicesValues,
            string bankIdTemplate)
        {
            using (var db = new EntityContext())
            {
                var docPackId = 0;
                string bankId = string.Empty;

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        doc.AgreementNo = DAL.Numbering.DocPack(doc.PDate, doc.CenterId);

                        db.DocPack.Add(doc);
                        db.SaveChanges();

                        docPackId = doc.Id;

                        if (!string.IsNullOrEmpty(bankIdTemplate))
                        {
                            bankId = DAL.Numbering.BankId(bankIdTemplate);
                            docInfo.BankId = bankId;
                        }

                        docInfo.PackId = docPackId;
                        db.DocPackInfo.Add(docInfo);
                        db.SaveChanges();

                        var docPackInfo = docInfo.Id;

                        foreach (var docPackList in docPackLists)
                        {
                            docPackList.PackInfoId = docPackInfo;

                            if (!string.IsNullOrEmpty(bankIdTemplate))
                                docPackList.CBankId = bankId;
                        }

                        db.DocPackList.AddRange(docPackLists);
                        db.SaveChanges();

                        if (shippment != null)
                        {
                            shippment.DocId = docPackId;
                            db.FoxShippment.Add(shippment);
                            db.SaveChanges();
                        }

                        for (var i = 0; i < services.Count; i++)
                        {
                            services[i].PackId = docPackId;
                            db.DocPackService.Add(services[i]);
                            db.SaveChanges();

                            servicesValues[i].DocPackServiceId = services[i].Id;
                            db.ServiceFieldValuesINT.Add(servicesValues[i]);
                            db.SaveChanges();
                        }
                        
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                }

                return docPackId;
            }
        }
    }
}
