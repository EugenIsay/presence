using data.DAO;
using data.Repository;
using domain.Request;
using domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Service
{
    public class UserService : IUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void AddGroup(AddUserRequest addUserRequest)
        {
            _userRepository.addUser(new UserDAO { Name = addUserRequest.Name });
        }
        public void RemoveGroup(RemoveUserRequest removeUserRequest)
        {
            _userRepository.removeUser(removeUserRequest.guid);
        }

        public void UpdateGroup(Guid guid, UpdateUserRequest updateUserRequest)
        {
            _userRepository.updateUser(guid, new UserDAO { Name = updateUserRequest.UserName, Group = new GroupDAO { GroupId = updateUserRequest.GroupId } });
        }
    }
}
