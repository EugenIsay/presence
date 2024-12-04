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
            presence.Status = _dbContext.statuses.FirstOrDefault(status => status.Id == presence.StatusId);
            presence.SubjectDay = _dbContext.subjectdays.FirstOrDefault(subjectDay => subjectDay.Id == presence.SubjectDayId);
            presence.User = _dbContext.users.FirstOrDefault(user => user.Guid == presence.UserGuid);
            _dbContext.presences.Add(presence);
            return _dbContext.SaveChanges() != 0;
        }

        public IEnumerable<PresenceDAO> GetAllPresences()
        {
            return _dbContext.presences
                .Include(p => p.User)
                .ThenInclude(p => p.Group)
                .ThenInclude(p => p.GroupSubjects)
                .Include(p => p.SubjectDay)
                .ThenInclude(p => p.Subject)
                .ThenInclude(p => p.GroupsSubject).ThenInclude(p => p.Group)
                .Include(p => p.Status)
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
            UserDAO user = _dbContext.users.FirstOrDefault(user => user.Guid == presence.UserGuid);
            SubjectDayDAO subjectDay = _dbContext.subjectdays.FirstOrDefault(sb => sb.Id == presence.SubjectDayId);
            PresenceDAO presence1 = _dbContext.presences.FirstOrDefault(p => p.User == user && p.SubjectDay == subjectDay);
            
            presence1.Status = _dbContext.statuses.FirstOrDefault(status => status.Id == Id);

            return _dbContext.SaveChanges() != 0;
        }
    }
}
