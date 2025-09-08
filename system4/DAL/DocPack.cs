using system4.DB;

namespace system4.DAL
{
    public class DocPack : DB.DocPack
    {
        public Branches Center { get; set; }

        public VisaTypes Visa { get; set; }

        public List<DocApplicant> Applicants { get; set; }

        public Appointment Appointment { get; set; }

        public List<DocComments> Comments { get; set; }

        public DocPackOptional DocPackOptional { get; set; }

        public PriceRate PriceRate { get; set; }

        public List<PriceList> PriceList { get; set; }


        private static DocPack Converter(DB.DocPack dbDoc)
        {
            var doc = new DocPack();

            foreach (var prop in dbDoc.GetType().GetProperties())
            {
                doc.GetType().GetProperty(prop.Name).SetValue(doc, prop.GetValue(dbDoc, null), null);
            }

            return doc;
        }

        public static DocPack Get(int docid)
        {
            var doc = Converter(DB.Entity.Get.Doc(docid));

            doc.Center = DB.Entity.Get.Branches(doc.CenterId);
            doc.Visa = DB.Entity.Get.VisaTypes(doc.VisaType);
            doc.Appointment = Appointment.Get(doc.AppId);
            doc.Comments = DB.Entity.Get.DocComments(docid);
            doc.PriceRate = DB.Entity.Get.PriceRate(doc.RateId);
            doc.PriceList = DB.Entity.Get.PriceList(doc.RateId, doc.VisaType);
            doc.DocPackOptional = DB.Entity.Get.DocPackOptional(docid);

            doc.Applicants = new List<DocApplicant>();

            foreach (var docInfo in DB.Entity.Get.DocInfo(docid))
            {
                foreach (var docList in DB.Entity.Get.DocList(docInfo.Id))
                {
                    var appData = doc.Appointment.AppData
                        .SingleOrDefault(x => x.Id == docList.ApplId);

                    doc.Applicants.Add(DAL.DocApplicant.Converter(doc, docInfo, docList, appData));
                }
            }

            return doc;
        }

        public static List<DocPack> List(string search, int? page,
            out int pageCount, bool juridical = false)
        {
            List<int> docIds = new List<int>();
            int count = 0;

            if (DateTime.TryParse(search, out DateTime date))
            {
                docIds = DB.Entity.Get
                    .DocsByDate(date, page ?? 1, Constants.PageSize, juridical, out count);
            }
            else if (Formats.OnlyNumeric(search).Length == 14)
            {
                var id = DB.Entity.Get.DocByNum(search);

                if (id > 0)
                {
                    docIds.Add(id);
                    count = 1;
                }
            }
            else if (Formats.OnlyNumeric(search).Length == 12)
            {
                var id = DB.Entity.Get.DocByBankId(Formats.OnlyNumeric(search));

                if (id > 0)
                {
                    docIds.Add(id);
                    count = 1;
                }
            }
            else if (search.Length == 9)
            {
                docIds = DB.Entity.Get
                    .DocsByPassnum(search, page ?? 1, Constants.PageSize, juridical, out count);
            }

            var docs = docIds
                .Select(x => Get(x))
                .ToList();

            pageCount = (int)Math.Ceiling((double)count / Constants.PageSize);

            return docs;
        }
    }
}
