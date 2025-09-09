using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class Services
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string TplPrefix { get; set; }
    }
}
