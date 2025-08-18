using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            if (DB.Entity.Services.VerifyPassword(Users.Login, Users.Pass))
            {
                DB.Entity.Session.SetCookies(Users.Login, PageContext.HttpContext);

                var user = DB.Entity.Get.User(Users.Login);

                HttpContext.Session.SetString("fullUserName",
                    $"{user.UserName} {user.UserSName} {user.UserLName}");

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
