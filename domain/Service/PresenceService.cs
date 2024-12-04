using data.DAO;
using data.Repository;
using domain.Entity;
using domain.Request;
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
        private readonly IPresenceRepository _precenseRepository;
        public PresenceService(IPresenceRepository presenceRepository) 
        {
            _precenseRepository = presenceRepository;
        }
        public void AddPresence(AddPresenceRequest presence)
        {
            _precenseRepository.AddPresence(new PresenceDAO { 
                UserGuid = presence.UserGuid, 
                StatusId = presence.StatusId, 
                SubjectDayId = presence.SubjectDayId 
            });
        }

        public IEnumerable<PresenceEntity> GetAllPresences()
        {
            return _precenseRepository.GetAllPresences().Select(presence => new PresenceEntity { 
                User = new UserEntity
                {
                    Guid = presence.UserGuid, 
                    Name = presence.User.Name,
                    Group = new GroupEntity 
                    {
                        Id = presence.User.Group.GroupId,
                        Name = presence.User.Group.GroupName
                    }
                },
                Status = new StatusEntity
                {
                    Id= presence.Status.Id,
                    Name = presence.Status.Name,
                },
                SubjectDay = new SubjectDayEntity
                {
                    Id = presence.SubjectDay.Id,
                    Date = presence.SubjectDay.Date,
                    Order = presence.SubjectDay.Order,
                    Subject = new SubjectEntity
                    {
                        Id = presence.SubjectDay.Subject.SubjectId,
                        Name = presence.SubjectDay.Subject.SubjectName,
                        GroupsSubject = presence.SubjectDay.Subject.GroupsSubject.Select(subject => new GroupSubjectEntity
                        {
                            Semester = subject.Semester,
                            Group = new GroupEntity()
                            {
                                Id = subject.Group.GroupId,
                                Name = subject.Group.GroupName
                            }
                        }).ToList(),
                    }
                }
            }).ToList();
        }

        public void RemoveAllPresence()
        {
            _precenseRepository.RemoveAllPresence();
        }

        public void RemovePresenceByGroup(int Id)
        {
            _precenseRepository.RemovePresenceByGroup(Id);
        }

        public void UpdatePresence(int Id, UpdatePresenceRequest presence)
        {
            _precenseRepository.UpdatePresence(Id, new PresenceDAO {  
                SubjectDayId = presence.SubjectDayId, 
                UserGuid = presence.UserGuid 
            });
        }
    }
}
