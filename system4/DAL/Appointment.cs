using system4.DB;

namespace system4.DAL
{
    public class Appointment : DB.Appointment
    {
        public Branches Center { get; set; }

        public VisaTypes VisaType { get; set; }

        public List<DB.AppData> AppData { get; set; }

        public List<AppComments> Comments { get; set; }

        public DB.TimeData TimeData { get; set; }

        private static Appointment Converter(DB.Appointment dbApp)
        {
            var app = new Appointment();

            foreach (var prop in dbApp.GetType().GetProperties())
            {
                app.GetType().GetProperty(prop.Name).SetValue(app, prop.GetValue(dbApp, null), null);
            }

            return app;
        }

        public static Appointment Get(int appid)
        {
            if (appid == 0)
            {
                return null;
            }

            var dbApp = DB.Entity.Get.App(appid);
            var app = Converter(dbApp);

            app.Comments = DB.Entity.Get.AppComments(appid);
            app.Center = DB.Entity.Get.Branches(app.CenterId);
            app.VisaType = DB.Entity.Get.VisaTypes(app.VType);
            app.AppData = DB.Entity.Get.AppData(appid);
            app.TimeData = BLL.Timeslots.Get.Time(app);

            return app;
        }

        public static List<Appointment> List(string search, int? page, out int pageCount)
        {
            List<int> appIds = new List<int>();
            int count = 0;

            if (DateTime.TryParse(search, out DateTime date))
            {
                appIds = DB.Entity.Get
                    .AppsByDate(date, page ?? 1, Constants.PageSize, out count);
            }
            else if (Formats.OnlyNumeric(search).Length == 15)
            {
                var id = DB.Entity.Get.AppByNum(Formats.OnlyNumeric(search));

                if (id > 0)
                {
                    appIds.Add(id);
                    count = 1;
                }
            }
            else if (search.Length == 9)
            {
                appIds = DB.Entity.Get
                    .AppsByPassnum(search, page ?? 1, Constants.PageSize, out count);
            }

            var apps = appIds
                .Select(x => Get(x))
                .ToList();

            pageCount = (int)Math.Ceiling((double)count / Constants.PageSize);

            return apps;
        }
    }
}
