using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class ServiceFields
    {
        [Key]
        public int Id { get; set; }

        public int ServiceId { get; set; }

        public string FName { get; set; }

        public string FType { get; set; }

        public string ValueType { get; set; }

        public string Required { get; set; }
    }
}
