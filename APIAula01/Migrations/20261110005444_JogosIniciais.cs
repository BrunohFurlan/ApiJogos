using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIAula01.Migrations
{
    /// <inheritdoc />
    public partial class JogosIniciais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Jogos",
                columns: new[] { "Id", "AnoLancamento", "Genero", "Plataforma", "Titulo", "Zerado" },
                values: new object[,]
                {
                    { 1, 2023, "Aventura", "Nintendo Switch", "The Legend of Zelda: Tears of the Kingdom", true },
                    { 2, 2025, "Metroidvania", "PC", "Hollow Knight: Silksong", false },
                    { 3, 2025, "Esporte", "PlayStation 5", "EA Sports FC 26", false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jogos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jogos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Jogos",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
