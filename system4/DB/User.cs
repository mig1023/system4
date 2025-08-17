using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class User
    {
        [Key]
        public string Login { get; set; }

        public string Pass { get; set; }

        public string Fingerprint { get; set; }

        public string Email { get; set; }

        public string UserLName { get; set; }

        public string UserName { get; set; }

        public string UserSName { get; set; }
    }
}
