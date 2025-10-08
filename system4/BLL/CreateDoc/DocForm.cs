namespace system4.BLL.CreateDoc
{
    public class DocForm
    {
        public int VisaType { get; set; }

        public bool Urgent { get; set; }

        public List<ApplicantForm> Applicants { get; set; }

        public DocForm()
        {
            Applicants = new List<ApplicantForm>();
        }
    }
}
