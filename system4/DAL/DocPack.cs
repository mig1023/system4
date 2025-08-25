using System.Text.RegularExpressions;
using system4.DB;

namespace system4.DAL
{
    public class DocPack : DB.DocPack
    {
        public Branches Center { get; set; }

        public VisaTypes VisaTypeLine { get; set; }

        public string StatusLine { get; set; }

        public List<DocPackInfo> DocPackInfo { get; set; }

        public Appointment Appointment { get; set; }

        public List<DocComments> Comments { get; set; }

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

            doc.Center = DB.Entity.Get.Branches(doc.CenterId);
            doc.VisaTypeLine = DB.Entity.Get.VisaTypes(doc.VisaType);
            doc.StatusLine = Constants.DocStatuses(doc.PStatus);
            doc.Appointment = Appointment.Get(doc.AppId);
            doc.Comments = DB.Entity.Get.DocComments(docid);

            doc.DocPackInfo = DB.Entity.Get.DocInfo(docid)
                .Select(x => DAL.DocPackInfo.Converter(x))
                .ToList();

            foreach (var docPackInfo in doc.DocPackInfo)
            {
                docPackInfo.DocPackList = DB.Entity.Get.DocList(docPackInfo.Id)
                    .Select(x => DAL.DocPackList.Converter(x))
                    .ToList();

                foreach (var docPackList in docPackInfo.DocPackList)
                {
                    docPackList.AppData = doc.Appointment.AppData
                        .SingleOrDefault(x => x.Id == docPackList.ApplId);
                }
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
