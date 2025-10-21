namespace system4.API
{
    public class Secret
    {
        public static Dictionary<string, string> Dadata = new Dictionary<string, string>
        {
            ["Url"] = "127.0.0.1",
            ["Token"] = "",
        };

        public static Dictionary<string, Dictionary<string, string>> Fox = new Dictionary<string, Dictionary<string, string>>
        {
            ["Url"] = new Dictionary<string, string>
            {
                ["Calc"] = "127.0.0.1",
                ["Order"] = "127.0.0.1",
                ["Track"] = "127.0.0.1",
                ["Document"] = "127.0.0.1",
            },
            ["Moscow"] = new Dictionary<string, string>
            {
                ["Login"] = "",
                ["Password"] = "",
                ["SenderAddress"] = "",
            },
            ["SPb"] = new Dictionary<string, string>
            {
                ["Login"] = "",
                ["Password"] = "",
                ["SenderAddress"] = "",
            },
        };
    }
}
