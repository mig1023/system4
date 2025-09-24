using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace system4.API
{
    [Authorize]
    [ApiController]
    public class Apps : ControllerBase
    {
        [HttpGet("api/visatypes/{centerId}")]
        public ActionResult<List<DB.VisaTypes>> VisaTypes(int centerId)
        {
            return DB.Entity.Get.VisaTypesByCenter(centerId);
        }
    }
}
