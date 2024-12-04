using domain.UseCase;
using Microsoft.AspNetCore.Mvc;
using Presence.Api.Request;
using Presence.Api.Response;
using domain.Request;
using System.Linq.Expressions;

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

        [HttpPost(template:"subjectDay")]
        public ActionResult<SubjectDayResponse> AddSubjectDay(SubjectDayRequest subjectDay)
        {
            _subjectDay.addSubjectDay(new AddSubjectDayRequest { Date = subjectDay.Date, Order = subjectDay.Order, SubjectId = subjectDay.SubjectId });
            return Ok();
        }
        [HttpDelete(template: "{Id}")]
        public ActionResult<SubjectDayResponse> RemoveSubjectDay(int Id)
        {
            _subjectDay.removeSubjectDay(Id);
            return Ok();
        }
        [HttpGet(template: "getSchedule")]
        public ActionResult<SubjectDayResponse> getSchedule()
        {
            var result = _subjectDay.getSubjectDays()
                .Select(s => new SubjectDayResponse 
                { 
                    Id = s.Id, 
                    Date = s.Date, 
                    Order = s.Order, 
                    Subject = new SubjectResponse { Id = s.Subject.Id, SubjectName = s.Subject.Name } 
                });
            return Ok(result);
        }
        [HttpPut(template:"{Id}")]
        public ActionResult<SubjectDayResponse> UpdateSchedule(int Id, SubjectDayRequest subjectDay)
        {
            _subjectDay.updateSubjectDay(Id, new UpdateSubjectDayRequest { Date = subjectDay.Date, Order = subjectDay.Order, SubjectId = subjectDay.SubjectId });
            return Ok();
        }
    }
}
