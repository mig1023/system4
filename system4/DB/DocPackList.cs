using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class DocPackList
    {
        [Key]
        public int Id { get; set; }

        public int PackInfoId { get; set; }

        public string CBankId { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public string MName { get; set; }

        public int isChild { get; set; }

        public int Status { get; set; }

        public string PassNum { get; set; }

        public DateTime SDate { get; set; }

        public string Login { get; set; }

        public int ApplId { get; set; }

        public int Reject { get; set; }

        public int iNRes { get; set; }

        public int Concil { get; set; }

        public string MobileNums { get; set; }

        public string ShipAddress { get; set; }

        public string ShipNum { get; set; }

        public float RTShipSum { get; set; }

        public float RTShipReturn { get; set; }

        public string SMS_mesid { get; set; }

        public DateTime SMS_when { get; set; }

        public int SMS_status { get; set; }

        public string SMS_reason { get; set; }

        public string AddrIndexP { get; set; }

        public int DHL_LIndexID { get; set; }

        public string ShipPhone { get; set; }

        public string ShipMail { get; set; }

        public DateTime FlyDate { get; set; }

        public DateTime BthDate { get; set; }

        public int AgeCatA { get; set; }

        public int FPStatus { get; set; }
    }
}
