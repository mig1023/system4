using static system4.DB.Entity.Contextcs;

namespace system4.DB.Entity
{
    public class Services
    {
        public static bool VerifyPassword(string login, string password)
        {
            User user = Get.User(login);

            if (user == null)
                return false;

            bool passwordIdValid = Cryptography
                .ValidatePassword(user.Pass, password);

            return passwordIdValid;
        }
    }
}
