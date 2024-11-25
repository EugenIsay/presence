using domain.UseCase;
using Microsoft.AspNetCore.Mvc;
using Presence.Api.Response;

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

        [HttpGet(template:"users")]
        public ActionResult<UserResponse> GetAllUsers() 
        { 

            return Ok(new List<UserResponse>());
        }
    }
}
