using domain.Request;
using domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_ui
{
    class GroupUI
    {
        private readonly GroupService _groupService;
        public GroupUI(GroupService groupService)
        {
            _groupService = groupService;
        }

        public void AdddGroup() 
        {
            Console.WriteLine("Введите название группы");
            _groupService.AddGroup(new AddGroupRequest { Name = Console.ReadLine() });
        }
    }
}
