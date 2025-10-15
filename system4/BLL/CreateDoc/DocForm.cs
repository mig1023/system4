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

        public string PassNum { get; set; }
        public DateTime PassDate { get; set; }
        public string PassWhom { get; set; }

        public string DovNumber { get; set; }
        public DateTime DovDate { get; set; }

        public string Phone { get; set; }
        public string Address { get; set; }
        public string InfoMail { get; set; }

        public string Comment { get; set; }

        public string Requests { get; set; }

        public DocForm()
        {
            Applicants = new List<ApplicantForm>();
        }
    }
}
