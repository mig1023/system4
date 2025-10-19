using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace system4.Pages.Create
{
    [Authorize]
    public class DocModel : PageModel
    {
        public DAL.Appointment Appointment { get; set; }

        public Dictionary<int, string> VisaTypes { get; set; }

        public List<DAL.Services> Services { get; set; }

        public Dictionary<string, Dictionary<string, string>> RequestData { get; set; }

        [BindProperty]
        public BLL.CreateDoc.DocForm DocPack { get; set; }

        private void InitPageValues(int appid)
        {
            Appointment = DAL.Appointment.Get(appid);

            DocPack = new BLL.CreateDoc.DocForm(Appointment);

            VisaTypes = DB.Entity.Get.VisaTypesByCenter(Appointment.CenterId)
                .ToDictionary(x => x.Id, x => x.VName);

            Services = DAL.Services.ServicesByCenter(Appointment.CenterId, Appointment.Center);

            RequestData = DAL.Constants.Requests();
        }

        public void OnGet(int appid)
        {
            InitPageValues(appid);
        }

        public IActionResult OnPost(int appid)
        {
            var form = Request.Form;

            if (!ModelState.IsValid)
            {
                InitPageValues(appid);
                return Page();
            }

            var appointment = DAL.Appointment.Get(appid);
            var allServices = DAL.Services.ServicesByCenter(appointment.CenterId, appointment.Center);
            var services = new List<DAL.Services>();

            if (form.ContainsKey($"Service_Shipping"))
            {
                var service = DAL.Constants.BanalServices("Shipping");
                var sh = "Service_Shipping_";

                service.Shipping = new DAL.Services.ShippingService
                {
                    Address = form[sh + "Address"],
                    Phone = form[sh + "Phone"],
                    Comment = form[sh +"Comment"],
                    Overload = form[sh + "Overload"].ToString().StartsWith("true"),
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
                    {
                        continue;
                    }

                    service.Value = value;
                    services.Add(service);
                }
            }

            var request = form["Requests"].ToString();

            var id = BLL.CreateDoc.Creation.Save(DocPack, services, request);
            return Redirect($"/doc/{id}/");
        }
    }
}
