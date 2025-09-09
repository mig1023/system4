using system4.DB;

namespace system4.DAL
{
    public class Services
    {
        public int ServiceId { get; set; }

        public string Name { get; set; }

        public string ValueType { get; set; }

        public int Value { get; set; }

        public double Price { get; set; }

        public static List<Services> Get(DocPack doc)
        {
            var pricesDb = DB.Entity.Get.ServicesPriceRates(doc.RateId);

            var prices = pricesDb.ToDictionary(x => x.ServiceId, y => y.Price);

            var services = DB.Entity.Get.ServicesByDocId(doc.Id);

            return services;
        }
    }
}
