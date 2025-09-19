using system4.DB;

namespace system4.BLL
{
    public class Timeslots
    {
        public static TimeData Time(Appointment app)
        {
            TimeSpan start;

            if (string.IsNullOrEmpty(app.AppTime))
            {
                var oldTimedata = DB.Entity.Get.TimeDataById(app.TimeslotId);
                start = TimeSpan.FromSeconds(oldTimedata.TStart);
            }
            else
            {
                TimeSpan.TryParse(app.AppTime, out start);
            }

            var tDate = DB.Entity.Get.Timeslots(app.CenterId, app.AppDate);
            var tStart = (int)start.TotalSeconds;
            var timedata = DB.Entity.Get.TimeDataByTStart(tDate.Id, tStart);

            return timedata;
        }
    }
}
