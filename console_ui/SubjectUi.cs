using domain.Service;
using domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.Request;

namespace console_ui
{
    class SubjectUi
    {
        private readonly ISubjectUseCase _subjectService;
        public SubjectUi(ISubjectUseCase subjectService)
        {
            subjectService = subjectService;
        }

        public void AddSubject()
        {
            Console.WriteLine("Введите название предмета для добавления");
            _subjectService.AddSubject(new AddSubjectRequest { SubjectName = Console.ReadLine() });
        }

        public void RemoveSubject() 
        {
            Console.WriteLine("Введите номер предметы который хотите удалить");
            _subjectService.RemoveSubject(new RemoveSubjectRequest { SubjectId = Int32.Parse(Console.ReadLine()) });
        }

        public void UpdateSubject()
        {
            Console.WriteLine("Введите id предмета который хотите поменять");
            int Id = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите новое название предмета");
            _subjectService.UpdateSubject(Id, new UpdateSubjectRequest { Name = Console.ReadLine()});
        }
    }
}
