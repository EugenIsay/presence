using domain.Request;
using domain.Service;
using domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_ui
{
    class GroupUI
    {
        private readonly IGroupUseCase _groupService;
        public GroupUI(IGroupUseCase groupService)
        {
            _groupService = groupService;
        }

        public void AddGroup() 
        {
            Console.WriteLine("Введите название группы");
            _groupService.AddGroup(new AddGroupRequest { Name = Console.ReadLine() });
        }
        public void AddGroupWithStudent()
        {
            Console.WriteLine("Введите имя гурппы");
            AddGroupRequest addGroupRequest = new AddGroupRequest { Name = Console.ReadLine() };
            List<AddStudentRequest> addStudentRequests = new List<AddStudentRequest>()
            {
                new AddStudentRequest{ StudentName = "123" },
                new AddStudentRequest{ StudentName = "321" }
            };
            AddGroupWithStudentRequest addGroupWithStudent = new AddGroupWithStudentRequest { addStudentRequests = addStudentRequests, addGroupRequest = addGroupRequest };
            _groupService.AddGroupWithStudent(addGroupWithStudent);

        }

        public void RemoveGroup() 
        {
            Console.WriteLine("Введите id группы");
            DeleteGroupRequest deleteGroupRequest = new DeleteGroupRequest { Id =  Int32.Parse(Console.ReadLine()) };
            _groupService.DeleteGroup(deleteGroupRequest);
        }

        public void UpdateGroup ()
        {
            UpdateGroupRequest updateGroupRequest = new UpdateGroupRequest();
            Console.WriteLine("Введите id группы которое хотите изменить");
            int Id = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите на какое названик хотите поменять");
            updateGroupRequest.Name = Console.ReadLine();
            _groupService.UpdateGroup(Id, updateGroupRequest);
        }
    }
}