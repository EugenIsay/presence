using domain.Entity;
using domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.UseCase
{
    public interface IGroupUseCase
    {
        public IEnumerable<GroupEntity> GetGroupsWithStudents();
        public void AddGroup(AddGroupRequest addGroupRequest);

        public void AddGroupWithStudent(AddGroupWithStudentRequest addGroupWithStudent);

        public void DeleteGroup(DeleteGroupRequest deleteGroupRequest);

        public void UpdateGroup (int Id, UpdateGroupRequest updateGroupRequest);

        public GroupEntity GetGroup(int Id);

    }
}
