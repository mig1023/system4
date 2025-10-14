using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class Countries
    {
        [Key]
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int Ex { get; set; }

        public string ExCode { get; set; }

        public string ExName { get; set; }

        public string EUCode { get; set; }

        public int MemberOfEU { get; set; }

        public int Schengen { get; set; }

        public string EnglishName { get; set; }
    }
}
