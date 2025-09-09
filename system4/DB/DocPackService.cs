using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class DocPackService
    {
        [Key]
        public int Id { get; set; }

        public int PackId { get; set; }

        public int ServiceId { get; set; }
    }
}
