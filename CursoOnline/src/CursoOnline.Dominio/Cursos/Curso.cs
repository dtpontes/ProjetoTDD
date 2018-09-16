using CursoOnline.Dominio._Base;
using CursoOnline.Dominio.Cursos;
using System;

namespace CursoOnline.Dominio.Cursos
{
    public class Curso : Entidade
    {
        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }
        public string Descricao { get; private set; }

        public Curso(string nome, string descricao, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            if(string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("Nome inválido");
            }
            this.Nome = nome;

            if(cargaHoraria < 1)
            {
                throw new ArgumentException("Carga horária menor que 1");
            }
            this.CargaHoraria = cargaHoraria;
            this.PublicoAlvo = publicoAlvo;

            if (valor < 1)
            {
                throw new ArgumentException("Valor menor que 1");
            }
            this.Valor = valor;

            this.Descricao = descricao;
        }
    }
}
