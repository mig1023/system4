using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class DocPackInfo
    {
        [Key]
        public int ID { get; set; }

        public int PackID { get; set; }

        public string BankID { get; set; }

        public float PSum { get; set; }

        public int VisaCnt { get; set; }

        public int Num_NR { get; set; }

        public int Num_NC { get; set; }

        public int Num_NN { get; set; }

        public string WhomFilled { get; set; }

        public DateTime WhenFilled { get; set; }

        public int Num_ACon { get; set; }

        public int Num_ANCon { get; set; }
    }
}
