using CadastroAluno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CadastroAluno.Teste
{
    public class AlunoTest
    {
        [Fact]
        public void  AtualizaDados()
        {
            //Arrange
            Alunos aluno = new Alunos();
            aluno.Nome = "Jose";
            aluno.Turma = "9";
            

            //Act
            aluno.AtualizarDados("José", "10");

            //Assert
            Assert.Equal("José",aluno.Nome);
            Assert.Equal("10", aluno.Turma);

            
        }

        [Theory]
        [InlineData(5)]
        [InlineData(7)]
        [InlineData(10)]
        public void VerificaAprovacao(double n1)
        {
            //Arrange

            Alunos aluno = new Alunos();
            aluno.Media = n1;


            //Act 

            var result = aluno.VerificaAprovacao();

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(3)]
        [InlineData(0)]
        public void VerificaAprovacao_AlunoReprovado(double n1)
        {
            //Arrange

            Alunos aluno = new Alunos();
            aluno.Media = n1;


            //Act 

            var result = aluno.VerificaAprovacao();

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void AtualizaMedia()
        {
            //Arrange
            Alunos aluno = new Alunos();
            aluno.Media = 5;



            //Act
            aluno.AtualizaMedia(10);

            //Assert
            Assert.Equal(10, aluno.Media);
        }
        }
    }
