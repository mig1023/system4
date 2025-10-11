using system4.DB;

namespace system4.DAL
{
    public class Services
    {
        public int ServiceId { get; set; }

        public string ServiceName { get; set; }

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

        public static List<Services> ServicesByCenter(int centerId, DB.Branches center)
        {
            var services = DB.Entity.Get.ServicesByCenter(centerId);

            if (center.isTranslate > 0)
                services.Insert(0, Constants.BanalServices("Translate"));

            if (center.isAnketa > 0)
                services.Insert(0, Constants.BanalServices("Anketa"));

            if (center.isPrinting > 0)
                services.Insert(0, Constants.BanalServices("Printing"));

            if (center.isPhoto > 0)
                services.Insert(0, Constants.BanalServices("Photo"));

            services.Insert(0, Constants.BanalServices("Xerox"));

            return services;
        }
    }
}
