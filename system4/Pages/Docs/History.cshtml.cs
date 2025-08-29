using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace system4.Pages.Docs
{
    public class HistoryModel : PageModel
    {
        [BindProperty]
        public string Search { get; set; }

        public List<DAL.DocHistory> History { get; set; }

        public void OnGet(string? searchNum)
        {   
            if (!string.IsNullOrEmpty(searchNum))
            {
                History = DAL.DocHistory.List(searchNum);
            }
            else
            {
                History = new List<DAL.DocHistory>();
            }
        }

        public IActionResult OnPost()
        {
            return Redirect($"/history/{Search}");
        }
    }
}
