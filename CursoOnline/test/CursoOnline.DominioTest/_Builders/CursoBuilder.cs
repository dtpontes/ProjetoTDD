using Bogus;
using CursoOnline.Domain.Cursos;

namespace CursoOnline.DominioTest._Builders
{
    public class CursoBuilder
    {
        private  string _nome = new Faker().Random.Word();
        private  decimal _cargaHoraria = new Faker().Random.Decimal(50, 1000);
        private  PublicoAlvo _publicoAlvo = PublicoAlvo.Estudante;
        private  decimal _valor = new Faker().Random.Decimal(100, 1000);
        private  string _descricao = new Faker().Lorem.Paragraph();         

        public static CursoBuilder Novo()
        {
            return new CursoBuilder();
        }

        public CursoBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }
        public CursoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public CursoBuilder ComCargaHoraria(decimal cargaHoraria)
        {
            _cargaHoraria = cargaHoraria;
            return this;
        }

        public CursoBuilder ComValor(decimal valor)
        {
            _valor = valor;
            return this;
        }

        public CursoBuilder ComPubicoAlvo(PublicoAlvo publicoAlvo)
        {
            _publicoAlvo = publicoAlvo;
            return this;
        }

        public Curso Build()
        {
            return new Curso(_nome, _descricao, _cargaHoraria, _publicoAlvo, _valor);
            
        }
    }
}
