using data.DAO;
using data.Repository;
using domain.Entity;
using domain.Request;
using domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Service
{
    public class GroupService : IGroupUseCase
    {
        private readonly IGroupRepository _groupRepository;

        public GroupService(IGroupRepository groupRepository) {
            _groupRepository = groupRepository;
        }

        public void AddGroup(AddGroupRequest addGroupRequest)
        {
            _groupRepository.addGroup(new GroupDAO { GroupName = addGroupRequest.Name });
        }

        public void AddGroupWithStudent(AddGroupWithStudentRequest addGroupWithStudent)
        {
            GroupDAO groupDAO = new GroupDAO { GroupName = addGroupWithStudent.addGroupRequest.Name };
            List<UserDAO> users = addGroupWithStudent.addStudentRequests.Select(it => new UserDAO { Name = it.StudentName }).ToList();
            _groupRepository.addGroupWithStudents(groupDAO, users);
        }

        public void DeleteGroup(DeleteGroupRequest deleteGroupRequest)
        {
            _groupRepository.removeGroup(deleteGroupRequest.Id);
        }

        public IEnumerable<GroupEntity> GetGroupsWithStudents()
        {
            return _groupRepository.getAllGroups().Select(group => new GroupEntity { Id = group.GroupId, Name = group.GroupName, 
                users = group.Users.Select(user => new UserEntity { Guid = user.Guid, Name = user.Name }).ToList() }).ToList();
        }

        public void UpdateGroup(int Id, UpdateGroupRequest updateGroupRequest)
        {
            _groupRepository.updateGroup(Id, new GroupDAO() { GroupName = updateGroupRequest.Name });
        }
    }
}
