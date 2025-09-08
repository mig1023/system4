using system4.DB.Entity;

namespace system4.BLL.Finances
{
    public class Prices
    {
        private static int Age(DateTime date)
        {
            var today = DateTime.Today;
            var age = today.Year - date.Year;

            if (date.Date > today.AddYears(-age))
            {
                age -= 1;
            }

            return age;
        }
        private static DB.PriceList PriceListByAge(DAL.DocPack doc, DAL.DocApplicant appl)
        {
            if (string.IsNullOrEmpty(doc.PriceRate.Ages))
            {
                return doc.PriceList.FirstOrDefault();
            }

            var ages = doc.PriceRate.Ages
                .Split('-')
                .Select(x => int.Parse(x))
                .ToList();

            var agesFree = doc.PriceRate.AgesFree
                .Split("-")
                .Select(x => int.Parse(x))
                .ToList();

            var age = Age(appl.BthDate);
            var group = string.Empty;

            if (age < agesFree[1])
            {
                group = doc.PriceRate.AgesFree;
            }
            else if (age < ages[1])
            {
                group = doc.PriceRate.Ages;
            }

            return doc.PriceList
                .FirstOrDefault(x => x.Ages == group);
        }


        public static double ConcilForApplicant(DAL.DocPack doc, DAL.DocApplicant appl)
        {
            if (appl.Status == 7)
            {
                return 0;
            }

            var priceList = PriceListByAge(doc, appl);

            if (doc.Urgent > 0)
            {
                return appl.iNRes == 0 ? priceList.ConcilRU : priceList.ConcilNU;
            }
            else
            {
                return appl.iNRes == 0 ? priceList.ConcilR : priceList.ConcilN;
            }
        }

        public static double Concil(DAL.DocPack doc)
        {
            double price = 0;

            foreach (var appl in doc.Applicants)
            {
                price += ConcilForApplicant(doc, appl);
            }

            return price;
        }
    }
}
