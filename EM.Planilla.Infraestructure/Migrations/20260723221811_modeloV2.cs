using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EM.Planilla.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class modeloV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "amount_salary",
                schema: "planilla",
                table: "employees",
                newName: "salary_currency");

            migrationBuilder.RenameColumn(
                name: "amount",
                schema: "planilla",
                table: "employees",
                newName: "salary_amount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "salary_currency",
                schema: "planilla",
                table: "employees",
                newName: "amount_salary");

            migrationBuilder.RenameColumn(
                name: "salary_amount",
                schema: "planilla",
                table: "employees",
                newName: "amount");
        }
    }
}
