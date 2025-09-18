using system4.DB;

namespace system4.BLL
{
    public class Timeslots
    {
        public static TimeData Time(Appointment app)
        {
            if (string.IsNullOrEmpty(app.AppTime))
            {
                return DB.Entity.Get.TimeData(app.TimeslotId);
            }
            else
            {
                TimeSpan.TryParse(app.AppTime, out TimeSpan start);

                var tDate = DB.Entity.Get.Timeslot(app.CenterId, app.AppDate);
                var tStart = (int)start.TotalSeconds;
                var tEnd = DB.Entity.Get.TimeData(tDate.Id, tStart);

                return new TimeData
                {
                    TStart = tStart,
                    TEnd = tEnd.TEnd,
                };
            }
        }
    }
}
