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

        [BindProperty]
        public BLL.CreateDoc.DocForm DocPack { get; set; }

        public void OnGet(int appid)
        {
            Appointment = DAL.Appointment.Get(appid);

            VisaTypes = DB.Entity.Get.VisaTypesByCenter(Appointment.CenterId)
                .ToDictionary(x => x.Id, x => x.VName);
        }

        public IActionResult OnPost()
        {
            return null;
        }
    }
}
