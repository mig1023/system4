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

        public static List<Appointment> AppsByDate(DateTime date)
        {
            using (var db = new EntityContext())
            {
                var apps = db.Appointments
                    .Where(x => x.AppDate == date.Date)
                    .ToList();

                return apps;
            }
        }

        public static Appointment App(int appid)
        {
            using (var db = new EntityContext())
            {
                var app = db.Appointments
                    .SingleOrDefault(x => x.Id == appid);

                return app;
            }
        }

        public static List<AppData> AppData(int appid)
        {
            using (var db = new EntityContext())
            {
                var apps = db.AppData
                    .Where(x => x.AppID == appid)
                    .ToList();

                return apps;
            }
        }

        public static List<AppComments> AppComments(int appid)
        {
            using (var db = new EntityContext())
            {
                var comments = db.AppComments
                    .Where(x => x.AppID == appid)
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

        public static DocPack Doc(int docid)
        {
            using (var db = new EntityContext())
            {
                var doc = db.DocPack
                    .SingleOrDefault(x => x.Id == docid);

                return doc;
            }
        }

        public static List<DocPackInfo> DocInfo(int docid)
        {
            using (var db = new EntityContext())
            {
                var docinfo = db.DocPackInfo
                    .Where(x => x.PackId == docid)
                    .ToList();

                return docinfo;
            }
        }

        public static List<DocPackList> DocList(int docinfoid)
        {
            using (var db = new EntityContext())
            {
                var doclist = db.DocPackList
                    .Where(x => x.PackInfoId == docinfoid)
                    .ToList();

                return doclist;
            }
        }

        public static List<DocComments> DocComments(int docid)
        {
            using (var db = new EntityContext())
            {
                var comments = db.DocComments
                    .Where(x => x.DocId == docid)
                    .ToList();

                return comments;
            }
        }

        public static DocPackOptional DocPackOptional(int docid)
        {
            using (var db = new EntityContext())
            {
                var options = db.DocPackOptional
                    .SingleOrDefault(x => x.DocPackId == docid);

                return options;
            }
        }
        
        public static Branches Branches(int appid)
        {
            using (var db = new EntityContext())
            {
                var branch = db.Branches
                    .SingleOrDefault(x => x.Id == appid);

                return branch;
            }
        }
        
        public static VisaTypes VisaTypes(int appid)
        {
            using (var db = new EntityContext())
            {
                var type = db.VisaTypes
                    .SingleOrDefault(x => x.Id == appid);

                return type;
            }
        }
    }
}
