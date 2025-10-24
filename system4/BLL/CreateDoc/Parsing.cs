using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace system4.BLL.CreateDoc
{
    public class Parsing
    {
        public static List<DAL.Services> Services(HttpRequest request, DAL.Appointment appointment,
            DocForm docForm, ModelStateDictionary modelState)
        {
            var form = request.Form;
            var allServices = DAL.Services.ServicesByCenter(appointment.CenterId, appointment.Center);
            var services = new List<DAL.Services>();
            var servicesIndex = 0;

            foreach (DAL.Services service in allServices)
            {
                if (docForm.Services[servicesIndex].Enabled)
                {
                    var value = docForm.Services[servicesIndex].Value ?? 0;

                    if (value > 0)
                    {
                        service.Value = value;
                        services.Add(service);
                    }
                    else
                    {
                        modelState.AddModelError($"DocPack.Services[{servicesIndex}]", "← Значение услуги не задано");
                    }
                }

                servicesIndex += 1;
            }

            return services;
        }
    }
}
