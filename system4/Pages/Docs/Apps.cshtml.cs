using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace system4.Pages.Docs
{
    [Authorize]
    public class AppsModel : PageModel
    {
        public List<DAL.Appointment> Appointments { get; set; }

        public int Pages { get; set; }

        public void OnGet(int? pageNum)
        {       
            Appointments = DAL.Appointment.List(DateTime.Now.ToString(), pageNum, out int pages);
            Pages = pages;
        }
    }
}
