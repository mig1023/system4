namespace system4.BLL.Finances
{
    public class Constants
    {
        public static string CentersCode(int center)
        {
            var codes = new Dictionary<int, string>
            {
                [1] = "00",
                [2] = "01",
                [9] = "02",
                [8] = "03",
                [3] = "04",
                [5] = "05",
                [7] = "06",
                [6] = "07",
                [4] = "08",
                [12] = "10",
                [13] = "11",
                [14] = "12",
                [15] = "14",
                [16] = "15",
                [18] = "16",
                [17] = "17",
                [19] = "18",
                [20] = "19",
                [22] = "20",
                [21] = "21",
                [23] = "22",
                [25] = "25",
                [24] = "26",
                [26] = "27",
                [31] = "91",
                [32] = "91",
                [36] = "93",
                [40] = "92",
                [41] = "92",
                [44] = "92",
                [45] = "92",
                [47] = "94",
                [48] = "00",

                [11] = "09",
                [27] = "23",
                [28] = "23",
                [29] = "09",
                [30] = "09",
                [33] = "30",
                [37] = "09",
                [38] = "29",
                [43] = "09",
            };

            return codes[center];
        }

        public static string ServicesCode(string service)
        {
            var codes = new Dictionary<string, string>
            {
                ["shipping"] = "501",
                ["sms"] = "300",
                ["tran"] = "000",
                ["xerox"] = "400",
                ["ank"] = "502",
                ["print"] = "503",
                ["photo"] = "504",
                ["vip"] = "505",
                ["service1"] = "506",
                ["service2"] = "704",
                ["service3"] = "000",
                ["service4"] = "705",
                ["service5"] = "511",
                ["service6"] = "512",
                ["service7"] = "513",
                ["service8"] = "514",
                ["service9"] = "515",
                ["service10"] = "000",
                ["service11"] = "520",
                ["service12"] = "531",
                ["service13"] = "532",
                ["service14"] = "533",
                ["service15"] = "534",
                ["service16"] = "516",
                ["service17"] = "517",
                ["service18"] = "521",
                ["service19"] = "301",
                ["service23"] = "521",
                ["piligrims"] = "701",
            };

            return codes[service];
        }
    }
}
