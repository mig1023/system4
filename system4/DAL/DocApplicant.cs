namespace system4.DAL
{
    public class DocApplicant : DB.DocPackList
    {
        public DocPack DocPack { get; set; }

        public DB.DocPackInfo DocPackInfo { get; set; }

        public DB.AppData AppData { get; set; }

        public static DocApplicant Converter(DAL.DocPack docPack,
            DB.DocPackInfo dbInfo, DB.DocPackList dbList, DB.AppData dbAppData)
        {
            var doc = new DocApplicant();

            foreach (var prop in dbList.GetType().GetProperties())
            {
                doc.GetType().GetProperty(prop.Name).SetValue(doc, prop.GetValue(dbList, null), null);
            }

            doc.DocPackInfo = dbInfo;
            doc.AppData = dbAppData;
            doc.DocPack = docPack;

            return doc;
        }
    }
}
