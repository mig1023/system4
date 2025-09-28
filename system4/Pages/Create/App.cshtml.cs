using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace system4.Pages.Create
{
    [Authorize]
    public class AppModel : PageModel
    {
        public Dictionary<int, string> Centers { get; set; }

        public List<BLL.Timeslots.Availability> AvailabilityDates { get; set; }

        [BindProperty]
        public BLL.CreateApp.AppointmentForm Appointment { get; set; }

        public void OnGet()
        {
            Centers = DB.Entity.Get.Branches()
                .ToDictionary(x => x.Id, x => x.BName);
        }

        public IActionResult OnPost()
        {
            var id = BLL.CreateApp.Creation.Save(Appointment, User.Identity.Name);
            return Redirect($"/app/{id}/");
        }
    }
}
