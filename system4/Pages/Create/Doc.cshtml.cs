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

        [BindProperty]
        public BLL.CreateDoc.DocForm DocPack { get; set; }

        public void OnGet(int appid)
        {
            Appointment = DAL.Appointment.Get(appid);

            VisaTypes = DB.Entity.Get.VisaTypesByCenter(Appointment.CenterId)
                .ToDictionary(x => x.Id, x => x.VName);

            Services = DAL.Services.ServicesByCenter(Appointment.CenterId, Appointment.Center);
        }

        public IActionResult OnPost()
        {
            return null;
        }
    }
}
