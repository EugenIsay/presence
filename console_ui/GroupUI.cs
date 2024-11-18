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

        public void AdddGroup() 
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
    }
}
