using data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repository
{
    public interface ISubjectRepository
    {
        public bool AddSubject(SubjectDAO subject);
        public bool RemoveSubject(int Id);
        public bool UpdateSubject(int Id ,SubjectDAO subject);
    }
}
