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

        public bool Companies { get; set; }

        public string LinkType { get; set; }

        public void OnGet(string type, int? pageNum)
        {
            var search = HttpContext.Session.GetString($"{type}docSearch");

            if (String.IsNullOrEmpty(search))
            {
                search = DateTime.Now.ToString();
            }
            else
            {
                Search = search;
            }

            LinkType = type;
            Companies = type == "companies";
            DocPack = DAL.DocPack.List(search, pageNum, out int pages, juridical: Companies);
            Pages = pages;
            Current = pageNum ?? 1;
        }

        public IActionResult OnPost(string type)
        {
            if (Request.Form.Keys.Contains("doSearch"))
            {
                HttpContext.Session.SetString($"{type}docSearch", Search);
            }
            else if (Request.Form.Keys.Contains("doClean"))
            {
                HttpContext.Session.Remove($"{type}docSearch");
            }

            return Redirect($"/docs/{type}/");
        }
    }
}
