using domain.UseCase;
using Microsoft.AspNetCore.Mvc;
using Presence.Api.Response;

namespace Presence.Api.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController: ControllerBase
    {
        private readonly IGroupUseCase _groupService;
        public GroupController(IGroupUseCase groupService)
        {
            _groupService = groupService;
        }

        [HttpGet("/group")]
        public ActionResult<GroupResponse> GetAllGroup()
        {
            var result = _groupService.GetGroupsWithStudents().Select(group => new GroupResponse
            { Id = group.Id, Name = group.Name, Users = group.users.Select(user => new UserResponse
            { Name = user.Name, Guid = user.Guid }).ToList() }).ToList();
            return Ok(result);
        }
        [HttpPost("/group/{name}")]
        public ActionResult<GroupResponse> AddGroup(GroupResponse group)
        {
        }
    }
}
