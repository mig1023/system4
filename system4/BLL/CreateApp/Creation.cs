namespace system4.BLL.CreateApp
{
    public class Creation
    {
        public static int Save(AppointmentForm appointment, string user)
        {
            var dwhom = new Dictionary<string, int>
            {
                ["inPerson"] = 0,
                ["byProxy"] = 1,
                ["byRelatives"] = 2,
            };

            var newAppointment = new DB.Appointment
            {
                NCount = 0,
                Status = 1,
                AppDate = appointment.AppDate,
                AppTime = "10:00",
                TimeslotId = 0,
                RDate = DateTime.Now,
                CenterId = appointment.Center,
                Login = user,
                EMail = appointment.EMail,
                Phone = appointment.Phone,
                Mobile = appointment.Mobile ?? string.Empty,
                Notes = string.Empty,
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
                TFName = string.Empty,
                TLName = string.Empty,
                Shipping = 0,
                ShAddress = string.Empty,
                Dwhom = dwhom[appointment.Whom],
                SessionID = string.Empty,
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
                    AMobile = string.Empty,
                    ASAddr = string.Empty
                };
            }

            return DB.Entity.Save.Appointment(newAppointment, newApplicants);
        }
    }
}
