using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class DocHistory
    {
        [Key]
        public int DocId { get; set; }

        public string PassNum { get; set; }

        public string Login { get; set; }

        public DateTime HDate { get; set; }

        public int StatusId { get; set; }

        public string? BankId { get; set; }

        public int ActTime { get; set; }

        public string AddInfo { get; set; }

        public int ODuration { get; set; }

        public int? FPStatus { get; set; }
    }
}
