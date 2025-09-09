using System;

namespace system4.BLL.Finances
{
    public class Services
    {
        public static List<Service> Get(DAL.DocPack doc)
        {
            // var insurance =
            // var additionalServices =

            var services = new List<Service>
            {
                new Service
                {
                    Name = "Услуги по оформлению документов",
                    Quantity = doc.Applicants.Where(x => !x.IsDeleted()).Count(),
                    Price = Prices.Services(doc),
                    VAT = true,
                    Department = 1,
                    Code = Code.Service(doc, "visa"),
                }
            };

            if (doc.Shipping > 0)
            {
                var service = new Service
                {
                    Name = "Услуги по доставке документов на дом",
                    Quantity = 1,
                    Price = doc.TShipSum,
                    VAT = true,
                    Department = 1,
                    Shipping = true,
                    Code = Code.Service(doc, "shipping"),
                };

                services.Add(service);
            }

            if (doc.SMS > 0)
            {
                var service = new Service
                {
                    Name = "Услуги по оповещению (СМС сообщение)",
                    Quantity = 1,
                    Price = doc.PriceRate.SMS,
                    VAT = true,
                    Department = 1,
                    Code = Code.Service(doc, "sms"),
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
                    Code = Code.Service(doc, "tran"),
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
                    Code = Code.Service(doc, "xerox"),
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
                    Code = Code.Service(doc, "ank"),
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
                    Code = Code.Service(doc, "print"),
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
                    Code = Code.Service(doc, "photo"),
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
                    Code = Code.Service(doc, "vip"),
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
                        Code = string.Empty,
                    };

                    services.Add(service);
                }
            }

            return services;
        }
    }
}
