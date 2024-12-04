using data.DAO;
using domain.Entity;
using domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.UseCase
{
    public interface IPresenceUseCase
    {
        public void AddPresence(AddPresenceRequest presence);
        public void RemovePresenceByGroup(int Id);
        public void RemoveAllPresence();
        public void UpdatePresence(int Id, UpdatePresenceRequest presence);
        public IEnumerable<PresenceEntity> GetAllPresences();
    }
}
