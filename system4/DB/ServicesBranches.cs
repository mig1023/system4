using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class ServicesBranches
    {
        [Key]
        public int Id { get; set; }

        public int ServiceId { get; set; }

        public int BranchId { get; set; }
    }
}
