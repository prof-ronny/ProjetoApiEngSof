using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoApiEngSof.Migrations
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foto_Formulario_FormularioId",
                table: "Foto");

            migrationBuilder.AlterColumn<Guid>(
                name: "FormularioId",
                table: "Foto",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_Formulario_FormularioId",
                table: "Foto",
                column: "FormularioId",
                principalTable: "Formulario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foto_Formulario_FormularioId",
                table: "Foto");

            migrationBuilder.AlterColumn<Guid>(
                name: "FormularioId",
                table: "Foto",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Foto_Formulario_FormularioId",
                table: "Foto",
                column: "FormularioId",
                principalTable: "Formulario",
                principalColumn: "Id");
        }
    }
}
