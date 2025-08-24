namespace system4.DAL
{
    public class DocPackList : DB.DocPackList
    {
        public AppData AppData { get; set; }

        public static DocPackList Converter(DB.DocPackList dbInfo)
        {
            var doc = new DocPackList();

            foreach (var prop in dbInfo.GetType().GetProperties())
            {
                doc.GetType().GetProperty(prop.Name).SetValue(doc, prop.GetValue(dbInfo, null), null);
            }

            return doc;
        }
    }
}
