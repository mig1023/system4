using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class PriceRate
    {
        [Key]
        public int Id { get; set; }

        public DateTime RDate { get; set; }

        public int isDeleted { get; set; }

        public string Currency { get; set; }

        public string ConcilCurrency { get; set; }

        public float Shipping { get; set; }

        public float IntShipping { get; set; }

        public int BranchId { get; set; }

        public float SMS { get; set; }

        public float XeroxPrice { get; set; }

        public int ShipNoVAT { get; set; }

        public float TranslatePr { get; set; }

        public float AnketaPrice { get; set; }

        public float PrintPrice { get; set; }

        public float PhotoPrice { get; set; }

        public float VIPPrice { get; set; }

        public string Ages { get; set; }

        public string AgesFree { get; set; }

        public string AgAutoFormat { get; set; }

        public string AgFAutoFormat { get; set; }

        public string SAutoFormat { get; set; }
    }
}
