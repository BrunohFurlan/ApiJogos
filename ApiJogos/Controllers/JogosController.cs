using ApiJogos.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace ApiJogos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {


        private static readonly List<Jogo> _jogos =

            [
                new Jogo{Id = 1, Titulo = "GTA VII RIO DE JANEIRO", Genero = "Ação", Plataforma = "Console/Pc", AnoLancamento = 2013, Zerado = true},
                new Jogo{Id = 2, Titulo = "ISTRET FIGUITER", Genero = "Luta", Plataforma = "Arcade", AnoLancamento = 1998, Zerado = false},
                new Jogo{Id = 3, Titulo = "MONKEY SIMULATOR", Genero = "RPG", Plataforma = "PC", AnoLancamento = 2013, Zerado = true},
            ];

        private static int _proximoId = 4;

        [HttpGet]
        public ActionResult<IEnumerable<Jogo>> GetJogos()
        {
            return Ok(_jogos);
        }

        [HttpGet("Id")]

        public ActionResult<Jogo> GetJogo(int id)
        {
            var jogo = _jogos.FirstOrDefault(x => x.Id == id);

            if (jogo == null)
            {
                return NotFound();
            }
            return jogo;
        }

        [HttpPost]

        public ActionResult<Jogo> PostJogo(Jogo jogo)
        {
            jogo.Id = _proximoId;

            _jogos.Add(jogo);

            return CreatedAtAction(nameof(GetJogo), new { id = jogo.Id });

        }
    }
}
