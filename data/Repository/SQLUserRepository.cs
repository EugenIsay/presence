﻿using data.DAO;
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

        public bool removeUser(Guid guid)
        {
            try
            {
                UserDAO user = _dbContext.users.FirstOrDefault(u => u.Guid == guid);
                _dbContext.users.Remove(user);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateUser(Guid guid, UserDAO user)
        {
            try
            {
                UserDAO mainUser = _dbContext.users.FirstOrDefault(u => u.Guid == guid);
                mainUser.Name = user.Name;
                GroupDAO group = _dbContext.groups.FirstOrDefault(g => g.GroupId == user.Group.GroupId);
                mainUser.Group = group;
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}