using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace system4.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            DB.Session.SetCookiesOut(PageContext.HttpContext);
            return RedirectToPage("Login");
        }
    }
}
