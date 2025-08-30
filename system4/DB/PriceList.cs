using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class PriceList
    {
        [Key]
        public int Id { get; set; }

        public int RateId { get; set; }

        public float Price { get; set; }

        public float UPrice { get; set; }

        public float JPrice { get; set; }

        public float JUPrice { get; set; }

        public int VisaId { get; set; }

        public float ConcilR { get; set; }

        public float ConcilN { get; set; }

        public int woVAT { get; set; }

        public float ConcilRU { get; set; }

        public float ConcilNU { get; set; }

        public string Ages { get; set; }
    }
}
