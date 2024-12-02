using data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repository
{
    public class SQLGroupSubjectRepository : IGroupSubjectRepository
    {
        private readonly RemoteDatabaseContext _dbContext;
        public SQLGroupSubjectRepository(RemoteDatabaseContext remoteDatabaseContext)
        {
            _dbContext = remoteDatabaseContext;
        }

        public bool AddGroupSubject(GroupSubjectDAO groupSubject)
        {
            _dbContext.groupsSubjects.Add(groupSubject);
            return _dbContext.SaveChanges() != 0;
        }

        public bool RemoveGroupSubject(GroupSubjectDAO groupSubject)
        {
            GroupSubjectDAO groupSubject1 = _dbContext.groupsSubjects
                .FirstOrDefault(GS => GS.GroupId == groupSubject.GroupId && GS.SubjectId == groupSubject.SubjectId);
            _dbContext.groupsSubjects.Remove(groupSubject1);
            return _dbContext.SaveChanges() != 0;
        }
    }
}
