using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIFuncionarios.Migrations
{
    /// <inheritdoc />
    public partial class adicaochamados2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chamados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFuncionarioPedinte = table.Column<int>(type: "int", nullable: false),
                    NomeFuncionarioPedinteId = table.Column<int>(type: "int", nullable: true),
                    IdFuncionarioRecebedor = table.Column<int>(type: "int", nullable: false),
                    NomeFuncionarioRecebedorId = table.Column<int>(type: "int", nullable: true),
                    Departamento = table.Column<int>(type: "int", nullable: false),
                    Título = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detalhes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Finalizado = table.Column<bool>(type: "bit", nullable: false),
                    DataDeCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDeFinalização = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comentarios = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chamados_Funcionarios_NomeFuncionarioPedinteId",
                        column: x => x.NomeFuncionarioPedinteId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Chamados_Funcionarios_NomeFuncionarioRecebedorId",
                        column: x => x.NomeFuncionarioRecebedorId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_NomeFuncionarioPedinteId",
                table: "Chamados",
                column: "NomeFuncionarioPedinteId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_NomeFuncionarioRecebedorId",
                table: "Chamados",
                column: "NomeFuncionarioRecebedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chamados");
        }
    }
}
