using Bogus;
using CursoOnline.Domain._Base;
using CursoOnline.Domain.Cursos;
using CursoOnline.DominioTest._Builders;
using CursoOnline.DominioTest._Util;
using Moq;
using System;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class ArmazenadorDeCursoTest
    {
        private readonly CursoDto _cursoDto;        
        private readonly ArmazenadorDeCurso _armazenadorDeCurso;
        private readonly Mock<ICursoRepositorio> _cursoRepositorioMock;

        public ArmazenadorDeCursoTest()
        {
            var faker = new Faker();
            _cursoDto = new CursoDto
            {
                Nome = faker.Random.Word(),
                CargaHoraria = faker.Random.Decimal(50, 1000),
                PublicoAlvo = "Estudante",
                Valor = faker.Random.Decimal(100, 1000),
                Descricao = faker.Lorem.Paragraph()                
                };

            _cursoRepositorioMock = new Mock<ICursoRepositorio>();

            _armazenadorDeCurso = new ArmazenadorDeCurso(_cursoRepositorioMock.Object);
        }

        [Fact]
        public void DeveAdicionarCurso()
        {                
            _armazenadorDeCurso.Armazenar(_cursoDto);

            _cursoRepositorioMock.Verify(r => r.Adicionar(
                It.Is<Curso>(
                    c=>c.Nome == _cursoDto.Nome
                    && c.Descricao == _cursoDto.Descricao
                    )
            ), Times.AtLeast(1)
            );
        }

        [Fact]
        public void NaoDeveAdicionarCursoComMesmoNomeDeOutroSalvo()
        {
            var cursoJaSalvo = CursoBuilder.Novo().ComNome(_cursoDto.Nome).Build();

            _cursoRepositorioMock.Setup(r => r.ObterPeloNome(_cursoDto.Nome)).Returns(cursoJaSalvo);

            Assert.Throws<ExcecaoDeDominio>(() => _armazenadorDeCurso.Armazenar(_cursoDto)).ComMensagem("Nome do curso já consta no banco de dados");
        }

        [Fact]
        public void NaoDeveInformarPublicoAlvoInvalido()
        {           
            _cursoDto.PublicoAlvo = "Médico";

            Assert.Throws<ExcecaoDeDominio>(() =>_armazenadorDeCurso.Armazenar(_cursoDto)).ComMensagem("Publico Alvo Inválido");
        }       
    }

    

    

    

    
}
