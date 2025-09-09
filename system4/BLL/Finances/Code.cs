namespace system4.BLL.Finances
{
    public class Code
    {
        public static string Service(DAL.DocPack doc, string service)
        {
            if (service == "visa")
            {
                var urgace = doc.Urgent > 0 ? "1" : "0";
                var payType = "1";
                var agent = "1";

                return "(ITA" + Constants.CentersCode(doc.CenterId) + payType + urgace + agent + ") ";
            }
            else
            {
                return "(ITA" + Constants.CentersCode(doc.CenterId) + Constants.ServicesCode(service) + ") ";
            }
        }
    }
}
