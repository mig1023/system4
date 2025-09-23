namespace system4.BLL.Timeslots
{
    public class Availability
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public Dictionary<DateTime, string> Dates { get; set; }
    }
}
