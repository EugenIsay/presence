using data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repository
{
    public interface IUserRepository
    {
        public IEnumerable<UserDAO>getAllUsers();
        public bool addUser(UserDAO user);

        public bool removeUser(Guid guid);

        public bool updateUser(Guid guid, UserDAO user);
    }
}
