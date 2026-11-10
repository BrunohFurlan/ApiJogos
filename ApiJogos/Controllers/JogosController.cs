using ApiJogos.Data;
using ApiJogos.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiJogos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        // Antes os jogos ficavam numa List estática (sumiam ao reiniciar a API).
        // Agora eles ficam salvos no banco jogos.db.
        private readonly AppDbContext _context;

        // O ASP.NET entrega o AppDbContext aqui automaticamente (injeção de dependência)
        public JogosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Jogo>> GetJogos()
        {
            return Ok(_context.Jogos.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Jogo> GetJogo(int id)
        {
            var jogo = _context.Jogos.FirstOrDefault(x => x.Id == id);

            if (jogo == null)
            {
                return NotFound();
            }
            return jogo;
        }

        [HttpPost]
        public ActionResult<Jogo> PostJogo(Jogo jogo)
        {
            // O Id é gerado pelo banco, não precisamos mais do _proximoId
            jogo.Id = 0;

            _context.Jogos.Add(jogo);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetJogo), new { id = jogo.Id }, jogo);
        }
    }
}
