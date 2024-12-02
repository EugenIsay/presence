using domain.Request;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.UseCase
{
    public interface IGSUseCase
    {
        public void AddGroupSubject(AddGroupSubjectsRequest addGroupSubjects);
    }
}
