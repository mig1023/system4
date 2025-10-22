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
                        appointment.AppNum = Numbering.Appointment(appointment.AppDate, appointment.CenterId);

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

        public static int DocPack(DocPack doc, DocPackInfo docInfo, List<DocPackList> docPackLists)
        {
            using (var db = new EntityContext())
            {
                var docPackId = 0;

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        doc.AgreementNo = Numbering.DocPack(doc.PDate, doc.CenterId);

                        db.DocPack.Add(doc);
                        db.SaveChanges();

                        docPackId = doc.Id;

                        docInfo.PackId = docPackId;
                        db.DocPackInfo.Add(docInfo);
                        db.SaveChanges();

                        var docPackInfo = docInfo.Id;

                        foreach (var docPackList in docPackLists)
                        {
                            docPackList.PackInfoId = docPackInfo;
                        }

                        db.DocPackList.AddRange(docPackLists);
                        db.SaveChanges();

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
