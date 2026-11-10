using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIAula01.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaNota : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Nota",
                table: "Jogos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nota",
                value: null);

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nota",
                value: null);

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nota",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nota",
                table: "Jogos");
        }
    }
}
