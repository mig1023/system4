using Microsoft.AspNetCore.Mvc.RazorPages;

namespace system4.Pages.Create
{
    public class DocModel : PageModel
    {
        public DAL.Appointment Appointment { get; set; }

        public Dictionary<int, string> VisaTypes { get; set; }

        public void OnGet(int appid)
        {
            Appointment = DAL.Appointment.Get(appid);

            VisaTypes = DB.Entity.Get.VisaTypesByCenter(Appointment.CenterId)
                .ToDictionary(x => x.Id, x => x.VName);
        }
    }
}
