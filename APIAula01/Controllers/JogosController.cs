using APIAula01.Data;
using APIAula01.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIAula01.Controllers;

/// <summary>
/// Versão 2: os dados ficam num banco de dados, acessado pelo Entity Framework Core.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class JogosController : ControllerBase
{
    private readonly AppDbContext _context;

    // O ASP.NET entrega um AppDbContext novo a cada requisição (Scoped)
    public JogosController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Jogos
    [HttpGet]
    public ActionResult<IEnumerable<Jogo>> GetJogos()
    {
        return Ok(_context.Jogos.ToList());
    }

    // GET: api/Jogos/5
    [HttpGet("{id}")]
    public ActionResult<Jogo> GetJogo(int id)
    {
        var jogo = _context.Jogos.Find(id);

        if (jogo is null)
        {
            return NotFound();
        }

        return Ok(jogo);
    }

    // POST: api/Jogos
    [HttpPost]
    public ActionResult<Jogo> PostJogo(Jogo jogo)
    {
        jogo.Id = 0;                  // quem gera o Id agora é o banco

        _context.Jogos.Add(jogo);     // 1. anota: "isto é para inserir"
        _context.SaveChanges();       // 2. envia de fato para o banco (INSERT)

        // 201 Created + cabeçalho Location apontando para GET api/Jogos/{id}
        return CreatedAtAction(nameof(GetJogo), new { id = jogo.Id }, jogo);
    }

    // PUT: api/Jogos/5
    [HttpPut("{id}")]
    public IActionResult PutJogo(int id, Jogo jogoAtualizado)
    {
        var jogo = _context.Jogos.Find(id);

        if (jogo is null)
        {
            return NotFound();
        }

        jogo.Titulo = jogoAtualizado.Titulo;
        jogo.Genero = jogoAtualizado.Genero;
        jogo.Plataforma = jogoAtualizado.Plataforma;
        jogo.AnoLancamento = jogoAtualizado.AnoLancamento;
        jogo.Zerado = jogoAtualizado.Zerado;
        jogo.Nota = jogoAtualizado.Nota;

        _context.SaveChanges();       // UPDATE só do que mudou

        return NoContent();
    }

    // DELETE: api/Jogos/5
    [HttpDelete("{id}")]
    public IActionResult DeleteJogo(int id)
    {
        var jogo = _context.Jogos.Find(id);

        if (jogo is null)
        {
            return NotFound();
        }

        _context.Jogos.Remove(jogo);
        _context.SaveChanges();       // DELETE

        return NoContent();
    }
}
