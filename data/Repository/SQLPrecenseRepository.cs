using data.DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repository
{
    public class SQLPrecenseRepository : IPresenceRepository
    {
        private readonly RemoteDatabaseContext _dbContext;
        public SQLPrecenseRepository(RemoteDatabaseContext remoteDatabaseContext)
        {
            _dbContext = remoteDatabaseContext;
        }
        public bool AddPresence(PresenceDAO presence)
        {
            _dbContext.presences.Add(presence);
            return _dbContext.SaveChanges() != 0;
        }

        public IEnumerable<PresenceDAO> GetAllPresences()
        {
            return _dbContext.presences
                .Include(p => p.User)
                .ThenInclude(p => p.Group)
                .Include(p => p.SubjectDay)
                .ThenInclude(p => p.Subject)
                .ThenInclude(p => p.GroupsSubject)
                .ToList();
        }


        public bool RemovePresenceByGroup(int Id)
        {
            _dbContext.presences.RemoveRange(_dbContext.presences.Where(p => p.User.Group.GroupId == Id).ToList());
            return _dbContext.SaveChanges() != 0;
        }

        public bool RemoveAllPresence()
        {
            _dbContext.presences.RemoveRange(_dbContext.presences.ToList());
            return _dbContext.SaveChanges() != 0;
        }

        public bool UpdatePresence(int Id, PresenceDAO presence)
        {
            return true;
        }
    }
}
