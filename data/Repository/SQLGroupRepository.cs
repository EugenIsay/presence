﻿using data.DAO;
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

        public bool removeGroup(GroupDAO group)
        {
            try
            {
                _dbContext.groups.Remove(group);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateGroup(GroupDAO group)
        {
            return true;
        }

        public IEnumerable<GroupDAO> getAllGroups()
        {
            return _dbContext.groups.ToList();
        }
    }
}
