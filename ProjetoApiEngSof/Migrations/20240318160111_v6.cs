using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoApiEngSof.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "endereco",
                table: "Ong",
                newName: "Endereco");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Ong",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "autenticacao",
                table: "Ong",
                newName: "Autenticacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Endereco",
                table: "Ong",
                newName: "endereco");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Ong",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Autenticacao",
                table: "Ong",
                newName: "autenticacao");
        }
    }
}
