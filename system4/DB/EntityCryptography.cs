using System.Security.Cryptography;
using System.Text;

namespace system4.DB
{
    public class EntityCryptography
    {
        public static bool ValidatePassword(string passwordHash, string password) =>
            GenerateMySQLHash(password) == passwordHash;

        private static string GenerateMySQLHash(string password)
        {
            var keyArray = Encoding.UTF8.GetBytes(password);
            var enc = new SHA1Managed();
            var encodedKey = enc.ComputeHash(enc.ComputeHash(keyArray));
            var myBuilder = new StringBuilder(encodedKey.Length);

            foreach (var b in encodedKey)
            {
                myBuilder.Append(b.ToString("X2"));
            }

            return $"*{myBuilder}";
        }
    }
}
