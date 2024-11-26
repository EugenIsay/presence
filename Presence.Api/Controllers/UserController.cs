using domain.UseCase;
using Microsoft.AspNetCore.Mvc;
using Presence.Api.Response;
using domain.Request;
using Presence.Api.Request;

namespace Presence.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserUseCase _userService;
        public UserController(IUserUseCase userService)
        {
            _userService = userService;
        }

        [HttpGet(template: "users")]
        public ActionResult<UserResponse> GetAllUsers()
        {
            var result = _userService.GetAllUsers()
                .Select(user => new UserResponse { Guid = user.Guid, Name = user.Name,
                    Group = new GroupResponse { Name = user.Group.Name } }).ToList();
            return Ok(result);
        }

        [HttpPut(template: "{name}")]
        public ActionResult<UserResponse> AddUser(UserRequest user)
        {
            _userService.AddUser(new AddUserRequest { Name = user.Name });
            return Ok();
        }
        [HttpDelete(template: "{guid}")]
        public ActionResult<UserResponse> RemoveUser(Guid guid)
        {
            _userService.RemoveUser(new RemoveUserRequest { guid = guid });
            return Ok();
        }
    }
}
