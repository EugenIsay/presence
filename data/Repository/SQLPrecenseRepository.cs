using data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repository
{
    public class SQLPrecenseRepository : IPresenceRepository
    {
        public bool AddPresence(PresenceDAO presence)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PresenceDAO> GetAllPresences()
        {
            throw new NotImplementedException();
        }

        public PresenceDAO GetPresence(int Id)
        {
            throw new NotImplementedException();
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
