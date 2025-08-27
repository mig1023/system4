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

        public static List<int> AppsByDate(DateTime date, int page, int size)
        {
            using (var db = new EntityContext())
            {
                var apps = db.Appointments
                    .Where(x => x.AppDate == date.Date)
                    .Select(x => x.Id)
                    .Skip(size * (page - 1))
                    .Take(size)
                    .ToList();

                return apps;
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
                    .Where(x => x.AppID == appId)
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

        public static List<DocPack> DocsByDate(DateTime date)
        {
            using (var db = new EntityContext())
            {
                var docs = db.DocPack
                    .Where(x => x.PDate == date.Date)
                    .ToList();

                return docs;
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
        
        public static Branches Branches(int appId)
        {
            using (var db = new EntityContext())
            {
                var branch = db.Branches
                    .SingleOrDefault(x => x.Id == appId);

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
    }
}
