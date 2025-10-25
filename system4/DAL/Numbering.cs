using static system4.DB.Entity.Contextcs;

namespace system4.DAL
{
    public class Numbering
    {
        public static string Appointment(DateTime date, int centerId)
        {
            using (var db = new EntityContext())
            {
                var apps = db.Appointments
                    .Where(x => x.AppDate == date.Date && x.CenterId == centerId)
                    .Max(x => x.AppNum);

                var newAppointment = string.Empty;
                var center = string.Format("{0:d3}", centerId);
                var currentDate = date.ToString("yyyyMMdd");

                if (apps == null)
                {
                    return $"{center}{currentDate}0001";
                }
                else
                {
                    var line = apps.Substring(apps.Length - 4);
                    var number = int.Parse(line);
                    number += 1;

                    return $"{center}{currentDate}{number}";
                }
            }
        }

        public static string DocPack(DateTime date, int centerId)
        {
            using (var db = new EntityContext())
            {
                var docs = db.DocPack
                    .Where(x => x.PDate == date.Date && x.CenterId == centerId)
                    .Max(x => x.AgreementNo);

                var newAgreement = string.Empty;
                var center = string.Format("{0:d2}", centerId);
                var currentDate = date.ToString("MMddyy");

                if (docs == null)
                {
                    return $"{center}000001{currentDate}";
                }
                else
                {
                    var line = docs.Substring(2, 6);
                    var number = int.Parse(line);
                    number += 1;

                    return $"{center}{number:d6}{currentDate}";
                }
            }
        }

        public static string BankId(string template)
        {
            template = template.Remove(template.IndexOf('|'));

            var searchTemplate = DateTime.Now.Year + template.Replace("x", string.Empty);

            using (var db = new EntityContext())
            {
                var lastBankId = db.DocPackList
                    .Where(x => x.CBankId.StartsWith(searchTemplate))
                    .Max(x => x.CBankId);

                if (lastBankId == null)
                {
                    lastBankId = template.Replace("x", "0");
                }
                
                var newBankId = ulong.Parse(lastBankId);

                return (newBankId + 1).ToString();
            }
        }
    }
}
