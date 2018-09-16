using CursoOnline.Domain._Base;
using System;

namespace CursoOnline.Domain.Cursos
{
    public class Curso : Entidade
    {
        public string Nome { get; private set; }
        public decimal CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public decimal Valor { get; private set; }
        public string Descricao { get; private set; }

        public Curso(string nome, string descricao, decimal cargaHoraria, PublicoAlvo publicoAlvo, decimal valor)
        {

            ValidadorDeRegra.Novo()
                .Quando(string.IsNullOrEmpty(nome), "Nome inválido")
                .Quando(cargaHoraria < 1, "Carga horária menor que 1")
                .Quando(valor < 1, "Valor menor que 1")
                .DispararExcecaoSeExistir();

           
            this.Nome = nome;
            this.CargaHoraria = cargaHoraria;
            this.PublicoAlvo = publicoAlvo;
            this.Valor = valor;
            this.Descricao = descricao;
        }
    }
}
