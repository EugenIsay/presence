using data.DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repository
{
    public class SQLGroupRepository:IGroupRepository
    {
        private readonly RemoteDatabaseContext _dbContext;
        public SQLGroupRepository(RemoteDatabaseContext remoteDatabaseContext) 
        {
            _dbContext = remoteDatabaseContext;
        }

        public bool addGroup(GroupDAO group)
        {
            try
            {
                _dbContext.groups.Add(group);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool removeGroup(int id)
        {
            try
            {
                GroupDAO? groupDAO = _dbContext.groups.FirstOrDefault(g => g.GroupId == id);
                if (groupDAO == null) return false;
                _dbContext.groups.Remove(groupDAO);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }



        public bool addGroupWithStudents(GroupDAO groupDAO, IEnumerable<UserDAO> userDAOs)
        {
            using var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                _dbContext.groups.Add(groupDAO);
                _dbContext.SaveChanges();
                foreach (var user in userDAOs)
                {
                    user.Group = groupDAO;
                    _dbContext.users.Add(user);
                }
                _dbContext.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback(); 
                return false;
            }
        }

        public bool updateGroup(int id, GroupDAO group)
        {
            try
            {
                GroupDAO? groupDAO = _dbContext.groups.FirstOrDefault(g => g.GroupId == id);
                groupDAO.GroupName = group.GroupName;
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<GroupDAO> getAllGroups()
        {
            return _dbContext.groups.Include(group => group.Users).ToList();
        }

        public GroupDAO getGroup(int Id)
        {
            return _dbContext.groups.FirstOrDefault(g => g.GroupId == Id);
        }
    }
}
