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

        public DateTime RegistrationDate { get; set; }

        public DateTime StatusDate { get; set; }

        public DateTime PassChanged { get; set; }

        public int RoleID { get; set; }

        public int Attempts { get; set; }

        public string UserLName { get; set; }

        public string UserName { get; set; }

        public string UserSName { get; set; }

        public int Gender { get; set; }

        public DateTime Birthday { get; set; }

        public int? Locked { get; set; }

        public DateTime? LockDate { get; set; }

        public string? LockedBy{ get; set; }

        public string? LockReason { get; set; }

        public string Branches { get; set; }

        public string LangID { get; set; }

        public string Printer { get; set; }

        public string? Cashbox { get; set; }

        public int? CompanyID { get; set; }
    }
}
