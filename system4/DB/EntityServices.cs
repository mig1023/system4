using static system4.DB.EntityContextcs;

namespace system4.DB
{
    public class EntityServices
    {
        public static bool VerifyPassword(string login, string password)
        {
            using (EntityContext db = new EntityContext())
            {
                User user = db.Users
                    .SingleOrDefault(x => x.Login == login);

                if (user == null)
                    return false;

                bool passwordIdValid = EntityCryptography
                    .ValidatePassword(user.Pass, password);

                return passwordIdValid;
            }
        }
    }
}
