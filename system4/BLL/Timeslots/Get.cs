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

        private static void SetCurrentAvailability(ref Availability currentAvailability, DateTime? pastDay)
        {
            if (currentAvailability == null)
                return;

            currentAvailability.End = pastDay ?? DateTime.Now;
        }

        public static List<Availability> Period(int centerId)
        {
            var center = DB.Entity.Get.Branches(centerId);
            var startDate = DateTime.Now.Date;
            // var endDate = center.AppointmentsOpenUntil;
            // !!
            var endDate = new DateTime(2025, 12, 31);

            var timeslots = DB.Entity.Get.Timeslots(centerId);
            var apps = DB.Entity.Get.AppsCountByPeriod(startDate, endDate, centerId);

            var availabilities = new List<Availability>();
            var currentMonth = 0;
            DateTime? pastDay = null;
            Availability currentAvailability = null;

            for (var currentDay = startDate; currentDay <= endDate; currentDay = currentDay.AddDays(1))
            {
                if (currentDay.Month != currentMonth)
                {
                    SetCurrentAvailability(ref currentAvailability, pastDay);

                    currentMonth = currentDay.Month;
                    currentAvailability = new Availability
                    {
                        Start = currentDay,
                        Dates = new Dictionary<DateTime, string>()
                    };

                    availabilities.Add(currentAvailability);
                }

                pastDay = currentDay;

                var timeslot = timeslots
                    .Where(x => x.Key <= currentDay)
                    .OrderByDescending(x => x.Key)
                    .First();

                var appCount = apps.ContainsKey(currentDay.Date) ? apps[currentDay.Date] : 0;
                var dayOfWeek = (int)currentDay.DayOfWeek + 1;

                if (!timeslot.Value.ContainsKey(dayOfWeek))
                    continue;

                var timeslotCount = timeslot.Value[dayOfWeek];
                currentAvailability.Dates.Add(currentDay, $"{appCount}-{timeslotCount}");
            }

            SetCurrentAvailability(ref currentAvailability, pastDay);

            return availabilities;
        }
    }
}
