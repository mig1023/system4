using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class DocPack
    {
        [Key]
        public int ID { get; set; }

        public DateTime PDate { get; set; }

        public int PStatus { get; set; }

        public string Login { get; set; }

        public string AgreementNo { get; set; }

        public int PType { get; set; }

        public float DSum { get; set; }

        public int Urgent { get; set; }

        public int VisaType { get; set; }

        public int JurID { get; set; }

        public int AppID { get; set; }

        public int Shipping { get; set; }

        public int SMS { get; set; }

        public string Phone { get; set; }

        public DateTime DovDate { get; set; }

        public string DovNum { get; set; }

        public string Template { get; set; }

        public int CenterID { get; set; }

        public string Mobile { get; set; }

        public DateTime ADate { get; set; }

        public string PassNum { get; set; }

        public DateTime PassDate { get; set; }

        public string PassWhom { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public string MName { get; set; }

        public string Address { get; set; }

        public int RateID { get; set; }

        public string Cur { get; set; }

        public string ShippingAddress { get; set; }

        public int SMS_status { get; set; }

        public string SMS_reason { get; set; }

        public int XeroxPage { get; set; }

        public int AnketaSrv { get; set; }

        public int PrintSrv { get; set; }

        public int PhotoSrv { get; set; }

        public int VIPSrv { get; set; }

        public float InsSum { get; set; }

        public float TShipSum { get; set; }

        public float TShipReturn { get; set; }

        public float ServSum { get; set; }

        public DateTime LastUpdate { get; set; }

        public string ShipNum { get; set; }

        public string SMS_mesid { get; set; }

        public DateTime SMS_when { get; set; }

        public string RANum { get; set; }

        public int SkipIns { get; set; }

        public string AddrIndex { get; set; }

        public int DHL_IndexID { get; set; }

        public int Translate { get; set; }

        public string PersonalNo { get; set; }

        public int isNewDHL { get; set; }

        public DateTime ConcilPaymentDate { get; set; }

        public int? OfficeToReceive { get; set; }

        public string? ShippingPhone { get; set; }

        public string? InsData { get; set; }

        public int? NoReceived { get; set; }

    }
}
