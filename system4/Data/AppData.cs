using System.Text.RegularExpressions;

namespace system4.Data
{
    public class AppData : DB.AppData
    {
        public string StatusLine { get; set; }

        public static AppData Converter(DB.AppData dbApp)
        {
            var app = new AppData();

            foreach (var prop in dbApp.GetType().GetProperties())
            {
                app.GetType().GetProperty(prop.Name).SetValue(app, prop.GetValue(dbApp, null), null);
            }

            app.StatusLine = DB.Entity.Get.Statuses(app.Status);

            return app;
        }
    }
}
