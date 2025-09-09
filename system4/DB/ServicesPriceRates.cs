using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class ServicesPriceRates
    {
        [Key]
        public int Id { get; set; }

        public int ServiceId { get; set; }

        public int PriceRateId { get; set; }

        public float Price { get; set; }
    }
}
