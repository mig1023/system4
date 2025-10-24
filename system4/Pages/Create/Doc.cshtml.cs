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

        public Dictionary<int, string> PaymentTypes { get; set; }

        public Dictionary<string, Dictionary<string, string>> RequestData { get; set; }

        [BindProperty]
        public string Requests { get; set; }

        [BindProperty]
        public BLL.CreateDoc.DocForm DocPack { get; set; }

        public List<DAL.Services> Services { get; set; }

        public string Error { get; set; }

        private void InitPageValues(int appid, bool reload = false)
        {
            Appointment = DAL.Appointment.Get(appid);

            Services = DAL.Services.ServicesByCenter(Appointment.CenterId, Appointment.Center);

            VisaTypes = DB.Entity.Get.VisaTypesByCenter(Appointment.CenterId)
                .ToDictionary(x => x.Id, x => x.VName);

            RequestData = DAL.Constants.Requests();
            PaymentTypes = DAL.Constants.PaymentTypes();

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
            var appointment = DAL.Appointment.Get(appid);
            var services = BLL.CreateDoc.Parsing.Services(Request, appointment, DocPack, ModelState);

            if (!ModelState.IsValid)
            {
                InitPageValues(appid, reload: true);
                return Page();
            }

            var id = BLL.CreateDoc.Creation.Save(appointment, DocPack, services, Requests, User.Identity.Name);

            if (id == 0)
            {
                ModelState.AddModelError("Error", "Ошибка создания договора");
                InitPageValues(appid, reload: true);
                return Page();
            }

            return Redirect($"/doc/{id}/");
        }
    }
}
