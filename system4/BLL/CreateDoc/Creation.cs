using Newtonsoft.Json;
using system4.DB;

namespace system4.BLL.CreateDoc
{
    public class Creation
    {
        public static int Save(DAL.Appointment app, DocForm doc,
            List<DAL.Services> services, string requestsJson, string user)
        {
            var requests = JsonConvert.DeserializeObject(requestsJson);
            var rate = DB.Entity.Get.PriceRate("RUR", DateTime.Now, app.CenterId);

            // gen bankid if genbank == 4

            // concil ?

            var newDoc = new DB.DocPack
            {
                LastUpdate = DateTime.Now,
                Cur = "RUR",
                RateId = rate.Id,
                Address = doc.Address,
                FName = doc.FName,
                LName = doc.LName,
                MName = doc.MName,
                PassNum = doc.PassNum,
                PassDate = doc.PassDate ?? DateTime.MinValue,
                PassWhom = doc.PassWhom,
                ADate = DateTime.Now,
                PDate = DateTime.Now,
                PStatus = 1,
                Login = user,
                PType = doc.PayType,
                Urgent = doc.Urgent ? 1 : 0,
                VisaType = doc.VisaType,
                AppId = app.Id,
                Phone = doc.Phone,
                DovDate = doc.DovDate ?? DateTime.MinValue,
                DovNum = doc.DovNumber ?? ".",
                Template =  "1", // template
                CenterId = app.CenterId,

                InsSum = 0,
                InsData = null,
                SkipIns = 0,
                PersonalNo = string.Empty,
                isNewDHL = 1,
                ConcilPaymentDate = DateTime.Now, // !!!
                NoReceived = 0,
                RANum = string.Empty,
                SMS_mesid = string.Empty,
                SMS_reason = string.Empty,
                ShipNum = string.Empty,
                Shipping = 0,
                ShippingAddress = string.Empty,
                AddrIndex = string.Empty,
                TShipSum = 0,
                Mobile = string.Empty,
            };

            // INSERT INTO DocPackOptional (DocPackID, ShippingFree, Reject, FeedbackKey)
            // INSERT INTO DocComments (DocID, Login, CommentText, CommentDate)

            var newInfo = new DB.DocPackInfo
            {
                PSum = 0,
                VisaCnt = doc.Applicants.Where(x => !x.Removed).Count(),
                Num_NR = 0,
                Num_NC = 0,
                Num_NN = 0,
                WhomFilled = string.Empty,
                Num_ACon = 0,
                Num_ANCon = 0,
            };

            var newApplicants = new List<DB.DocPackList>();

            foreach (var applicant in doc.Applicants.Where(x => !x.Removed))
            {
                var appData = app.AppData
                    .SingleOrDefault(x => x.Id == applicant.ApplId);

                var newApplicant = new DB.DocPackList
                {
                    LName = applicant.RLName,
                    FName = applicant.RFName,
                    MName = applicant.RMName,
                    isChild = 0, // !!!
                    PassNum = appData.PassNum,
                    FlyDate = applicant.FlyDate,
                    BthDate = applicant.BirthDate ?? DateTime.MinValue,
                    SDate = DateTime.Now,
                    Login = user,
                    Status = 1,
                    ApplId = applicant.ApplId,
                    iNRes = applicant.NRes ? 1 : 0,
                    Concil = applicant.Concil ? 1 : 0,

                    AgeCatA = 0, // !!!
                    FPStatus = 1, // !!!

                    MobileNums = string.Empty,
                    ShipAddress = string.Empty,
                    ShipNum = string.Empty,
                    RTShipSum = 0,
                    ShipPhone = string.Empty,
                    ShipMail = string.Empty,
                    AddrIndexP = string.Empty,
                    SMS_mesid = string.Empty,
                    SMS_reason = string.Empty,
                };

                if (app.Center.genbank == 0)
                {
                    newApplicant.CBankId = applicant.BankId;
                }

                newApplicants.Add(newApplicant);
            }

            DB.FoxShippment shippment = null;

            if (doc.Shipping)
            {
                newDoc.Shipping = 1;
                newDoc.ShippingAddress = doc.ShippingData.Addr;
                newDoc.AddrIndex = doc.ShippingData.Index;
                newDoc.TShipSum = (float)doc.ShippingData.Price;

                if (!string.IsNullOrEmpty(doc.ShippingData.Info) || doc.ShippingData.Overload)
                {
                    shippment = new DB.FoxShippment
                    {
                        ShippmentComment = doc.ShippingData.Info,
                        Oversize = doc.ShippingData.Overload ? 1 : 0,
                    };
                }
            }

            if (doc.SMS)
            {
                newDoc.SMS = 1;
                newDoc.Mobile = doc.Mobile;
            }

            var servicesIntegrated = DAL.Services.ServicesInDocPack();
            var servicesAdditional = new List<DocPackService>();
            var servicesAddValues = new List<ServiceFieldValuesINT>();
            var servicesFields = DB.Entity.Get.ServiceFields();

            foreach (var service in services)
            {
                if (servicesIntegrated.ContainsKey(service?.ServiceName ?? string.Empty))
                {
                    newDoc.GetType().GetProperty(servicesIntegrated[service.ServiceName]).SetValue(newDoc, service.Value);
                }
                else
                {
                    servicesAdditional.Add(new DocPackService { ServiceId = service.ServiceId });

                    var fieldId = servicesFields
                        .Where(x => x.ServiceId == service.ServiceId)
                        .SingleOrDefault();

                    var servicesValue = new ServiceFieldValuesINT
                    {
                        ServiceFieldId = fieldId.ServiceId,
                        Value = service.Value,
                    };

                    servicesAddValues.Add(servicesValue);
                }
            }

            // VIPSrv 

            // INSERT INTO INSERT INTO DocHistory
            // INSERT INTO DocRequest

            string bankIdTemplate = string.Empty;

            if (app.Center.genbank == 0)
            {
                newInfo.BankId = newApplicants.First().CBankId;
            }
            else
            {
                bankIdTemplate = rate.SAutoFormat;
            }

            var id = DB.Entity.Save.DocPack(newDoc, newInfo, newApplicants,
                shippment, servicesAdditional, servicesAddValues, bankIdTemplate);

            // recalc

            var dsum = 100; // !!! в конце через Finances/Services
            var serv = 100; // ServSum

            return id;
        }
    }
}
