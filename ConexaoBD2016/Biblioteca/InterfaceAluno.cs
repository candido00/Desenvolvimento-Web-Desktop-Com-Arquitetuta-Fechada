using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
   public  interface InterfaceAluno
    {
       void Insert(Aluno aluno);
       void Update(Aluno aluno);
       void Delete(Aluno aluno);
       bool VerificaDuplicidade(Aluno aluno);
       List<Aluno> Select(Aluno filtro);
    }
}
