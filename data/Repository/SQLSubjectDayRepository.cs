using data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repository
{
    internal class SQLSubjectDayRepository : ISubjectDayRepository
    {
        private readonly RemoteDatabaseContext _dbContext;
        public SQLSubjectDayRepository(RemoteDatabaseContext remoteDatabaseContext)
        {
            _dbContext = remoteDatabaseContext;
        }
        public bool addSubjectDay(SubjectDayDAO subjectDay)
        {
            _dbContext.subjectdays.Add(subjectDay);
            return _dbContext.SaveChanges() != 0;
        }

        public IEnumerable<SubjectDayDAO> getSybjectDays()
        {
            return _dbContext.subjectdays.ToList();
        }

        public bool removeSubjectDay(int Id)
        {
            throw new NotImplementedException();
        }

        public bool updateSubjectDay(int Id, SubjectDayDAO subjectDay)
        {
            throw new NotImplementedException();
        }
    }
}
