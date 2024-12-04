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
    public class UserService : IUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void AddUser(AddUserRequest addUserRequest)
        {
            _userRepository.addUser( new UserDAO {
                Name = addUserRequest.Name,
                Group = new GroupDAO
                {    
                    GroupId = addUserRequest.GroupId 
                }  
            });
        }

        public IEnumerable<UserEntity> GetAllUsers()
        {
            return _userRepository.getAllUsers()
                .Select(u => new UserEntity { 
                    Guid = u.Guid, 
                    Name = u.Name, 
                    Group = new GroupEntity { Name = u.Group.GroupName }})
                .ToList();
        }

        public UserEntity GetUser(Guid guid)
        {
            UserDAO user = _userRepository.getUser(guid);
            return new UserEntity { 
                Guid = user.Guid, 
                Name = user.Name, 
                Group = new GroupEntity { 
                    Name = user.Group.GroupName 
                } 
            };
        }

        public void RemoveUser(RemoveUserRequest removeUserRequest)
        {
            _userRepository.removeUser(removeUserRequest.guid);
        }

        public void UpdateUser(Guid guid, UpdateUserRequest updateUserRequest)
        {
            _userRepository.updateUser(guid, new UserDAO { 
                Name = updateUserRequest.UserName, 
                Group = new GroupDAO { 
                    GroupId = updateUserRequest.GroupId 
                } 
            });
        }
    }
}
