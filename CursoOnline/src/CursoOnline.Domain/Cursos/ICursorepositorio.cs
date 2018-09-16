using CursoOnline.Domain._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoOnline.Domain.Cursos
{
    public interface ICursoRepositorio : IRepositorio<Curso>
    {        
        Curso ObterPeloNome(string nome);
    }
}
