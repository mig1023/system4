using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class Appointments
    {
        [Key]
        public int Id { get; set; }

        public string AppNum { get; set; }

        public DateTime AppDate { get; set; }

        public int TimeslotID { get; set; }

        public DateTime RDate { get; set; }

        public int CenterID { get; set; }

        public string Login { get; set; }

        public string EMail { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string Notes { get; set; }

        public string Address { get; set; }

        public int NCount { get; set; }

        public int Status { get; set; }

        public DateTime? ReleaseTime { get; set; }

        public int SMS { get; set; }

        public int Telephone { get; set; }

        public string? TelephoneNum { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public string MName { get; set; }

        public string PassNum { get; set; }

        public DateTime PassDate { get; set; }

        public string PassWhom { get; set; }

        public string SessionID { get; set; }

        public DateTime SDate { get; set; }

        public DateTime FDate { get; set; }

        public int Duration { get; set; }

        public int Urgent { get; set; }

        public int VType { get; set; }

        public string TFName { get; set; }

        public string TLName { get; set; }

        public DateTime TBDate { get; set; }

        public int PolicyType { get; set; }

        public int PacketID { get; set; }

        public int Shipping { get; set; }

        public string ShAddress { get; set; }

        public int Dwhom { get; set; }

        public int? CompanyID { get; set; }

        public int? Draft { get; set; }

        public string? Itinerario { get; set; }

        public string? Vettore { get; set; }

        public string? Frontiera { get; set; }

        public int? Cost { get; set; }

        public string? BankID { get; set; }

        public int? PrintSrv { get; set; }

        public int? OfficeToReceive { get; set; }
    }
}
