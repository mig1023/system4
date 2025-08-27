using System.ComponentModel.DataAnnotations;

namespace system4.DB
{
    public class TimeData
    {
        [Key]
        public int SlotId { get; set; }

        public int TimeId { get; set; }

        public int TStart { get; set; }

        public int TEnd { get; set; }

        public int Visas { get; set; }

        public int EVisas { get; set; }

        public int isDeleted { get; set; }

        public int DayNum { get; set; }
    }
}
