using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class Exclusions
    {
        [Key]
        public DateTime EDate { get; set; }

        public string EName { get; set; }

        public string Centers { get; set; }
    }
}
