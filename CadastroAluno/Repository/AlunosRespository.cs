using CadastroAluno.Contracts;
using CadastroAluno.Data;
using CadastroAluno.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAluno.Repository
{
    public class AlunosRespository : IAlunosRepository
    {
        private readonly CadastroAlunoContext _context;

        public AlunosRespository(CadastroAlunoContext context)
        {
            _context = context;
        }

        public Alunos AddAluno(Alunos aluno)
        {
            _context.Alunos.Add(aluno);

            _context.SaveChanges();
            return aluno;
        }

        public void DeleteAluno(int id)
        {
            throw new NotImplementedException();
        }

        public Alunos GetAlunoById(int? id)
        {
            return _context.Alunos.FirstOrDefault(a => a.Id == id);


        }

        public List<Alunos> GetAlunos()
        {
            return _context.Alunos.ToList();
        }

        public int UpdateAluno(int? id, Alunos alunosAlterado)
        {
            var aluno = _context.Alunos.FirstOrDefault(c => c.Id == id);

            if (aluno == null)
                return 0;

            aluno.AtualizaDados(alunosAlterado.Nome, alunosAlterado.Media);

            _context.Entry(aluno).State = EntityState.Modified;
            return _context.SaveChanges();


        }
        public void DeleteAluno(int? id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
        }
    }
}
    