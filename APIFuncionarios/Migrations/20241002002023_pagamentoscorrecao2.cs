using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIFuncionarios.Migrations
{
    /// <inheritdoc />
    public partial class pagamentoscorrecao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagamentos_Funcionarios_IdFuncionario",
                table: "Pagamentos");

            migrationBuilder.DropIndex(
                name: "IX_Pagamentos_IdFuncionario",
                table: "Pagamentos");

            migrationBuilder.AddColumn<int>(
                name: "PagamentoId",
                table: "Funcionarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_PagamentoId",
                table: "Funcionarios",
                column: "PagamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Pagamentos_PagamentoId",
                table: "Funcionarios",
                column: "PagamentoId",
                principalTable: "Pagamentos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Pagamentos_PagamentoId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_PagamentoId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "PagamentoId",
                table: "Funcionarios");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_IdFuncionario",
                table: "Pagamentos",
                column: "IdFuncionario",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagamentos_Funcionarios_IdFuncionario",
                table: "Pagamentos",
                column: "IdFuncionario",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
