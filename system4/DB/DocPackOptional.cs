using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class DocPackOptional
    {
        [Key]
        public int DocPackId { get; set; }

        public int? ShippingFree { get; set; }

        public int? Reject { get; set; }

        public DateTime? ShReturnDate { get; set; }

        public string? ShReturnLogin { get; set; }

        public string? SendInfoEmail { get; set; }

        public string? PhoneForService { get; set; }

        public int? PhoneServiceTry { get; set; }

        public string? FeedbackKey { get; set; }

        public int? FeedbackParam1 { get; set; }

        public int? FeedbackParam2 { get; set; }

        public int? FeedbackParam3 { get; set; }

        public int? FeedbackParam4 { get; set; }

        public int? FeedbackParam5 { get; set; }

        public int? FeedbackParam6 { get; set; }

        public int? FeedbackParam7 { get; set; }

        public int? CountDDV { get; set; }
    }
}
