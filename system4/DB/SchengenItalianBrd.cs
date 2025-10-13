using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class SchengenItalianBrd
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int SCHID { get; set; }
    }
}
