using data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.UseCase
{
    public interface IPresenceUseCase
    {
        public void AddPresence(PresenceDAO presence);
        public void RemovePresenceByGroup(int Id);
        public void RemoveAllPresence();
        public void UpdatePresence(int Id, PresenceDAO presence);
        public IEnumerable<PresenceDAO> GetAllPresences();
    }
}
