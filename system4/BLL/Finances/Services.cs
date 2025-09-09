using System;

namespace system4.BLL.Finances
{
    public class Services
    {
        public static List<Service> Get(DAL.DocPack doc)
        {
            var smscnt = 0;
            var shcnt = 0;
            double shsum = 0;

            if (doc.Shipping > 0)
            {
                shsum = doc.TShipSum;
                shcnt = doc.Shipping;
            }

            var apcnt = 0;
            var astr = string.Empty;
            var bankid = string.Empty;
            var prevbank = 0;

            foreach (DAL.DocApplicant app in doc.Applicants)
            {
                if (app.Status == 7)
                {
                    continue;
                }

                apcnt += 1;

                if ((doc.SMS_status == 2) && (app.MobileNums != string.Empty))
                {
                    smscnt += 1;
                }

                if ((doc.Shipping == 2) && (app.ShipAddress != string.Empty))
                {
                    shcnt += 1;
                    shsum += app.RTShipSum;
                }
            }

            // var insurance_rgs =
            // var insurance_kl =

            var shippingSum = doc.isNewDHL > 0 ? shsum : doc.PriceRate.Shipping * shcnt;

            if (doc.SMS_status > 0)
            {
                smscnt = 1;
            }

            var vprice = doc.Urgent > 0 ? doc.PriceList.First().UPrice : doc.PriceList.First().Price;

            var services = new List<Service>();

            if (shcnt > 0)
            {
                var service = new Service
                {
                    Name = "Услуги по доставке документов на дом",
                    Quantity = shcnt,
                    Price = shsum,
                    VAT = true,
                    Department = 1,
                    Shipping = true,
                };

                services.Add(service);
            }

            if (smscnt > 0)
            {
                var service = new Service
                {
                    Name = "Услуги по оповещению (СМС сообщение)",
                    Quantity = smscnt,
                    Price = doc.PriceRate.SMS,
                    VAT = true,
                    Department = 1,
                };

                services.Add(service);
            }

            if (doc.Translate > 0)
            {
                var service = new Service
                {
                    Name = "Услуги по переводу документов",
                    Quantity = doc.Translate,
                    Price = doc.PriceRate.TranslatePr,
                    VAT = true,
                    Department = 1,
                };

                services.Add(service);
            }

            if (doc.XeroxPage > 0)
            {
                var service = new Service
                {
                    Name = "Услуги по копированию документов",
                    Quantity = doc.XeroxPage,
                    Price = doc.PriceRate.XeroxPrice,
                    VAT = true,
                    Department = 1,
                };

                services.Add(service);
            }

            if (apcnt > 0)
            {
                var service = new Service
                {
                    Name = "Услуги по оформлению документов",
                    Quantity = apcnt,
                    Price = vprice,
                    VAT = true,
                    Department = 1,
                };

                services.Add(service);
            }

            if (doc.AnketaSrv > 0)
            {
                var service = new Service
                {
                    Name = "Услуги по заполнению и распечатке анкеты заявителя",
                    Quantity = doc.AnketaSrv,
                    Price = doc.PriceRate.AnketaPrice,
                    VAT = true,
                    Department = 1,
                };

                services.Add(service);
            }

            if (doc.PrintSrv > 0)
            {
                var service = new Service
                {
                    Name = "Услуги по распечатке документов",
                    Quantity = doc.PrintSrv,
                    Price = doc.PriceRate.PrintPrice,
                    VAT = true,
                    Department = 1,
                };

                services.Add(service);
            }

            if (doc.PhotoSrv > 0)
            {
                var service = new Service
                {
                    Name = "Услуги фотосъемки и изготовления фото",
                    Quantity = doc.PhotoSrv,
                    Price = doc.PriceRate.PhotoPrice,
                    VAT = true,
                    Department = 1,
                };

                services.Add(service);
            }

            if (doc.VIPSrv > 0)
            {
                var service = new Service
                {
                    Name = "Услуги по ВИП обслуживанию",
                    Quantity = doc.VIPSrv,
                    Price = doc.PriceRate.VIPPrice,
                    VAT = true,
                    Department = 1,
                };

                services.Add(service);
            }

            if (Prices.Concil(doc) > 0)
            {
                var concils = Prices.ConcilByType(doc);

                foreach (var concil in concils)
                {
                    var service = new Service
                    {
                        Name = $"Консульский сбор {concil.Key}",
                        Quantity = 1,
                        Price = concil.Value,
                        VAT = false,
                        Department = 2,
                    };

                    services.Add(service);
                }
            }

            return services;
        }
    }
}
