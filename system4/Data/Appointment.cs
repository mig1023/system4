using System;
using System.Text.RegularExpressions;
using system4.DB;

namespace system4.Data
{
    public class Appointment : DB.Appointment
    {
        public List<AppData> AppData { get; set; }

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

            return app;
        }

        public static Appointment Get(int appid)
        {
            var app = Converter(DB.Entity.Get.App(appid));

            app.AppData = DB.Entity.Get.AppData(appid);

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
