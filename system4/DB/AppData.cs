using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class AppData
    {
        [Key]
        public int ID { get; set; }

        public int AppID { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public string RFName { get; set; }

        public string RMName { get; set; }

        public string RLName { get; set; }

        public string PassNum { get; set; }

        public string RPassNum { get; set; }

        public DateTime RPWhen { get; set; }

        public string RPWhere { get; set; }

        public DateTime BirthDate { get; set; }

        public int Status { get; set; }

        public int isChild { get; set; }

        public int PolicyType { get; set; }

        public string PolicyNum { get; set; }

        public string PolicyErr { get; set; }

        public int InsurerID { get; set; }

        public int DListID { get; set; }

        public int NRes { get; set; }

        public string AMobile { get; set; }

        public string ASAddr { get; set; }

        public string PolicyID { get; set; }

        public string PrevLNames { get; set; }

        public string BrhPlace { get; set; }

        public string BrhCountry { get; set; }

        public string Citizenship { get; set; }

        public string PrevCitizenship { get; set; }

        public int Gender { get; set; }

        public int Family { get; set; }

        public string FullAddress { get; set; }

        public string AppPhone { get; set; }

        public string KinderData { get; set; }

        public int DocType { get; set; }

        public DateTime PassDate { get; set; }

        public string DocTypeOther { get; set; }

        public DateTime PassTill { get; set; }

        public string PassWhom { get; set; }

        public int CountryLive { get; set; }

        public string VidNo { get; set; }

        public DateTime VidTill { get; set; }

        public string ProfActivity { get; set; }

        public string WorkOrg { get; set; }

        public string VisaPurpose { get; set; }

        public string VisaOther { get; set; }

        public string Countries { get; set; }

        public string FirstCountry { get; set; }

        public int VisaNum { get; set; }

        public DateTime AppSDate { get; set; }

        public DateTime AppFDate { get; set; }

        public string CalcDuration { get; set; }

        public int PrevVisa { get; set; }

        public DateTime PrevVisaFD { get; set; }

        public DateTime PrevVisaED { get; set; }

        public int Fingers { get; set; }

        public DateTime FingersDate { get; set; }

        public string Permesso { get; set; }

        public DateTime PermessoFD { get; set; }

        public DateTime PermessoED { get; set; }

        public string Hotels { get; set; }

        public string HotelAdresses { get; set; }

        public string HotelPhone { get; set; }

        public string ACompanyName { get; set; }

        public string ACompanyAddress { get; set; }

        public string ACompanyPhone { get; set; }

        public string ACompanyFax { get; set; }

        public string ACopmanyPerson { get; set; }

        public int MezziWhom { get; set; }

        public string MezziWhomOther { get; set; }

        public string Mezzi { get; set; }

        public string MezziOtherSrc { get; set; }

        public int FamRel { get; set; }

        public string EuLName { get; set; }

        public string EuFName { get; set; }

        public DateTime EuBDate { get; set; }

        public string EuCitizen { get; set; }

        public string EuPassNum { get; set; }

        public string IDNumber { get; set; }

        public DateTime AnkDate { get; set; }

        public string AnketaC { get; set; }

        public string FamilyOther { get; set; }

        public string CountryRes { get; set; }

        public string City { get; set; }

        public string Nulla { get; set; }

        public string NullaCity { get; set; }

        public string? FirstCity { get; set; }

        public int? SchengenAppDataID { get; set; }

        public DateTime? AppDateBM { get; set; }

        public int? TimeslotBMID { get; set; }

        //public int? ConcilFree { get; set; }

        public int? Short { get; set; }

        public int? AnketaSrv { get; set; }

        public int? PhotoSrv { get; set; }

        public string? SchengenJSON { get; set; }

        public string? AdditionalPurpose { get; set; }

        public string? OtherCitizenship { get; set; }

        public string? VisaAdeviso { get; set; }

        public int? ConcilOnlinePay { get; set; }

        public int? BlockOnlineApp { get; set; }

        public string? CheckDocComment { get; set; }

        public string? OtherPeopleFillDataNames { get; set; }

        public string? OtherPeopleFillDataAddress { get; set; }

        public string? OtherPeopleFillDataPhone { get; set; }
    }
}
