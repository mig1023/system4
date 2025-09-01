using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace system4.Pages.Docs
{
    [Authorize]
    public class HistoryModel : PageModel
    {
        [BindProperty]
        public string Search { get; set; }

        public List<DAL.DocHistory> History { get; set; }

        public void OnGet()
        {   
            var search = HttpContext.Session.GetString("historySearch");

            if (String.IsNullOrEmpty(search))
            {
                History = new List<DAL.DocHistory>();
            }
            else
            {
                History = DAL.DocHistory.List(search);
                Search = search;
            }
        }

        public IActionResult OnPost()
        {
            if (Request.Form.Keys.Contains("doSearch"))
            {
                HttpContext.Session.SetString("historySearch", Search);
            }
            else if (Request.Form.Keys.Contains("doClean"))
            {
                HttpContext.Session.Remove("historySearch");
            }

            return RedirectToPage();
        }
    }
}
