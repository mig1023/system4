using static system4.DB.Entity.Contextcs;

namespace system4.DB.Entity
{
    public class Services
    {
        public static User GetUser(string login)
        {
            using (EntityContext db = new EntityContext())
            {
                User user = db.Users
                    .SingleOrDefault(x => x.Login == login);

                if (user == null)
                    return null;

                return user;
            }
        }

        public static bool VerifyPassword(string login, string password)
        {
            User user = GetUser(login);

            if (user == null)
                return false;

            bool passwordIdValid = Cryptography
                .ValidatePassword(user.Pass, password);

            return passwordIdValid;
        }
    }
}
