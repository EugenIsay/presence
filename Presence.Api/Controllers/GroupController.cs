﻿using domain.UseCase;
using Microsoft.AspNetCore.Mvc;
using Presence.Api.Response;
using domain.Request;
using Presence.Api.Request;
using domain.Entity;

namespace Presence.Api.Controllers
{
    [ApiController]
    [Route("api/group")]
    public class GroupController: ControllerBase
    {
        private readonly IGroupUseCase _groupService;
        public GroupController(IGroupUseCase groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public ActionResult<GroupResponse> GetAllGroup()
        {
            var result = _groupService.GetGroupsWithStudents().Select(group => new GroupResponse
            { Id = group.Id, Name = group.Name, Users = group.users?.Select(user => new UserResponse
            { Name = user.Name, Guid = user.Guid }).ToList() }).ToList();
            return Ok(result);
        }

        [HttpGet(template: "{Id}")]
        public ActionResult<GroupResponse> GetAllGroup(int Id)
        {
            GroupEntity group = _groupService.GetGroup(Id);
            var result = new GroupResponse { Id = group.Id, Name = group.Name, Users = group.users
                .Select(user => new UserResponse { Guid = user.Guid, Name = user.Name }) } ;
            return Ok(result);
        }
        [HttpPost]
        public ActionResult<GroupResponse> AddGroup(GroupRequest group)
        {
            try
            {
                _groupService.AddGroup(new AddGroupRequest { Name = group.Name });
            }
            catch
            {
                return Conflict();
            }
            return Ok();
        }
        [HttpPost(template: "group_with_users")]
        public ActionResult<GroupResponse> AddGroupWithStudents(GroupUsersRequest group)
        {
            try
            {
                _groupService.AddGroupWithStudent(new AddGroupWithStudentRequest { 
                    addGroupRequest = new AddGroupRequest { Name = group.Name },
                    addStudentRequests = group.Users.Select(user => new AddStudentRequest { StudentName = user.Name }).ToList()
                });
            }
            catch
            {
                return Conflict();
            }
            return Ok();
        }
        [HttpDelete(template: "{id}")]
        public ActionResult<GroupResponse> RemoveGroup(int Id)
        {
            _groupService.DeleteGroup(new DeleteGroupRequest { Id = Id });
            return Ok();
        }

        [HttpPut(template: "{id}")]
        public ActionResult<GroupResponse> UpdateGroup(int Id, GroupRequest group)
        {
            _groupService.UpdateGroup(Id, new UpdateGroupRequest {Name = group.Name });
            return Ok();
        }


    }
}
