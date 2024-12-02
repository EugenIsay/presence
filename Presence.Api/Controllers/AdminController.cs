using domain.UseCase;
using Microsoft.AspNetCore.Mvc;
using Presence.Api.Response;
using domain.Request;
using Presence.Api.Request;

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

        [HttpPost(template: "User/{name}")]
        public ActionResult<UserResponse> AddUser(UserRequest user)
        {
            _userService.AddUser(new AddUserRequest { Name = user.Name });
            return Ok();
        }
        [HttpDelete(template: "User/{guid}")]
        public ActionResult<UserResponse> RemoveUser(Guid guid)
        {
            _userService.RemoveUser(new RemoveUserRequest { guid = guid });
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
