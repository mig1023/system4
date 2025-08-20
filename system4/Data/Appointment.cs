using System;
using System.Text.RegularExpressions;
using system4.DB;

namespace system4.Data
{
    public class Appointment : DB.Appointment
    {
        public Branches Center { get; set; }

        public VisaTypes VisaType { get; set; }

        public List<AppData> AppData { get; set; }

        public List<AppComments> Comments { get; set; }

        public string StatusLine { get; set; }

        public string SMSLine { get; set; }

        public string DeliveringLine { get; set; }

        public List<string> POALines { get; set; }

        private static Appointment Converter(DB.Appointment dbApp)
        {
            var app = new Appointment();

            foreach (var prop in dbApp.GetType().GetProperties())
            {
                app.GetType().GetProperty(prop.Name).SetValue(app, prop.GetValue(dbApp, null), null);
            }

            var appNum = Regex
                .Match(app.AppNum, @"(\d\d\d)(\d\d\d\d)(\d\d)(\d\d)(\d\d\d\d)")
                .Groups
                .Cast<Group>()
                .ToList();

            appNum.RemoveAt(0);
            app.AppNum = string.Join("/", appNum);

            app.SMSLine = app.SMS > 0 ? $"SMS ({app.Mobile})" : "нет";
            app.DeliveringLine = app.Shipping > 0 ? app.ShAddress : "нет";

            app.POALines = new List<string>
            {
                $"по доверенности ",
                $"{app.LName} {app.FName} {app.MName}",
                $"{app.PassNum}",
                $"{app.PassWhom}"
            }; 

            return app;
        }

        public static Appointment Get(int appid)
        {
            var app = Converter(DB.Entity.Get.App(appid));
            
            app.Comments = DB.Entity.Get.AppComments(appid);
            app.Center = DB.Entity.Get.Branches(app.CenterID);
            app.VisaType = DB.Entity.Get.VisaTypes(app.VType);
            app.StatusLine = DB.Entity.Get.Statuses(app.Status);

            app.AppData = DB.Entity.Get.AppData(appid)
                .Select(x => Data.AppData.Converter(x))
                .ToList();

            return app;
        }

        public static List<Appointment> List(string search)
        {
            var apps = DB.Entity.Get.AppsByDate(DateTime.Parse(search))
                .Select(x => Converter(x))
                .ToList();

            return apps;
        }
    }
}
