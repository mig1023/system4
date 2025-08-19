using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using system4.DB;

namespace system4.Pages.Docs
{
    [Authorize]
    public class AppModel : PageModel
    {
        public Data.Appointment Appointment { get; set; }

        public void OnGet(int appid)
        {
            Appointment = Data.Appointment.Get(appid);
        }
    }
}
