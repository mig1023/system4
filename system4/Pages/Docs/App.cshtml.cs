using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace system4.Pages.Docs
{
    [Authorize]
    public class AppModel : PageModel
    {
        public DAL.Appointment Appointment { get; set; }

        public void OnGet(int appid)
        {
            Appointment = DAL.Appointment.Get(appid);
        }
    }
}
