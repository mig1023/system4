using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using system4.API;
using system4.BLL.Finances;

namespace system4.Pages.Create
{
    [Authorize]
    public class DocModel : PageModel
    {
        public DAL.Appointment Appointment { get; set; }

        public Dictionary<int, string> VisaTypes { get; set; }

        public List<DAL.Services> Services { get; set; }

        [BindProperty]
        public BLL.CreateDoc.DocForm DocPack { get; set; }

        public void OnGet(int appid)
        {
            Appointment = DAL.Appointment.Get(appid);

            VisaTypes = DB.Entity.Get.VisaTypesByCenter(Appointment.CenterId)
                .ToDictionary(x => x.Id, x => x.VName);

            Services = DAL.Services.ServicesByCenter(Appointment.CenterId, Appointment.Center);
        }

        public IActionResult OnPost(int appid)
        {
            var appointment = DAL.Appointment.Get(appid);
            var allServices = DAL.Services.ServicesByCenter(appointment.CenterId, appointment.Center);
            var form = Request.Form;
            var services = new List<DAL.Services>();

            if (form.ContainsKey($"Service_Shipping"))
            {
                var service = DAL.Constants.BanalServices("Shipping");

                service.Shipping = new DAL.Services.ShippingService
                {
                    Address = form["Service_Shipping_Address"],
                    Phone = form["Service_Shipping_Phone"],
                    Comment = form["Service_Shipping_Comment"],
                    Overload = form["Service_Shipping_Overload"].ToString().StartsWith("true"),
                };

                services.Add(service);
            }

            foreach (DAL.Services service in allServices)
            {
                var serviceId = service.ServiceId > 0 ? service.ServiceId.ToString() : service.ServiceName;

                if (form.ContainsKey($"Service_{serviceId}"))
                {
                    var valued = int.TryParse(form[$"Service_{serviceId}_Value"], out int value);

                    if (!valued)
                        continue;

                    service.Value = value;
                    services.Add(service);
                }
            }


            return null;
        }
    }
}
