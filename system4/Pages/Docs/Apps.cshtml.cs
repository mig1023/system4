using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using system4.DB;

namespace system4.Pages.Docs
{
    [Authorize]
    public class AppsModel : PageModel
    {
        public List<DB.Appointment> Appointments { get; set; }

        public void OnGet()
        {
            Appointments = DB.Entity.Get.AppsByDate(DateTime.Now);
        }
    }
}
