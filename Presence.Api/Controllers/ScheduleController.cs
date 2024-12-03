using domain.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace Presence.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly ISDUseCase _subjectDay;
        public ScheduleController(ISDUseCase subjectDay)
        {
            _subjectDay = subjectDay;
        }

        [HttpPost]
        public class ActionResult
    }
}
