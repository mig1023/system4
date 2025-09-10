using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class Companies
    {
        [Key]
        public int Id { get; set; }

        public string CName { get; set; }

        public string BName { get; set; }

        public string Address { get; set; }

        public string? EMail { get; set; }

        public string? ResponsiblePhone { get; set; }

        public int? SendingReport { get; set; }

        public int? SendingStop { get; set; }

        public string INN { get; set; }

        public string KPP { get; set; }

        public string Bank { get; set; }

        public string RS { get; set; }

        public string KS { get; set; }

        public string BIK { get; set; }

        public string Phone { get; set; }

        public int Blocked { get; set; }

        public string Reason { get; set; }

        public string UpdLogin { get; set; }

        public int isDeleted { get; set; }

        public string AgreementNo { get; set; }

        public string Currency { get; set; }

        public DateTime AgrDate { get; set; }

        public string FAddress { get; set; }

        public int RCenter { get; set; }

        public string? NoteDetailsRU { get; set; }

        public string? NoteDetailsEN { get; set; }

        public string? NoteChief { get; set; }

        public string? InsuranceCompany { get; set; }
    }
}
