using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace system4.Pages.Docs
{
    [Authorize]
    public class DocsModel : PageModel
    {
        [BindProperty]
        public string Search { get; set; }

        public List<DAL.DocPack> DocPack { get; set; }

        public int Pages { get; set; }

        public int Current { get; set; }

        public void OnGet(int? pageNum)
        {
            var search = HttpContext.Session.GetString("docSearch");

            if (String.IsNullOrEmpty(search))
            {
                search = DateTime.Now.ToString();
            }
            else
            {
                Search = search;
            }

            DocPack = DAL.DocPack.List(search, pageNum, out int pages);
            Pages = pages;
            Current = pageNum ?? 1;
        }

        public IActionResult OnPost()
        {
            if (Request.Form.Keys.Contains("doSearch"))
            {
                HttpContext.Session.SetString("docSearch", Search);
            }
            else if (Request.Form.Keys.Contains("doClean"))
            {
                HttpContext.Session.Remove("docSearch");
            }

            return RedirectToPage();
        }
    }
}
