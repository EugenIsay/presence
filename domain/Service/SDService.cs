using data.Repository;
using domain.Entity;
using domain.Request;
using domain.UseCase;
using data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Service
{
    public class SDService : ISDUseCase
    {

        private readonly ISubjectDayRepository _subjectDayRepository;

        public SDService(ISubjectDayRepository subjectDayRepository)
        {
            _subjectDayRepository = subjectDayRepository;
        }
        public void addSubjectDay(AddSubjectDayRequest subjectDay)
        {
            _subjectDayRepository.addSubjectDay(new SubjectDayDAO { Date = subjectDay.Date, Order = subjectDay.Order, Subject = new SubjectDAO {  SubjectId = subjectDay.SubjectId } });
        }

        public IEnumerable<SubjectDayEntity> getSubjectDays()
        {
            return _subjectDayRepository.getSubjectDays().Select(day => 
            new SubjectDayEntity { 
                Date = day.Date, 
                Id = day.Id, 
                Order = day.Order, 
                Subject = new SubjectEntity { Name = day.Subject.SubjectName, Id = day.Subject.SubjectId, 
                    GroupsSubject = day.Subject.GroupsSubject.Select(gs => new GroupSubjectEntity { 
                        Group = new GroupEntity { Id = gs.Group.GroupId, Name = gs.Group.GroupName  }, Semester = gs.Semester }).ToList() }  
            }).ToList();
        }

        public void removeSubjectDay(int Id)
        {
            _subjectDayRepository.removeSubjectDay(Id);
        }

        public void updateSubjectDay(int Id, UpdateSubjectDayRequest subjectDay)
        {
            _subjectDayRepository.updateSubjectDay(Id, new SubjectDayDAO { Date = subjectDay.Date, Order = subjectDay.Order, Subject = new SubjectDAO { SubjectId = subjectDay.SubjectId } });
        }
    }
}
