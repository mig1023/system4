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
    }
}
