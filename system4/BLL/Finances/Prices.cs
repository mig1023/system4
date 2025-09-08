using System;

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
        private static DB.PriceList PriceListByAge(DAL.DocApplicant appl)
        {
            if (string.IsNullOrEmpty(appl.DocPack.PriceRate.Ages))
            {
                return appl.DocPack.PriceList.FirstOrDefault();
            }

            var ages = appl.DocPack.PriceRate.Ages
                .Split('-')
                .Select(x => int.Parse(x))
                .ToList();

            var agesFree = appl.DocPack.PriceRate.AgesFree
                .Split("-")
                .Select(x => int.Parse(x))
                .ToList();

            var age = Age(appl.BthDate);
            var group = string.Empty;

            if (age < agesFree[1])
            {
                group = appl.DocPack.PriceRate.AgesFree;
            }
            else if (age < ages[1])
            {
                group = appl.DocPack.PriceRate.Ages;
            }

            return appl.DocPack.PriceList
                .FirstOrDefault(x => x.Ages == group);
        }


        public static double ConcilPerApplicant(DAL.DocApplicant appl)
        {
            if (appl.Status == 7)
            {
                return 0;
            }

            var priceList = PriceListByAge(appl);

            if (appl.DocPack.Urgent > 0)
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
                price += ConcilPerApplicant(appl);
            }

            return price;
        }

        public static double ServicesPerApplicant(DAL.DocApplicant appl)
        {
            if (appl.Status == 7)
            {
                return 0;
            }

            var priceList = appl.DocPack.PriceList.FirstOrDefault();

            if (appl.DocPack.Urgent > 0)
            {
                return appl.DocPack.JurId > 0 ? priceList.JUPrice : priceList.UPrice;
            }
            else
            {
                return appl.DocPack.JurId > 0 ? priceList.JPrice : priceList.Price;
            }
        }

        public static double Services(DAL.DocPack doc)
        {
            double price = 0;

            foreach (var appl in doc.Applicants)
            {
                price += ServicesPerApplicant(appl);
            }

            return price;
        }
    }
}
