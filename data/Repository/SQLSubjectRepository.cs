using data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repository
{
    public class SQLSubjectRepository : ISubjectRepository
    {
        private readonly RemoteDatabaseContext _dbContext;
        public SQLSubjectRepository(RemoteDatabaseContext remoteDatabaseContext)
        {
            _dbContext = remoteDatabaseContext;
        }

        public bool AddSubject(SubjectDAO subject)
        {
            _dbContext.subjects.Add(subject);
            return _dbContext.SaveChanges() != 0;
        }

        public bool RemoveSubject(int Id)
        {
            SubjectDAO subject = _dbContext.subjects.FirstOrDefault(s => s.SubjectId == Id);
            _dbContext.subjects.Remove(subject);
            return _dbContext.SaveChanges() != 0;
        }

        public bool UpdateSubject(int Id, SubjectDAO subject)
        {
            SubjectDAO subject1 = _dbContext.subjects.FirstOrDefault(s => s.SubjectId == Id);
            subject1.SubjectName = subject.SubjectName;
            return _dbContext.SaveChanges() != 0;
        }
    }
}
