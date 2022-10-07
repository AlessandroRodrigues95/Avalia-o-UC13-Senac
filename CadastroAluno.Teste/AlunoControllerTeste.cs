using CadastroAluno.Contracts;
using CadastroAluno.Controllers;
using CadastroAluno.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CadastroAluno.Teste
{
   public class AlunoControllerTeste
    {
        Mock<IAlunosRepository> _repository;
        Alunos aluno;

        public AlunoControllerTeste()
        {
            _repository = new Mock<IAlunosRepository>();

            aluno = new Alunos()
            {
                Id = 1,
                Nome = "Alessandro",
                Media = 9,
                Turma = "9b"

            };
        }

        [Fact]
        public  void GetAlunos_ExecutaAcao_RetornaOkStatus()
        {
            //Arrange
           AlunosController controller = new AlunosController(_repository.Object);

            //Act
        var result =  controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }


        [Fact]
        public void Index_ExecutaAcao_ChamaRepositorioUmaVez()
        {
            //Arrange
            AlunosController controller = new AlunosController(_repository.Object);

            _repository.Setup(a => a.GetAlunos());

            //Act
            controller.Index();


            //Assert
            _repository.Verify(repo => repo.GetAlunos(), Times.Once);
        }


        [Fact]
       public void Details_ExecutaAcao_RetornaBadRequest()
        {
            AlunosController controller = new AlunosController(_repository.Object);

            //Arrange
           


            //Act
            var result = controller.Details(3);

            //Assert 
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Details_ExecutaAcao_ChamaRepositorioUmaVez()
        {
            AlunosController controller = new AlunosController(_repository.Object);

            //Arrange
            Alunos aluno = new Alunos();
            aluno.Id = 3;

            _repository.Setup(a => a.GetAlunoById(3))
                .Returns(aluno);


            //Act
            controller.Details(3);


            //Assert 
            _repository.Verify(a => a.GetAlunoById(3), Times.Once);
        }

        [Fact]
        public void Create_RetornaView()
        {
            AlunosController controller = new AlunosController(_repository.Object);

            //Arrange



            //Act
            var result = controller.Create();

            //Assert 
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Create_ValidaPropriedades_DaModel()
        {
            AlunosController controller = new AlunosController(_repository.Object);

            //Arrange
            Alunos aluno = new Alunos();

            aluno.Id = -1;
            aluno.Nome = null;
            aluno.Media = -2;
            aluno.Turma = null;

            //Act
            var result = controller.Create(aluno);

            //Assert 
            _repository.Verify(a => a.AddAluno(aluno),Times.Once);
            Assert.IsType<RedirectToActionResult>(result);

        }
    }
}
