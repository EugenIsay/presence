using data.Repository;
using domain.Request;
using domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data.DAO;
using domain.Entity;

namespace domain.Service
{
    public class SubjectService : ISubjectUseCase
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public void AddSubject(AddSubjectRequest addSubjectRequest)
        {
            _subjectRepository.AddSubject(new SubjectDAO { SubjectName = addSubjectRequest.SubjectName });
        }

        IEnumerable<SubjectEntity> ISubjectUseCase.GetAllSubject()
        {
            throw new NotImplementedException();
        }

        public void RemoveSubject(RemoveSubjectRequest removeSubjectRequest)
        {
            _subjectRepository.RemoveSubject(removeSubjectRequest.SubjectId);
        }

        public void UpdateSubject(int Id, UpdateSubjectRequest updateSubjectRequest)
        {
            _subjectRepository.UpdateSubject(Id, new SubjectDAO { SubjectName = updateSubjectRequest.Name });
        }


    }
}
