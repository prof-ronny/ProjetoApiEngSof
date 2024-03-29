using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoApiEngSof.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ong",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    autenticacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PessoaFisica",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autenticacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaFisica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formulario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PessoaFisicaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OngId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    localizacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formulario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Formulario_Ong_OngId",
                        column: x => x.OngId,
                        principalTable: "Ong",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Formulario_PessoaFisica_PessoaFisicaId",
                        column: x => x.PessoaFisicaId,
                        principalTable: "PessoaFisica",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Atualizacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormularioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OngId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PessoaFisicaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atualizacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atualizacoes_Formulario_FormularioId",
                        column: x => x.FormularioId,
                        principalTable: "Formulario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atualizacoes_Ong_OngId",
                        column: x => x.OngId,
                        principalTable: "Ong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atualizacoes_PessoaFisica_PessoaFisicaId",
                        column: x => x.PessoaFisicaId,
                        principalTable: "PessoaFisica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Foto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caminho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormularioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foto_Formulario_FormularioId",
                        column: x => x.FormularioId,
                        principalTable: "Formulario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atualizacoes_FormularioId",
                table: "Atualizacoes",
                column: "FormularioId");

            migrationBuilder.CreateIndex(
                name: "IX_Atualizacoes_OngId",
                table: "Atualizacoes",
                column: "OngId");

            migrationBuilder.CreateIndex(
                name: "IX_Atualizacoes_PessoaFisicaId",
                table: "Atualizacoes",
                column: "PessoaFisicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Formulario_OngId",
                table: "Formulario",
                column: "OngId");

            migrationBuilder.CreateIndex(
                name: "IX_Formulario_PessoaFisicaId",
                table: "Formulario",
                column: "PessoaFisicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Foto_FormularioId",
                table: "Foto",
                column: "FormularioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atualizacoes");

            migrationBuilder.DropTable(
                name: "Foto");

            migrationBuilder.DropTable(
                name: "Formulario");

            migrationBuilder.DropTable(
                name: "Ong");

            migrationBuilder.DropTable(
                name: "PessoaFisica");
        }
    }
}
