using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EM.Planilla.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class modeloV5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NetPay",
                schema: "planilla",
                table: "payroll_details");

            migrationBuilder.RenameColumn(
                name: "AFP",
                schema: "planilla",
                table: "payroll_details",
                newName: "afp");

            migrationBuilder.AlterColumn<decimal>(
                name: "afp",
                schema: "planilla",
                table: "payroll_details",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<decimal>(
                name: "total_deductions",
                schema: "planilla",
                table: "payroll_details",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total_deductions",
                schema: "planilla",
                table: "payroll_details");

            migrationBuilder.RenameColumn(
                name: "afp",
                schema: "planilla",
                table: "payroll_details",
                newName: "AFP");

            migrationBuilder.AlterColumn<decimal>(
                name: "AFP",
                schema: "planilla",
                table: "payroll_details",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "NetPay",
                schema: "planilla",
                table: "payroll_details",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
