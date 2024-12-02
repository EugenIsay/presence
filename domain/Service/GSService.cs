using data.Repository;
using domain.Request;
using domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data.DAO;

namespace domain.Service
{
    public class GSService : IGSUseCase
    {
        private readonly IGroupSubjectRepository _groupSubjectRepository;

        public GSService(IGroupSubjectRepository groupSubjectRepository)
        {
            _groupSubjectRepository = groupSubjectRepository;
        }
        public void AddGroupSubject(AddGroupSubjectsRequest addGroupSubjects)
        {
            
            foreach (var subject in addGroupSubjects.subjects)
            {
                _groupSubjectRepository.AddGroupSubject(new GroupSubjectDAO { GroupId = addGroupSubjects.GroupId, Semester = subject.Semestr, SubjectId = subject.SubjectId });
            }
        }
    }
}
