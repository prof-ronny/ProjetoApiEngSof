using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoApiEngSof.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Formulario",
                newName: "TipoOcorrencia");

            migrationBuilder.CreateTable(
                name: "TipoOcorrencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoOcorrencia", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoOcorrencia");

            migrationBuilder.RenameColumn(
                name: "TipoOcorrencia",
                table: "Formulario",
                newName: "Tipo");
        }
    }
}
