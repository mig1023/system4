using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class FoxShippment
    {
        [Key]
        public int Id { get; set; }

        public int DocId { get; set; }

        public string ShippmentComment { get; set; }

        public int Oversize { get; set; }
    }
}
