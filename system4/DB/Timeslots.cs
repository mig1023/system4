using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class Timeslots
    {
        [Key]
        public int Id { get; set; }

        public DateTime TDate { get; set; }

        public int BranchID { get; set; }

        public int IsDeleted { get; set; }

        public int? Agency { get; set; }
    }
}
