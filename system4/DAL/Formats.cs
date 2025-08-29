using System.Text.RegularExpressions;

namespace system4.DAL
{
    public class Formats
    {
        public static string Appointment(string appointment)
        {
            var appNum = Regex
                .Match(appointment, @"(\d\d\d)(\d\d\d\d)(\d\d)(\d\d)(\d\d\d\d)")
                .Groups
                .Cast<Group>()
                .ToList();

            appNum.RemoveAt(0);
            
            return string.Join("/", appNum);
        }

        public static string Agreement(string agreement)
        {
            var agreementNo = Regex
                .Match(agreement, @"(\d\d)(\d\d\d\d\d\d)(\d\d\d\d)")
                .Groups
                .Cast<Group>()
                .ToList();

            agreementNo.RemoveAt(0);

            return string.Join(".", agreementNo);
        }
    }
}
