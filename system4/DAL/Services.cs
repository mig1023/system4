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
            var prices = DB.Entity.Get
                .ServicesPriceRates(doc.RateId)
                .ToDictionary(x => x.ServiceId, x => x.Price);

            var services = DB.Entity.Get.ServicesByDocId(doc.Id);
            
            foreach (var service in services)
            {
                if (prices.ContainsKey(service.ServiceId))
                {
                    service.Price = prices[service.ServiceId];
                }
            }

            return services;
        }
    }
}
