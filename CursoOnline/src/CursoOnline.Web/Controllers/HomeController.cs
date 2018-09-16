using CursoOnline.Domain._Base;
using CursoOnline.Domain.Cursos;
using CursoOnline.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace CursoOnline.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ArmazenadorDeCurso _armazenadorDeCurso;
        private readonly IRepositorio<Curso> _cursoRepositorio;

        public HomeController(ArmazenadorDeCurso armazenadorDeCurso, IRepositorio<Curso> CursoRepositorio)
        {
            _armazenadorDeCurso = armazenadorDeCurso;
            _cursoRepositorio = CursoRepositorio;
        }

        public IActionResult Index()
        {
            var cursos = _cursoRepositorio.Consultar();

            if(cursos.Any())
            {
                var dtos = cursos.Select(x => new {
                    Id = x.Id,
                    Nome = x.Nome
                });
            }
            return View();
        }

        public IActionResult NovoCurso()
        {
            CursoDto curso = new CursoDto
            {
                Descricao = "Curso de MAtemática aplicada",
                Nome = "Matemática",
                CargaHoraria = 20,
                PublicoAlvo = PublicoAlvo.Empreendedor.ToString(),
                Valor = 900
            };

            _armazenadorDeCurso.Armazenar(curso);

            return View("Index");
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
