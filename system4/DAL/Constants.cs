using System.Xml.Linq;

namespace system4.DAL
{
    public class Constants
    {
        public const int PageSize = 10;

        public static string AppStatuses(int status)
        {
            var statuses = new Dictionary<int, string>
            {
                [1] = "pending",
                [2] = "canceled",
                [3] = "no_show",
                [4] = "complete",
                [5] = "revisit",

                [10] = "doc_preview",
                [11] = "doc_checked",
                [12] = "doc_complete",

                [13] = "remote_app",
            };

            return statuses[status];
        }

        public static string DocStatuses(int status)
        {
            var statuses = new Dictionary<int, string>
            {
                [1] = "wait_for_payment",
                [2] = "payed",
                [3] = "in_consulate",
                [4] = "doc_ready",
                [5] = "delivering",
                [6] = "complete",
                [7] = "deleted",
                [8] = "returned_to_consulate",
                [9] = "received",
                [10] = "sent_to_HQ",
                [11] = "received_in_HQ",
                [12] = "sent_to_branch",
                [13] = "received_in_branch",
                [14] = "to_be_sent_to_branch",
                [15] = "temporary_in_HQ",
                [16] = "correction",

                [25] = "wait_for_fox",
                [26] = "received_from_fox",
                [27] = "delivering_by_fox",

                [30] = "request"
            };

            return statuses[status];
        }

        public static string FingerStatuses(int? status)
        {
            var statuses = new Dictionary<int, string>
            {
                [1] = "pending",
                [2] = "complete",
                [3] = "N/A",
            };

            return statuses[status ?? 1];
        }

        public static string PaymentType(int? type)
        {
            var statuses = new Dictionary<int, string>
            {
                [1] = "наличные",
                [2] = "безналичный",
                [3] = "банковская карта",
                [4] = "банковская карта (сайт)",
            };

            return statuses[type ?? 1];
        }

        public static Services BanalServices(string name)
        {
            var services = new Dictionary<string, Services>
            {
                ["Xerox"] = new Services { Name = "Ксерокопия" },
                ["Translate"] = new Services { Name = "Перевод" },
                ["Anketa"] = new Services { Name = "Заполнение анкеты" },
                ["Printing"] = new Services { Name = "Распечатка" },
                ["Photo"] = new Services { Name = "Фото" },
                ["Shipping"] = new Services { Name = "Доставка" },
            };

            var service = services[name];
            service.ServiceName = name;

            if (string.IsNullOrEmpty(service.ValueType))
            {
                service.ValueType = "2";
            }

            return service;
        }

        public static Dictionary<string, Dictionary<string, string>> Requests()
        {
            var requests = new Dictionary<string, Dictionary<string, string>>
            {
                ["VisaType"] = new Dictionary<string, string>
                {
                    ["A"] = "A - AIRPORT TRANSIT VISA TYPE",
                    ["C"] = "C - SHORT STAY VISA TYPE",
                    ["C1"] = "C1 - ONE YEAR STAY VISA TYPE",
                    ["C2"] = "C2 - TWO YEARS STAY VISA TYPE",
                    ["C3"] = "C3 - THREE YEARS STAY VISA TYPE",
                    ["C5"] = "C5 - FIVE YEARS STAY VISA TYPE",
                    ["D"] = "D - NATIONAL VISA TYPE",
                },
                ["TravelPurp"] = new Dictionary<string, string>
                {
                    ["AF"] = "COMMERCIAL AFFAIRS",
                    ["TU"] = "TOURISM",
                },
                ["NumEntries"] = new Dictionary<string, string>
                {
                    ["M"] = "MULT",
                    ["1"] = "01",
                    ["2"] = "02",
                },
                ["FirstEntry"] = new Dictionary<string, string>
                {
                    ["A"] = "AUSTRIA",
                    ["B"] = "BELGIO",
                    ["BGR"] = "BULGARIA",
                    ["HRV"] = "CROATIA",
                    ["DK"] = "DANIMARCA",
                    ["EE"] = "ESTONIA",
                    ["FI"] = "FINLANDIA",
                    ["F"] = "FRANCIA",
                    ["D"] = "GERMANIA",
                    ["GR"] = "GRECIA",
                    ["IS"] = "ISLANDA",
                    ["I"] = "ITALIA",
                    ["LV"] = "LETTONIA",
                    ["LT"] = "LITUANIA",
                    ["L"] = "LUSSEMBURGO",
                    ["MT"] = "MALTA",
                    ["N"] = "NORVEGIA",
                    ["NL"] = "PAESI BASSI",
                    ["PL"] = "POLONIA",
                    ["P"] = "PORTOGALLO",
                    ["CZ"] = "REPUBBLICA CECA",
                    ["ROU"] = "ROMANIA",
                    ["SK"] = "SLOVACCHIA",
                    ["SI"] = "SLOVENIA",
                    ["E"] = "SPAGNA",
                    ["S"] = "SVEZIA",
                    ["CH"] = "SVIZZERA",
                    ["HU"] = "UNGHERIA",
                },
                ["SchengenItalianBrd"] = new Dictionary<string, string>(),
            };

            foreach (var schengen in DB.Entity.Get.SchengenItalianBrd())
            {
                requests["SchengenItalianBrd"].Add(schengen.SCHID.ToString(), schengen.Name);
            }

            return requests;
        }
    }
}
