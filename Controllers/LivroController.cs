using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers
{
    public class LivroController : Controller
    {
        private BibliotecaDbContext _contexto { get; set; }

        public LivroController (BibliotecaDbContext contexto)
        {
            _contexto = contexto;
        }
        
        public ActionResult Listar()
        {
            var TodosOsLivros = _contexto.Livros
                .Include(p => p.LivroEditora)
                .Include(p => p.AutoresDoLivro).ThenInclude(p => p.Autor);

            ViewData["Title"] = "Lista de livros";
            ViewBag.dados = TodosOsLivros;

            return View();
        }

        public ActionResult Detalhar(int? id)
        {
            var livro = _contexto.Livros
                .Include(p => p.LivroEditora)
                .Include(p => p.AutoresDoLivro).ThenInclude(p => p.Autor)
                .Where(l => l.LivroID == id);

            return View();
        }

    }
}
