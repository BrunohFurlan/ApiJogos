using ApiJogos.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiJogos.Data
{
    // Classe que representa o banco de dados.
    // Cada DbSet vira uma tabela no banco ApiJogosDb (SQL Server).
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Tabela "Jogos"
        public DbSet<Jogo> Jogos { get; set; }

        // Dados iniciais: são inseridos quando o banco é criado pela primeira vez.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jogo>().HasData(
                new Jogo { Id = 1, Titulo = "GTA VII RIO DE JANEIRO", Genero = "Ação", Plataforma = "Console/Pc", AnoLancamento = 2013, Zerado = true },
                new Jogo { Id = 2, Titulo = "ISTRET FIGUITER", Genero = "Luta", Plataforma = "Arcade", AnoLancamento = 1998, Zerado = false },
                new Jogo { Id = 3, Titulo = "MONKEY SIMULATOR", Genero = "RPG", Plataforma = "PC", AnoLancamento = 2013, Zerado = true }
            );
        }
    }
}
