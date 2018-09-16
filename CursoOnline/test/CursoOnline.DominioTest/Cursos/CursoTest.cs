using Bogus;
using CursoOnline.DominioTest._Builders;
using CursoOnline.DominioTest._Util;
using ExpectedObjects;
using System;
using Xunit;
using Xunit.Abstractions;
using CursoOnline.Domain.Cursos;
using CursoOnline.Domain._Base;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTest 
    {
        private readonly ITestOutputHelper _output;
        private readonly string _nome;
        private readonly decimal _cargaHoraria;
        private readonly PublicoAlvo _publicoAlvo;
        private readonly decimal _valor;
        private readonly string _descricao;

        public CursoTest(ITestOutputHelper output)
        {
            _output = output;

            var faker = new Faker();
            _nome = faker.Random.Word();
            _cargaHoraria = faker.Random.Decimal(50,1000);
            _publicoAlvo = PublicoAlvo.Estudante;
            _valor = faker.Random.Decimal(100,1000);
            _descricao = faker.Lorem.Paragraph();     

        }        

        [Fact(DisplayName = "DeveCriarCurso")]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = _nome,
                CargaHoraria = _cargaHoraria,
                PublicoAlvo = _publicoAlvo,
                Valor = _valor,
                Descricao = _descricao
                
            };            

            var curso = new Curso(cursoEsperado.Nome,cursoEsperado.Descricao, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerUmNomeInvalido(string nomeInvalido)
        {           

            
            Assert.Throws<ExcecaoDeDominio>(() =>
                CursoBuilder.Novo().ComNome(nomeInvalido).Build())
                .ComMensagem("Nome inválido");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmaCargaHorariaMenorQUe1(decimal cargaHoraria)
        {      

            Assert.Throws<ExcecaoDeDominio>(() =>
            CursoBuilder.Novo().ComCargaHoraria(cargaHoraria).Build())
            .ComMensagem("Carga horária menor que 1");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmValorMenorQUe1(decimal valorInvalido)
        {
           Assert.Throws<ExcecaoDeDominio>(() =>
           CursoBuilder.Novo().ComValor(valorInvalido).Build())
           .ComMensagem("Valor menor que 1");
        }

        
    }

    
}
