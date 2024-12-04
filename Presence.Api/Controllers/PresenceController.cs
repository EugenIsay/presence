using domain.Entity;
using domain.UseCase;
using Microsoft.AspNetCore.Mvc;
using Presence.Api.Request;
using Presence.Api.Response;
using domain.Request;

namespace Presence.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PresenceController: ControllerBase
    {
        private readonly IPresenceUseCase _presenceService;
        public PresenceController(IPresenceUseCase presenceService)
        {
            _presenceService = presenceService;
        }

        [HttpGet(template: "getPrecense")]
        public ActionResult<PresenceResponse> GetPrecense()
        {
            var result = _presenceService.GetAllPresences().Select(presence => new PresenceResponse
            {
                User = new UserResponse
                {
                    Guid = presence.User.Guid,
                    Name = presence.User.Name,
                    Group = new GroupResponse
                    {
                        Id = presence.User.Group.Id,
                        Name = presence.User.Group.Name
                    }
                },
                Status = new StatusResponse
                {
                    Id = presence.Status.Id,
                    Name = presence.Status.Name,
                },
                SubjectDay = new SubjectDayResponse
                {
                    Id = presence.SubjectDay.Id,
                    Date = presence.SubjectDay.Date,
                    Order = presence.SubjectDay.Order,
                    Subject = new SubjectResponse
                    {
                        Id = presence.SubjectDay.Subject.Id,
                        SubjectName = presence.SubjectDay.Subject.Name,
                        groupSubjects = presence.SubjectDay.Subject.GroupsSubject.Select(subject => new GroupSubjectResponse
                        {
                            Semestr = subject.Semester,
                            Group = new GroupResponse()
                            {
                                Id = subject.Group.Id,
                                Name = subject.Group.Name
                            }
                        }).ToList(),
                    }
                }
            }).ToList();

            return Ok(result);
        }

        [HttpPost(template: "presence")]
        public ActionResult<PresenceResponse> AddPresence(PresenceRequest presence)
        {
            _presenceService.AddPresence(new AddPresenceRequest {
                StatusId = presence.StatusId,
                SubjectDayId = presence.SubjectDayId,
                UserGuid = presence.UserGuid
            });
            return Ok();
        }
        [HttpDelete(template:"allPresence")]
        public ActionResult<PresenceResponse> RemoveAllPresence() 
        {
            _presenceService.RemoveAllPresence();
            return Ok();
        }
        [HttpDelete(template: "{group_id}")]
        public ActionResult<PresenceResponse> RemovePresenceByGroupId(int group_id)
        {
            _presenceService.RemovePresenceByGroup(group_id);
            return Ok();
        }
        [HttpPut(template: "presence/{status_id}")]
        public ActionResult<PresenceResponse> UpdatePresenceStatus(int status_id, UpdateStatusRequest presence)
        {
            _presenceService.UpdatePresence(status_id, new UpdatePresenceRequest { SubjectDayId = presence.SubjectDay, UserGuid = Guid.Parse(presence.UserGuid) });
            return Ok();
        }

    }
}
