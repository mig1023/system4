namespace system4.BLL.CreateApp
{
    public class AppointmentForm
    {
        public List<ApplicantForm> Applicants { get; set; }// = new List<DynamicItem>();

        public AppointmentForm()
        {
            Applicants = new List<ApplicantForm>();
        }
    }
}
