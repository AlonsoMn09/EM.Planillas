using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EM.Planilla.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class modeloV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deductions_amount",
                schema: "planilla",
                table: "payroll_details");

            migrationBuilder.DropColumn(
                name: "deductions_currency",
                schema: "planilla",
                table: "payroll_details");

            migrationBuilder.DropColumn(
                name: "earnings_currency",
                schema: "planilla",
                table: "payroll_details");

            migrationBuilder.DropColumn(
                name: "pay_currency",
                schema: "planilla",
                table: "payroll_details");

            migrationBuilder.RenameColumn(
                name: "pay_amount",
                schema: "planilla",
                table: "payroll_details",
                newName: "total_earnings");

            migrationBuilder.RenameColumn(
                name: "earnings_amount",
                schema: "planilla",
                table: "payroll_details",
                newName: "net_pay");

            migrationBuilder.AddColumn<decimal>(
                name: "AFP",
                schema: "planilla",
                table: "payroll_details",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NetPay",
                schema: "planilla",
                table: "payroll_details",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AFP",
                schema: "planilla",
                table: "payroll_details");

            migrationBuilder.DropColumn(
                name: "NetPay",
                schema: "planilla",
                table: "payroll_details");

            migrationBuilder.RenameColumn(
                name: "total_earnings",
                schema: "planilla",
                table: "payroll_details",
                newName: "pay_amount");

            migrationBuilder.RenameColumn(
                name: "net_pay",
                schema: "planilla",
                table: "payroll_details",
                newName: "earnings_amount");

            migrationBuilder.AddColumn<decimal>(
                name: "deductions_amount",
                schema: "planilla",
                table: "payroll_details",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "deductions_currency",
                schema: "planilla",
                table: "payroll_details",
                type: "character varying(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "earnings_currency",
                schema: "planilla",
                table: "payroll_details",
                type: "character varying(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "pay_currency",
                schema: "planilla",
                table: "payroll_details",
                type: "character varying(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");
        }
    }
}
