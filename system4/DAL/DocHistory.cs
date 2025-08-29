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
            DB.DocPack doc = DB.Entity.Get.Doc(search);

            List<DocHistory> history = DB.Entity.Get.DocHistory(doc.Id)
                .Select(x => Converter(x))
                .ToList();

            return history;
        }
    }
}
