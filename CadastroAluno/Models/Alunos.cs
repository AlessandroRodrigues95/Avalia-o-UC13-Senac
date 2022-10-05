using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAluno.Models
{
    public class Alunos
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Turma { get; set; }

        public double Media { get; set; }

        public void AtualizarDados(string nome, string turma)
        {
            Nome = nome;
            Turma = turma;
        }

        public bool VerificaAprovacao()
        
           => Media > 5;
           
        
        public void AtualizaMedia(double novaMedia)
        {
            Media = novaMedia;
        }

        internal void AtualizaDados(string nome, double media)
        {
            throw new NotImplementedException();
        }
    }
}
