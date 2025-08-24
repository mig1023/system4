namespace system4.DAL
{
    public class DocPackInfo : DB.DocPackInfo
    {
        public List<DocPackList> DocPackList { get; set; }

        public static DocPackInfo Converter(DB.DocPackInfo dbInfo)
        {
            var doc = new DocPackInfo();

            foreach (var prop in dbInfo.GetType().GetProperties())
            {
                doc.GetType().GetProperty(prop.Name).SetValue(doc, prop.GetValue(dbInfo, null), null);
            }

            return doc;
        }
    }
}
