using Newtonsoft.Json;

namespace system4.BLL.CreateDoc
{
    public class Creation
    {
        private static void FillAllNullableProperties(object app)
        {
            foreach (var property in app.GetType().GetProperties())
            {
                if (property.GetValue(app) != null)
                {
                    continue;
                }
                else if (Nullable.GetUnderlyingType(property.PropertyType) != null)
                {
                    continue;
                }
                else if (property.PropertyType == typeof(string))
                {
                    property.SetValue(app, string.Empty);
                }
                else if (property.PropertyType == typeof(DateTime))
                {
                    property.SetValue(app, DateTime.MinValue);
                }
                else
                {
                    property.SetValue(app, 0);
                }
            }
        }

        public static int Save(DocForm doc, List<DAL.Services> services, string requestsJson)
        {
            var requests = JsonConvert.DeserializeObject(requestsJson);

            return 0;
        }
    }
}
