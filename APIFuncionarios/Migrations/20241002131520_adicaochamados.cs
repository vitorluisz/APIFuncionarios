using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIFuncionarios.Migrations
{
    /// <inheritdoc />
    public partial class adicaochamados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeFuncionario",
                table: "Pagamentos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SobrenomeFuncionario",
                table: "Pagamentos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeFuncionario",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "SobrenomeFuncionario",
                table: "Pagamentos");
        }
    }
}
