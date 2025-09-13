namespace system4.BLL.CreateApp
{
    public class AppointmentForm
    {
        public int Center { get; set; }

        public int VisaType { get; set; }

        public List<ApplicantForm> Applicants { get; set; }

        public AppointmentForm()
        {
            Applicants = new List<ApplicantForm>();
        }
    }
}
