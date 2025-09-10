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
        private static DB.PriceList PriceListByAge(DAL.DocApplicant appl, out bool ageType)
        {
            var age = Age(appl.BthDate);
            var group = string.Empty;

            ageType = false;

            if (age < 6)
            {
                group = appl.DocPack.PriceRate.AgesFree;
            }
            else if (age < 12)
            {
                group = appl.DocPack.PriceRate.Ages;
                ageType = true;
            }

            if (string.IsNullOrEmpty(appl.DocPack.PriceRate.Ages))
            {
                return appl.DocPack.PriceList.FirstOrDefault();
            }
            else
            {
                return appl.DocPack.PriceList.FirstOrDefault(x => x.Ages == group);
            }
        }

        private static string VisaTypeCode(DAL.DocApplicant appl, bool age, string code)
        {
            if ((appl.DocPack.Visa.Category == "D") && (appl.DocPack.VisaType == 12))
            {
                return "D05";
            }
            else if (appl.DocPack.Visa.Category == "D")
            {
                return "D04";
            }
            else if (age)
            {
                return "C04";
            }
            else
            {
                return code;
            }
        }

        public static double ConcilPerApplicant(DAL.DocApplicant appl, out string type)
        {
            if (appl.IsDeleted())
            {
                type = string.Empty;
                return 0;
            }

            var priceList = PriceListByAge(appl, out bool age);

            if ((appl.DocPack.Urgent > 0) && (appl.iNRes == 0))
            {
                type = VisaTypeCode(appl, age, "C02");
                return priceList.ConcilRU;
            }
            else if ((appl.DocPack.Urgent > 0) && (appl.iNRes != 0))
            {
                type = VisaTypeCode(appl, age, "C02");
                return priceList.ConcilNU;
            }
            else if ((appl.DocPack.Urgent == 0) && (appl.iNRes != 0))
            {
                type = VisaTypeCode(appl, age, "C03");
                return priceList.ConcilN;
            }
            else
            {
                type = VisaTypeCode(appl, age, "C01");
                return priceList.ConcilR;
            }
        }

        public static double Concil(DAL.DocPack doc)
        {
            double price = 0;

            foreach (var appl in doc.Applicants)
            {
                price += ConcilPerApplicant(appl, out string _);
            }

            return price;
        }

        public static Dictionary<string, double> ConcilByType(DAL.DocPack doc)
        {
            var concils = new Dictionary<string, double>();

            foreach (var appl in doc.Applicants)
            {
                var price = ConcilPerApplicant(appl, out string type);

                if (concils.ContainsKey(type))
                {
                    concils[type] += price;
                }
                else
                {
                    concils.Add(type, price);
                }
            }

            return concils;
        }

        public static double ServicesPerApplicant(DAL.DocApplicant appl)
        {
            if (appl.IsDeleted())
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

        public static double ServiceAverage(DAL.DocPack doc)
        {
            var appl = doc.Applicants
                .Where(x => !x.IsDeleted())
                .FirstOrDefault();

            if (appl == null)
            {
                return 0;
            }
            else
            {
                return ServicesPerApplicant(appl);
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
