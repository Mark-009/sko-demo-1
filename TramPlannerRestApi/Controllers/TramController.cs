using Microsoft.AspNetCore.Mvc;
using TramPlannerLib.Responses;
using TramPlannerLib.Services;

namespace TramPlannerRestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TramController : ControllerBase
    {
        private readonly TramContainer _tramContainer;

        public TramController(TramContainer tramContainer)
        {
            _tramContainer = tramContainer;
        }

        [HttpGet("plan-mission")]
        public async Task<ActionResult<PlanResponse>> PlanMission()
        {
            var response = await _tramContainer.PlanMissionForTram();
            return Ok(response);
        }

        [HttpGet("get-trams")]
        public ActionResult<TramsListResponse> GetTrams()
        {
            return Ok(new TramsListResponse { Trams = _tramContainer.GetTrams() });
        }
    }
}
