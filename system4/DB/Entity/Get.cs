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

        public static Branches Branches(int appid)
        {
            using (var db = new EntityContext())
            {
                var branch = db.Branches
                    .SingleOrDefault(x => x.Id == appid);

                return branch;
            }
        }
    }
}
