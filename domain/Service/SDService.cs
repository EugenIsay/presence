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
            throw new NotImplementedException();
        }

        public void removeSubjectDay(int Id)
        {
            throw new NotImplementedException();
        }

        public void updateSubjectDay(int Id, UpdateSubjectDayRequest subjectDay)
        {
            throw new NotImplementedException();
        }
    }
}
