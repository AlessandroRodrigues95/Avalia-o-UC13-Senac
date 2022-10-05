using CadastroAluno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAluno.Contracts
{
   public  interface IAlunosRepository
    {
       List <Alunos> GetAlunos();

        Alunos GetAlunoById(int? id);

        Alunos AddAluno(Alunos cliente);

       int UpdateAluno(int? id, Alunos alunosAlterado);

         void DeleteAluno(int id);
    }
}
