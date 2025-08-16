using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using system4.DB;

namespace system4.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public DB.User Users { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (EntityServices.VerifyPassword(Users.Login, Users.Pass))
            {
                DB.Session.SetCookies(Users.Login, PageContext.HttpContext);
                return RedirectToPage("Index");
            }
            else
            {
                ModelState.AddModelError("Users.Login", "Login or Password is wrong");
                return Page();
            }
        }
    }
}
