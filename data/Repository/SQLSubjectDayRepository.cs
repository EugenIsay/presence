using data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repository
{
    public class SQLSubjectDayRepository : ISubjectDayRepository
    {
        private readonly RemoteDatabaseContext _dbContext;
        public SQLSubjectDayRepository(RemoteDatabaseContext remoteDatabaseContext)
        {
            _dbContext = remoteDatabaseContext;
        }
        public bool addSubjectDay(SubjectDayDAO subjectDay)
        {
            subjectDay.Subject = _dbContext.subjects
                .FirstOrDefault(sb => sb.SubjectId == subjectDay.Subject.SubjectId);
            _dbContext.subjectdays.Add(subjectDay);
            return _dbContext.SaveChanges() != 0;
        }

        public IEnumerable<SubjectDayDAO> getSubjectDays()
        {
            return _dbContext.subjectdays.ToList();
        }

        public bool removeSubjectDay(int Id)
        {
            SubjectDayDAO subgectDay = _dbContext.subjectdays.FirstOrDefault(sb => sb.Id == Id);
            _dbContext.subjectdays.Remove(subgectDay);
            return _dbContext.SaveChanges() != 0;
        }

        public bool updateSubjectDay(int Id, SubjectDayDAO subjectDay)
        {
            SubjectDayDAO subgectDay1 = _dbContext.subjectdays.FirstOrDefault(sb => sb.Id == Id);
            subgectDay1.Date = subjectDay.Date;
            subgectDay1.Order = subjectDay.Order;
            subgectDay1.Subject = subjectDay.Subject;
            return _dbContext.SaveChanges() != 0;
        }
    }
}
