using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIFuncionarios.Migrations
{
    /// <inheritdoc />
    public partial class dtos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Funcionarios_NomeFuncionarioPedinteId",
                table: "Chamados");

            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Funcionarios_NomeFuncionarioRecebedorId",
                table: "Chamados");

            migrationBuilder.DropIndex(
                name: "IX_Chamados_NomeFuncionarioPedinteId",
                table: "Chamados");

            migrationBuilder.DropIndex(
                name: "IX_Chamados_NomeFuncionarioRecebedorId",
                table: "Chamados");

            migrationBuilder.DropColumn(
                name: "NomeFuncionarioPedinteId",
                table: "Chamados");

            migrationBuilder.DropColumn(
                name: "NomeFuncionarioRecebedorId",
                table: "Chamados");

            migrationBuilder.AddColumn<int>(
                name: "ChamadosId",
                table: "Funcionarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeFuncionarioPedinte",
                table: "Chamados",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeFuncionarioRecebedor",
                table: "Chamados",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_ChamadosId",
                table: "Funcionarios",
                column: "ChamadosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Chamados_ChamadosId",
                table: "Funcionarios",
                column: "ChamadosId",
                principalTable: "Chamados",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Chamados_ChamadosId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_ChamadosId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "ChamadosId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "NomeFuncionarioPedinte",
                table: "Chamados");

            migrationBuilder.DropColumn(
                name: "NomeFuncionarioRecebedor",
                table: "Chamados");

            migrationBuilder.AddColumn<int>(
                name: "NomeFuncionarioPedinteId",
                table: "Chamados",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NomeFuncionarioRecebedorId",
                table: "Chamados",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_NomeFuncionarioPedinteId",
                table: "Chamados",
                column: "NomeFuncionarioPedinteId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_NomeFuncionarioRecebedorId",
                table: "Chamados",
                column: "NomeFuncionarioRecebedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Funcionarios_NomeFuncionarioPedinteId",
                table: "Chamados",
                column: "NomeFuncionarioPedinteId",
                principalTable: "Funcionarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Funcionarios_NomeFuncionarioRecebedorId",
                table: "Chamados",
                column: "NomeFuncionarioRecebedorId",
                principalTable: "Funcionarios",
                principalColumn: "Id");
        }
    }
}
