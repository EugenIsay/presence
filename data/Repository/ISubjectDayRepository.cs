using data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repository
{
    public interface ISubjectDayRepository
    {
        public IEnumerable<SubjectDayDAO> getSubjectDays();
        public bool addSubjectDay(SubjectDayDAO subjectDay);

        public bool removeSubjectDay(int Id);

        public bool updateSubjectDay(int Id, SubjectDayDAO subjectDay);
    }
}
