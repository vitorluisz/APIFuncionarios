using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIFuncionarios.Migrations
{
    /// <inheritdoc />
    public partial class pagamentoscorrecao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "Pagamentos");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagamentos_Funcionarios_IdFuncionario",
                table: "Pagamentos");

            migrationBuilder.DropIndex(
                name: "IX_Pagamentos_IdFuncionario",
                table: "Pagamentos");

            migrationBuilder.AddColumn<int>(
                name: "Departamento",
                table: "Pagamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Pagamentos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "Pagamentos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
