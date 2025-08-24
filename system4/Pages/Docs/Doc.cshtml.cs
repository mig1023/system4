using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace system4.Pages.Docs
{
    [Authorize]
    public class DocModel : PageModel
    {
        public DAL.DocPack DocPack { get; set; }

        public void OnGet(int docid)
        {
            DocPack = DAL.DocPack.Get(docid);
        }
    }
}
