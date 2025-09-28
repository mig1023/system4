using static system4.DB.Entity.Contextcs;

namespace system4.DB.Entity
{
    public class Save
    {
        public static int Appointment(Appointment appointment, List<AppData> appData)
        {
            using (var db = new EntityContext())
            {
                int appId = 0;

                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var appNum = Numbering.Appointment(appointment.AppDate, appointment.CenterId);
                        appointment.AppNum = appNum;

                        db.Appointments.Add(appointment);
                        db.SaveChanges();

                        appId = appointment.Id;

                        foreach (var app in appData)
                        {
                            app.AppId = appId;
                        }

                        db.AppData.AddRange(appData);
                        db.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                }

                return appId;
            }
        }
    }
}
