using domain.Entity;
using domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.UseCase
{
    public interface ISDUseCase
    {
        public IEnumerable<SubjectDayEntity> getSubjectDays();
        public void addSubjectDay(AddSubjectDayRequest subjectDay);

        public void removeSubjectDay(int Id);

        public void updateSubjectDay(int Id, UpdateSubjectDayRequest subjectDay);
    }
}
