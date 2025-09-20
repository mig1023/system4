using system4.DB;

namespace system4.BLL.Timeslots
{
    public class Timeslot
    {
        public int Id { get; set; }

        public int TStart { get; set; }

        public int TEnd { get; set; }

        public int Visas { get; set; }

        public int Applicants {  get; set; }

        public int Percentage { get; set; }

        public Timeslot(TimeData timedata)
        {
            Id = timedata.SlotId;
            TStart = timedata.TStart;
            TEnd = timedata.TEnd;
            Visas = timedata.Visas;
            Applicants = 0;
        }
    }
}
