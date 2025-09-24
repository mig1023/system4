using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class Holidays
    {
        [Key]
        public DateTime HDate { get; set; }

        public string HName { get; set; }

        public string Centers { get; set; }
    }
}
