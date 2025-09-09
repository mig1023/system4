using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;
using system4.DAL;
using static system4.DB.Entity.Contextcs;

namespace system4.DB.Entity
{
    public class Get
    {
        public static User User(string login)
        {
            using (var db = new EntityContext())
            {
                var user = db.Users
                    .SingleOrDefault(x => x.Login == login);

                if (user == null)
                    return null;

                return user;
            }
        }

        public static List<int> AppsByDate(DateTime date, int page, int size, out int count)
        {
            using (var db = new EntityContext())
            {
                var allApp = db.Appointments
                    .Where(x => x.AppDate == date.Date)
                    .Select(x => x.Id)
                    .ToList();

                count = allApp.Count;

                var apps = allApp
                    .Skip(size * (page - 1))
                    .Take(size)
                    .ToList();

                return apps;
            }
        }

        public static List<int> AppsByPassnum(string pass, int page, int size, out int count)
        {
            using (var db = new EntityContext())
            {
                var allApps = db.AppData
                    .Where(x => x.PassNum == pass)
                    .Distinct()
                    .Select(x => x.AppId)
                    .ToList();

                count = allApps.Count;

                var apps = allApps
                    .Skip(size * (page - 1))
                    .Take(size)
                    .ToList();

                return apps;
            }
        }

        public static int AppByNum(string appNum)
        {
            using (var db = new EntityContext())
            {
                var app = db.Appointments
                    .SingleOrDefault(x => x.AppNum == appNum);

                return app?.Id ?? 0;
            }
        }

        public static Appointment App(int appId)
        {
            using (var db = new EntityContext())
            {
                var app = db.Appointments
                    .SingleOrDefault(x => x.Id == appId);

                return app;
            }
        }

        public static List<AppData> AppData(int appId)
        {
            using (var db = new EntityContext())
            {
                var apps = db.AppData
                    .Where(x => x.AppId == appId)
                    .ToList();

                return apps;
            }
        }

        public static List<AppComments> AppComments(int appId)
        {
            using (var db = new EntityContext())
            {
                var comments = db.AppComments
                    .Where(x => x.AppID == appId)
                    .ToList();

                return comments;
            }
        }

        public static List<int> DocsByDate(DateTime date, int page, int size,
            bool juridical, out int count)
        {
            using (var db = new EntityContext())
            {
                var allDocs = db.DocPack
                    .Where(x => x.PDate == date.Date)
                    .Where(x => juridical ? x.JurId > 0 : x.JurId == 0)
                    .Select(x => x.Id)
                    .ToList();

                count = allDocs.Count;

                var docs = allDocs
                    .Skip(size * (page - 1))
                    .Take(size)
                    .ToList();

                return docs;
            }
        }

        public static List<int> DocsByPassnum(string pass, int page, int size,
            bool juridical, out int count)
        {
            using (var db = new EntityContext())
            {
                var lists = db.DocPackList
                    .Where(x => x.PassNum == pass)
                    .Select(x => x.PackInfoId)
                    .ToList();

                var infos = db.DocPackInfo
                    .Where(x => lists.Contains(x.Id))
                    .Select(x => x.PackId)
                    .Distinct()
                    .ToList();

                count = infos.Count;

                var docs = db.DocPack
                    .Where(x => infos.Contains(x.Id))
                    .Select(x => x.Id)
                    .Distinct()
                    .Skip(size * (page - 1))
                    .Take(size)
                    .ToList();

                return docs;
            }
        }

        public static int DocByBankId(string bankid)
        {
            using (var db = new EntityContext())
            {
                var doc = db.DocPackInfo
                    .SingleOrDefault(x => x.BankId == bankid);

                return doc?.PackId ?? 0;
            }
        }

        public static int DocByNum(string agreementNo) =>
            Doc(agreementNo)?.Id ?? 0;

        public static DocPack Doc(string agreementNo)
        {
            using (var db = new EntityContext())
            {
                var doc = db.DocPack
                    .SingleOrDefault(x => x.AgreementNo == Formats.OnlyNumeric(agreementNo));

                return doc;
            }
        }

        public static DocPack Doc(int docId)
        {
            using (var db = new EntityContext())
            {
                var doc = db.DocPack
                    .SingleOrDefault(x => x.Id == docId);

                return doc;
            }
        }

        public static List<DocPackInfo> DocInfo(int docId)
        {
            using (var db = new EntityContext())
            {
                var docinfo = db.DocPackInfo
                    .Where(x => x.PackId == docId)
                    .ToList();

                return docinfo;
            }
        }

        public static List<DocPackList> DocList(int docInfoId)
        {
            using (var db = new EntityContext())
            {
                var doclist = db.DocPackList
                    .Where(x => x.PackInfoId == docInfoId)
                    .ToList();

                return doclist;
            }
        }

        public static List<DocComments> DocComments(int docId)
        {
            using (var db = new EntityContext())
            {
                var comments = db.DocComments
                    .Where(x => x.DocId == docId)
                    .ToList();

                return comments;
            }
        }

        public static DocPackOptional DocPackOptional(int docId)
        {
            using (var db = new EntityContext())
            {
                var options = db.DocPackOptional
                    .SingleOrDefault(x => x.DocPackId == docId);

                return options;
            }
        }
        
        public static Branches Branches(int centerId)
        {
            using (var db = new EntityContext())
            {
                var branch = db.Branches
                    .SingleOrDefault(x => x.Id == centerId);

                return branch;
            }
        }
        
        public static VisaTypes VisaTypes(int appId)
        {
            using (var db = new EntityContext())
            {
                var type = db.VisaTypes
                    .SingleOrDefault(x => x.Id == appId);

                return type;
            }
        }

        public static TimeData TimeData(int slotId)
        {
            using (var db = new EntityContext())
            {
                var slot = db.TimeData
                    .SingleOrDefault(x => x.SlotId == slotId);

                return slot;
            }
        }

        public static List<DocHistory> DocHistory(int docid)
        {
            using (var db = new EntityContext())
            {
                var history = db.DocHistory
                    .Where(x => x.DocId == docid)
                    .ToList();

                return history;
            }
        }

        public static List<DocHistory> DocHistoryByPassnum(string passnum)
        {
            using (var db = new EntityContext())
            {
                var history = db.DocHistory
                    .Where(x => x.PassNum == passnum)
                    .ToList();

                return history;
            }
        }

        public static List<DocHistory> DocHistoryByBankId(string bankId)
        {
            using (var db = new EntityContext())
            {
                var history = db.DocHistory
                    .Where(x => x.BankId == bankId)
                    .ToList();

                return history;
            }
        }

        public static PriceRate PriceRate(int rateId)
        {
            using (var db = new EntityContext())
            {
                var price = db.PriceRate
                    .SingleOrDefault(x => x.Id == rateId);

                return price;
            }
        }

        public static List<PriceList> PriceList(int rateId, int visaType)
        {
            using (var db = new EntityContext())
            {
                var price = db.PriceList
                    .Where(x => x.RateId == rateId)
                    .Where(x => x.VisaId == visaType)
                    .ToList();

                return price;
            }
        }
        
        public static List<ServiceFields> ServiceFields(int serviceId)
        {
            using (var db = new EntityContext())
            {
                var price = db.ServiceFields
                    .Where(x => x.ServiceId == serviceId)
                    .ToList();

                return price;
            }
        }


    }
}
