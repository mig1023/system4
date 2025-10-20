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

        public Dictionary<string, Dictionary<string, string>> RequestData { get; set; }

        [BindProperty]
        public BLL.CreateDoc.DocForm DocPack { get; set; }

        public List<DAL.Services> Services { get; set; }

        private void InitPageValues(int appid, bool reload = false)
        {
            Appointment = DAL.Appointment.Get(appid);

            Services = DAL.Services.ServicesByCenter(Appointment.CenterId, Appointment.Center);

            VisaTypes = DB.Entity.Get.VisaTypesByCenter(Appointment.CenterId)
                .ToDictionary(x => x.Id, x => x.VName);

            RequestData = DAL.Constants.Requests();

            if (!reload)
            {
                DocPack = new BLL.CreateDoc.DocForm(Appointment, Services);
            }
        }

        public void OnGet(int appid)
        {
            InitPageValues(appid);
        }

        public IActionResult OnPost(int appid)
        {
            var form = Request.Form;
            var appointment = DAL.Appointment.Get(appid);
            var allServices = DAL.Services.ServicesByCenter(appointment.CenterId, appointment.Center);
            var services = new List<DAL.Services>();

            if (form.ContainsKey($"Service_Shipping"))
            {
                var service = DAL.Constants.BanalServices("Shipping");
                var sh = "Service_Shipping_";
                var address = form[sh + "Address"];
                var phone = form[sh + "Phone"];

                service.Shipping = new DAL.Services.ShippingService
                {
                    Address = address,
                    Phone = phone,
                    Comment = form[sh +"Comment"],
                    Overload = form[sh + "Overload"].ToString().StartsWith("true"),
                };

                services.Add(service);
            }

            var servicesIndex = 0;

            foreach (DAL.Services service in allServices)
            {
                if (DocPack.Services[servicesIndex].Enabled)
                {
                    var value = DocPack.Services[servicesIndex].Value ?? 0;

                    if (value > 0)
                    {
                        service.Value = value;
                        services.Add(service);
                    }
                    else
                    {
                        ModelState.AddModelError($"DocPack.Services[{servicesIndex}]", "Значение услуги не задано");
                    }
                }

                servicesIndex += 1;
            }

            if (!ModelState.IsValid)
            {
                InitPageValues(appid, reload: true);
                return Page();
            }

            var request = form["Requests"].ToString();

            var id = BLL.CreateDoc.Creation.Save(DocPack, services, request);
            return Redirect($"/doc/{id}/");
        }
    }
}
