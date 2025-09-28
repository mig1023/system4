using static system4.DB.Entity.Contextcs;

namespace system4.DB.Entity
{
    public class Numbering
    {
        public static string Appointment(DateTime date, int centerId)
        {
            using (var db = new EntityContext())
            {
                var apps = db.Appointments
                    .Where(x => (x.AppDate == date.Date) && (x.CenterId == centerId))
                    .Max(x => x.AppNum);

                var newAppointment = string.Empty;
                var center = string.Format("{0:d3}", centerId);
                var currentDate = date.ToString("yyyyMMdd");

                if (apps == null)
                {
                    return $"{center}{currentDate}0001";
                }
                else
                {
                    var line = apps.Substring(apps.Length - 4);
                    var number = int.Parse(line);
                    number += 1;

                    return $"{center}{currentDate}{number}";
                }
            }
        }
    }
}
