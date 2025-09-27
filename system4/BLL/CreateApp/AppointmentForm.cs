namespace system4.BLL.CreateApp
{
    public class AppointmentForm
    {
        public int Center { get; set; }

        public int VisaType { get; set; }

        public DateTime AppDate { get; set; }

        public int AppTime { get; set; }

        public string Whom { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public string MName { get; set; }

        public string PassNum { get; set; }

        public DateTime PassDate { get; set; }

        public string PassWhom { get; set; }

        public List<ApplicantForm> Applicants { get; set; }

        public AppointmentForm()
        {
            Applicants = new List<ApplicantForm>();
        }
    }
}
