using domain.UseCase;
using Microsoft.AspNetCore.Mvc;
using Presence.Api.Response;
using domain.Request;
using Presence.Api.Request;
using System.Collections.Generic;

namespace Presence.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IUserUseCase _userService;
        private readonly ISubjectUseCase _subjectService;
        private readonly IGSUseCase _gsService;
        public AdminController(ISubjectUseCase subjectService, IUserUseCase userService, IGSUseCase gsService)
        {
            _subjectService = subjectService;
            _userService = userService;
            _gsService = gsService;
        }

        [HttpGet(template: "users")]
        public ActionResult<UserResponse> GetAllUsers()
        {
            var result = _userService.GetAllUsers()
                .Select(user => new UserResponse { Guid = user.Guid, Name = user.Name,
                    Group = new GroupResponse { Name = user.Group.Name } }).ToList();
            return Ok(result);
        }

        [HttpPost(template: "{group_id}/students")]
        public ActionResult<UserResponse> AddUser(int group_id, List<string> user_guids)
        {
            _userService.ChangeUsersGroup(new ChangeUsersGroupRequest { GroupId = group_id, UsersGuids = user_guids.Select(guid => Guid.Parse(guid)).ToList() });
            return Ok();
        }

        [HttpPost(template: "group/{group_id}/subjects")]
        public ActionResult<SubjectResponse> AddSubject(int group_id, List<SubjectRequest> subjects)
        {
            _gsService.AddGroupSubject(new AddGroupSubjectsRequest { GroupId = group_id, subjects = subjects
                .Select(subject => new SemestrSubject { SubjectId = subject.Id, Semestr = subject.Semestr }).ToList() });
            return Ok();
        }
    }
}
