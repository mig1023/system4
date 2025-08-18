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
    }
}
