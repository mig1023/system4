using Newtonsoft.Json;

namespace system4.BLL.CreateDoc
{
    public class Creation
    {
        private static int ServiceIsEnabled(string name, List<DAL.Services> services)
        {
            var shipping = services
                .Where(x => x.ServiceName == name)
                .SingleOrDefault();

            return shipping == null ? 0 : 1;
        }

        public static int Save(DAL.Appointment app, DocForm doc,
            List<DAL.Services> services, string requestsJson, string user)
        {
            var requests = JsonConvert.DeserializeObject(requestsJson);

            var rate = DB.Entity.Get.PriceRate("RUR", DateTime.Now, app.CenterId);

            // gen bankid if genbank == 4

            var dsum = 100; // !!!

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
                DSum = dsum,
                ServSum = dsum, // !!!
                ADate = DateTime.Now,
                PDate = DateTime.Now,
                PStatus = 1,
                Login = user,
                PType = 1, // doc form
                Urgent = doc.Urgent ? 1 : 0,
                VisaType = doc.VisaType, //  !!!
                AppId = app.Id,
                Phone = doc.Phone,
                DovDate = doc.DovDate ?? DateTime.MinValue,
                DovNum = doc.DovNumber ?? ".",
                Template = "1", // template from center
                CenterId = app.CenterId,

                SMS = ServiceIsEnabled("SMS", services),
                Mobile = doc.Phone, // service !!!

                Shipping = ServiceIsEnabled("Shipping", services),
                ShippingAddress = "Кривоколенная ул, д 10",
                AddrIndex = "101000",
                ShipNum = "0",
                TShipSum = 100,
                ShippingPhone = "1112233",

                // !!!
                XeroxPage = 1,
                AnketaSrv = 1,
                PrintSrv = 1,
                PhotoSrv = 1,
                VIPSrv = 1,
                Translate = 1,

                InsSum = 0,
                InsData = null,
                SkipIns = 0,
                PersonalNo = "",
                isNewDHL = 1,
                ConcilPaymentDate = DateTime.Now, // !!!
                NoReceived = 0,
                RANum = "",
                SMS_mesid = "",
                SMS_reason = "",
            };

            // insert in DocPackService !!!

            // INSERT INTO DocPackOptional (DocPackID, ShippingFree, Reject, FeedbackKey)
            // INSERT INTO FoxShippment (DocID, ShippmentComment, Oversize) 
            // INSERT INTO DocComments (DocID, Login, CommentText, CommentDate)

            // ???
            var newInfo = new DB.DocPackInfo
            {
                BankId = "202512345678", // !!!
                PSum = 0,
                VisaCnt = doc.Applicants.Where(x => !x.Removed).Count(),
                Num_NR = 0,
                Num_NC = 0,
                Num_NN = 0,
                WhomFilled = "",
                //WhenFilled = DateTime.MinValue,
                Num_ACon = 0,
                Num_ANCon = 0,
            };

            var newApplicants = new List<DB.DocPackList>();

            foreach (var applicant in doc.Applicants.Where(x => !x.Removed))
            {
                var newApplicant = new DB.DocPackList
                {
                    PackInfoId = 0, // !!!
                    CBankId = "202512345678", // !!!
                    LName = applicant.RLName,
                    FName = applicant.RFName,
                    MName = applicant.RMName,
                    isChild = 0, // !!!
                    PassNum = "111222333", // !!!
                    FlyDate = applicant.FlyDate,
                    BthDate = applicant.BirthDate ?? DateTime.MinValue,
                    SDate = DateTime.Now,
                    Login = user,
                    Status = 1,
                    ApplId = applicant.ApplId,
                    iNRes = applicant.NRes ? 1 : 0,
                    Concil = applicant.Concil ? 1 : 0,
                    MobileNums = "",
                    ShipAddress = "",
                    ShipNum = "",
                    RTShipSum = 0,
                    ShipPhone = "",
                    ShipMail = "",

                    AgeCatA = 0, // !!!
                    FPStatus = 1, // !!!
                    AddrIndexP = "",
                    SMS_mesid = "",
                    SMS_reason = "",
                };

                //FillAllNullableProperties(newApplicant);
                newApplicants.Add(newApplicant);
            }

            // INSERT INTO INSERT INTO DocHistory
            // INSERT INTO DocRequest

            return DB.Entity.Save.DocPack(newDoc, newInfo, newApplicants);
        }
    }
}
