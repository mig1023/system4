using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class ServiceFieldValuesINT
    {
        [Key]
        public int DocPackServiceId { get; set; }

        public int ServiceFieldId { get; set; }

        public int Value { get; set; }
    }
}
