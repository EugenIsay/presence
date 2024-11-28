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
            return _dbContext.presences.Include(p => p.User).Include(p => p.SubjectDay).ToList();
        }

        public PresenceDAO GetPresence(int Id)
        {
            PresenceDAO  presence = _dbContext.presences.FirstOrDefault(p => p.);
        }

        public bool RemovePresence(int Id)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePresence(int Id, PresenceDAO presence)
        {
            throw new NotImplementedException();
        }
    }
}
