using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace system4.Pages.Docs
{
    [Authorize]
    public class DocsModel : PageModel
    {
        public List<DAL.DocPack> DocPack { get; set; }

        public void OnGet()
        {
            DocPack = DAL.DocPack.List(DateTime.Now.ToString());
        }
    }
}
