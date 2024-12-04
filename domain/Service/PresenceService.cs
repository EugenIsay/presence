using data.DAO;
using data.Repository;
using domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Service
{
    public class PresenceService : IPresenceUseCase
    {
        private readonly IPresenceUseCase _precenseRepository;
        public PresenceService() 
        {
            
        }
        public void AddPresence(PresenceDAO presence)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PresenceDAO> GetAllPresences()
        {
            throw new NotImplementedException();
        }

        public void RemoveAllPresence()
        {
            throw new NotImplementedException();
        }

        public void RemovePresenceByGroup(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePresence(int Id, PresenceDAO presence)
        {
            throw new NotImplementedException();
        }
    }
}
