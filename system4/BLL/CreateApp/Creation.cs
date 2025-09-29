namespace system4.BLL.CreateApp
{
    public class Creation
    {
        private static void FillAllNullableProperties(object app)
        {
            foreach (var property in app.GetType().GetProperties())
            {
                if (property.GetValue(app) != null)
                {
                    continue;
                }
                else if (Nullable.GetUnderlyingType(property.PropertyType) != null)
                {
                    continue;
                }
                else if (property.PropertyType == typeof(string))
                {
                    property.SetValue(app, string.Empty);
                }
                else if (property.PropertyType == typeof(DateTime))
                {
                    property.SetValue(app, DateTime.MinValue);
                }
                else
                {
                    property.SetValue(app, 0);
                }
            }
        }

        public static int Save(AppointmentForm appointment, string user)
        {
            var dwhom = new Dictionary<string, int>
            {
                ["inPerson"] = 0,
                ["byProxy"] = 1,
                ["byRelatives"] = 2,
            };

            var appTimeslot = DB.Entity.Get.TimeDataById(appointment.AppTime);
            var appTime = TimeSpan.FromSeconds(appTimeslot.TStart);

            var newAppointment = new DB.Appointment
            {
                NCount = appointment.Applicants.Count,
                Status = 1,
                AppDate = appointment.AppDate,
                AppTime = appTime.ToString(@"hh\:mm"),
                TimeslotId = 0,
                RDate = DateTime.Now,
                CenterId = appointment.Center,
                Login = user,
                EMail = appointment.EMail,
                Phone = appointment.Phone,
                Mobile = appointment.Mobile ?? string.Empty,
                Address = appointment.Address ?? string.Empty,
                SMS = appointment.SMS ? 1 : 0,
                FName = appointment.FName ?? string.Empty,
                LName = appointment.LName ?? string.Empty,
                MName = appointment.MName ?? string.Empty,
                PassNum = appointment.PassNum ?? string.Empty,
                PassDate = appointment.PassDate,
                PassWhom = appointment.PassWhom ?? string.Empty,
                SDate = appointment.SDate,
                FDate = appointment.FDate,
                Urgent = appointment.Urgent ? 1 : 0,
                VType = appointment.VisaType,
                Shipping = 0,
                Dwhom = dwhom[appointment.Whom],
            };

            var newApplicants = new List<DB.AppData>();

            foreach (var applicant in appointment.Applicants)
            {
                var newApplicant = new DB.AppData
                {
                    FName = applicant.FName,
                    LName = applicant.LName,
                    PassNum = applicant.PassNum,
                    BirthDate = applicant.BirthDate,
                    isChild = applicant.IsChild ? 1 : 0,
                    RFName = applicant.RFName,
                    RLName = applicant.RLName,
                    RMName = applicant.RMName,
                    RPassNum = applicant.RPassNum,
                    RPWhen = applicant.RPWhen,
                    RPWhere = applicant.RPWhere,
                    Status = 1,
                    NRes = applicant.NRes ? 1 : 0,
                };

                FillAllNullableProperties(newApplicant);
                newApplicants.Add(newApplicant);
            }

            return DB.Entity.Save.Appointment(newAppointment, newApplicants);
        }
    }
}
