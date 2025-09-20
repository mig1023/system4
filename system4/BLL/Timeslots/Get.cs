using system4.DB;

namespace system4.BLL.Timeslots
{
    public class Get
    {
        private static int DayOfWeek(DateTime date) =>
            date.DayOfWeek == 0 ? 7 : (int)date.DayOfWeek;

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
            var timedata = DB.Entity.Get.TimeDataByTStart(tDate.Id, tStart, DayOfWeek(app.AppDate));

            return timedata;
        }

        public static List<Timeslot> Day(int centerId, DateTime date)
        {
            var dayNum = DayOfWeek(date);
            var tDate = DB.Entity.Get.Timeslots(centerId, date);
            var appointments = DB.Entity.Get.AppsByDate(date, centerId);

            var timeslots = DB.Entity.Get
                .TimeDataByTimeslot(tDate.Id, dayNum)
                .Select(x => new Timeslot(x))
                .ToList();

            foreach (var appointment in appointments)
            {
                if (appointment.Status == 2)
                    continue;

                var time = Time(appointment);

                var timeslot = timeslots
                    .FirstOrDefault(x => x.Id == time.SlotId);

                if (timeslot != null)
                    timeslot.Applicants += appointment.NCount;
            }

            foreach (var timeslot in timeslots)
            {
                var percent = timeslot.Applicants / timeslot.Visas * 100;
                timeslot.Percentage = 100 - percent;
            }

            return timeslots;
        }

        public static List<string> AllDates(int centerId)
        {
            return null;
        }
    }
}
