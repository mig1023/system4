namespace system4.DAL
{
    public class AppData : DB.AppData
    {
        public static AppData Converter(DB.AppData dbApp)
        {
            var app = new AppData();

            foreach (var prop in dbApp.GetType().GetProperties())
            {
                app.GetType().GetProperty(prop.Name).SetValue(app, prop.GetValue(dbApp, null), null);
            }

            return app;
        }
    }
}
