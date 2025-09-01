using Microsoft.AspNetCore.Mvc.RazorPages;
using system4.DB;

namespace system4.DAL
{
    public class DocHistory : DB.DocHistory
    {
        public string AgreementNo { get; set; }

        public static DocHistory Converter(DB.DocHistory dbHistory)
        {
            var history = new DocHistory();

            foreach (var prop in dbHistory.GetType().GetProperties())
            {
                history.GetType().GetProperty(prop.Name).SetValue(history, prop.GetValue(dbHistory, null), null);
            }

            var docPack = DB.Entity.Get.Doc(history.DocId);
            history.AgreementNo = docPack.AgreementNo;

            return history;
        }

        public static List<DocHistory> List(string search)
        {
            List<DB.DocHistory> docIds = new List<DB.DocHistory>();

            if (Formats.OnlyNumeric(search).Length == 14)
            {
                DB.DocPack doc = DB.Entity.Get.Doc(search);
                docIds = DB.Entity.Get.DocHistory(doc.Id);
            }
            else if (search.Length == 9)
            {
                docIds = DB.Entity.Get.DocHistoryByPassnum(search);
            }

            List<DocHistory> history = docIds
                .Select(x => Converter(x))
                .ToList();

            return history;
        }
    }
}
