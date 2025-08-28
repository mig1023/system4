using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class Branches
    {
        [Key]
        public int Id { get; set; }

        public string BName { get; set; }

        public int? Ord { get; set; }

        public int Timezone { get; set; }

        public int isDeleted { get; set; }

        public int isDefault { get; set; }

        public int Display { get; set; }

        public int Insurance { get; set; }

        public string BAddr { get; set; }

        public string JAddr { get; set; }

        public int? AddrEqualled { get; set; }

        public int? SenderID { get; set; }

        public string CTemplate { get; set; }

        public int isConcil { get; set; }

        public int isSMS { get; set; }

        public int isSMSconfirm { get; set; }

        public int isUrgent { get; set; }

        public int posShipping { get; set; }

        public int isDover { get; set; }

        public int calcInsurance { get; set; }

        public int cdSimpl { get; set; }

        public int cdUrgent { get; set; }

        public int cdCatD { get; set; }

        public int CollectDate { get; set; }

        public string siteLink { get; set; }

        public int calcConcil { get; set; }

        public int ConsNDS { get; set; }

        public int genbank { get; set; }

        public int isTranslate { get; set; }

        public int shengen { get; set; }

        public int isAnketa { get; set; }

        public int isPrinting { get; set; }

        public int isPhoto { get; set; }

        public int isVIP { get; set; }

        public int Weekend { get; set; }

        public int isShippingFree { get; set; }

        // public int isPrepayedAppointment { get; set; }

        public int DefaultPaymentMethod { get; set; }

        public int DisableAppSameDay { get; set; }

        public int CityID { get; set; }

        public int RegionType { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? SubmissionTime { get; set; }

        public string? CollectionTime { get; set; }
    }
}
