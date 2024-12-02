using data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repository
{
    public interface IPresenceRepository
    {
        public bool AddPresence(PresenceDAO presence);
        public bool RemovePresence(int Id);
        public bool UpdatePresence(int Id, PresenceDAO presence);
        public IEnumerable<PresenceDAO> GetAllPresences();
    }
}
