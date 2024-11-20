using domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.UseCase
{
    public interface IUserUseCase
    {
        public void AddUser(AddUserRequest addUserRequest); 
        public void RemoveUser(RemoveUserRequest removeUserRequest);

        public void UpdateUser(Guid guid, UpdateUserRequest updateUserRequest);
    }
}
