using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAluno.Models
{
    public class Alunos
    {
        //public Alunos(string nome, double media)
        //{
        //    Nome = nome;
        //    Media = media;           
        //}
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório!")]
        [MinLength(1, ErrorMessage = ("O nome do campo deve ter ao menos um caractere"))]
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
            Nome = nome;
            Media = media; 
        }
    }
}
