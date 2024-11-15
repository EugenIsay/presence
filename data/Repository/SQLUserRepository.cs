using data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repository
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly RemoteDatabaseContext _dbContext;
        public SQLUserRepository(RemoteDatabaseContext remoteDatabaseContext)
        {
            _dbContext = remoteDatabaseContext;
        }
        public bool addUser(UserDAO user)
        {
            try
            {
                _dbContext.users.Add(user);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<UserDAO> getAllUsers()
        {
            return _dbContext.users.ToList();
        }

        public bool removeUser(UserDAO user)
        {
            throw new NotImplementedException();
        }

        public bool updateUser(UserDAO user)
        {
            throw new NotImplementedException();
        }
    }
}
