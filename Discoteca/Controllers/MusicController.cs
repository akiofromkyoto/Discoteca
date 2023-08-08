using Discoteca.Models;
using Discoteca.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Discoteca.Controllers
{
    public class MusicController : Controller
    {
        private readonly IMusicRepositorio _musicRepositorio;
        public MusicController(IMusicRepositorio musicRepositorio) 
        {
            _musicRepositorio = musicRepositorio;
        }

        public IActionResult Index()
        {
            List<MusicModel> musics = _musicRepositorio.BuscarTodos();

            return View(musics);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            MusicModel music = _musicRepositorio.ListarPorId(id);
            return View(music);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            MusicModel music = _musicRepositorio.ListarPorId(id);
            return View(music);
        }

        public IActionResult Apagar(int id)
        {
            _musicRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(MusicModel music)
        {
            _musicRepositorio.Adicionar(music);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(MusicModel music)
        {
            _musicRepositorio.Atualizar(music);
            return RedirectToAction("Index");
        }
    }
}
