using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace system4.Pages.Create
{
    [Authorize]
    public class AppModel : PageModel
    {
        public Dictionary<int, string> Centers { get; set; }

        [BindProperty]
        public BLL.CreateApp.AppointmentForm FormModel { get; set; }

        public void OnGet()
        {
            Centers = DB.Entity.Get.Branches()
                .ToDictionary(x => x.Id, x => x.BName);
        }

        public void OnPost()
        {

        }
    }
}
