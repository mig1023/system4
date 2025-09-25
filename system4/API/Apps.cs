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

        [HttpGet("api/availability/{centerId}")]
        public ActionResult<List<BLL.Timeslots.Availability>> Availability(int centerId)
        {
            return BLL.Timeslots.Get.Period(centerId);
        }

        [HttpGet("api/timeslots/{centerId}/{date}")]
        public ActionResult<List<BLL.Timeslots.Timeslot>> Timeslots(int centerId, string date)
        {
            return BLL.Timeslots.Get.Day(centerId, DateTime.Parse(date));
        }
    }
}
