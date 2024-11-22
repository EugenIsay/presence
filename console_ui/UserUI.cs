using System;
using System.Collections.Generic;
using domain.UseCase;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data.DAO;
using domain.Request;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;

namespace console_ui
{
    class UserUI
    {
        private readonly IUserUseCase _userService;
        public UserUI(IUserUseCase userService)
        {
            _userService = userService;
        }
        public void AddUser()
        {
            Console.WriteLine("Введите имя студента");
            UserDAO user = new UserDAO();
            user.Name = Console.ReadLine();
            Console.WriteLine("Введите номер его группы");
            _userService.AddUser(new AddUserRequest { Name = user.Name, GroupId = Int32.Parse(Console.ReadLine()) });
        }
        public void RemoveUser()
        {
            Console.WriteLine("Введите Guid студента");
            _userService.RemoveUser(new RemoveUserRequest { guid = Guid.Parse(Console.ReadLine()) });
        }
        public void UpdateUser()
        {
            Console.WriteLine("Введите Guid студента для изменения");
            Guid guid = Guid.Parse(Console.ReadLine());
            Console.WriteLine("Введите новое имя студента");
            UpdateUserRequest user = new UpdateUserRequest();
            user.UserName = Console.ReadLine();
            Console.WriteLine("Введите новую группу студента");
            user.GroupId = Int32.Parse(Console.ReadLine());
            _userService.UpdateUser(guid, user);
        }
    }
}
