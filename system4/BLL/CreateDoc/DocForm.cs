namespace system4.BLL.CreateDoc
{
    public class DocForm
    {
        public int VisaType { get; set; }

        public bool Urgent { get; set; }

        public List<ApplicantForm> Applicants { get; set; }

        public ApplicantForm ApplicantDwhom { get; set; }

        public string LName { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }

        public DocForm()
        {
            Applicants = new List<ApplicantForm>();
        }
    }
}
