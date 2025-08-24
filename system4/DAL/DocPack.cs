using System.Text.RegularExpressions;

namespace system4.DAL
{
    public class DocPack : DB.DocPack
    {
        public List<DocPackInfo> DocPackInfo { get; set; }

        private static DocPack Converter(DB.DocPack dbDoc)
        {
            var doc = new DocPack();

            foreach (var prop in dbDoc.GetType().GetProperties())
            {
                doc.GetType().GetProperty(prop.Name).SetValue(doc, prop.GetValue(dbDoc, null), null);
            }

            var agreementNo = Regex
                .Match(doc.AgreementNo, @"(\d\d)(\d\d\d\d\d\d)(\d\d\d\d)")
                .Groups
                .Cast<Group>()
                .ToList();

            agreementNo.RemoveAt(0);
            doc.AgreementNo = string.Join(".", agreementNo);

            return doc;
        }

        public static DocPack Get(int docid)
        {
            var doc = Converter(DB.Entity.Get.Doc(docid));

            doc.DocPackInfo = DB.Entity.Get.DocInfo(docid)
                .Select(x => DAL.DocPackInfo.Converter(x))
                .ToList();

            foreach (var docPackInfo in doc.DocPackInfo)
            {
                docPackInfo.DocPackList = DB.Entity.Get.DocList(docPackInfo.Id)
                    .Select(x => DAL.DocPackList.Converter(x))
                    .ToList();
            }

            return doc;
        }

        public static List<DocPack> List(string search)
        {
            var apps = DB.Entity.Get.DocsByDate(DateTime.Parse(search))
                .Select(x => Converter(x))
                .ToList();

            return apps;
        }
    }
}
