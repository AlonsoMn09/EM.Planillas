using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EM.Planilla.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class modeloV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_loans_Status",
                schema: "planilla",
                table: "loans");

            migrationBuilder.RenameColumn(
                name: "Status",
                schema: "planilla",
                table: "loans",
                newName: "status");

            migrationBuilder.AddColumn<DateTime>(
                name: "processing_date",
                schema: "planilla",
                table: "payrolls",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "total_amount",
                schema: "planilla",
                table: "payrolls",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "total_amount_currency",
                schema: "planilla",
                table: "payrolls",
                type: "character varying(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                schema: "planilla",
                table: "payroll_details",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.AddColumn<decimal>(
                name: "earnings_amount",
                schema: "planilla",
                table: "payroll_details",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "earnings_currency",
                schema: "planilla",
                table: "payroll_details",
                type: "character varying(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "employee_name",
                schema: "planilla",
                table: "payroll_details",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "pay_amount",
                schema: "planilla",
                table: "payroll_details",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "pay_currency",
                schema: "planilla",
                table: "payroll_details",
                type: "character varying(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                schema: "planilla",
                table: "loans",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_payroll_details_EmployeeId",
                schema: "planilla",
                table: "payroll_details",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_payroll_details_employees_EmployeeId",
                schema: "planilla",
                table: "payroll_details",
                column: "EmployeeId",
                principalSchema: "planilla",
                principalTable: "employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_payroll_details_employees_EmployeeId",
                schema: "planilla",
                table: "payroll_details");

            migrationBuilder.DropIndex(
                name: "IX_payroll_details_EmployeeId",
                schema: "planilla",
                table: "payroll_details");

            migrationBuilder.DropColumn(
                name: "processing_date",
                schema: "planilla",
                table: "payrolls");

            migrationBuilder.DropColumn(
                name: "total_amount",
                schema: "planilla",
                table: "payrolls");

            migrationBuilder.DropColumn(
                name: "total_amount_currency",
                schema: "planilla",
                table: "payrolls");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "planilla",
                table: "payroll_details");

            migrationBuilder.DropColumn(
                name: "deductions_amount",
                schema: "planilla",
                table: "payroll_details");

            migrationBuilder.DropColumn(
                name: "deductions_currency",
                schema: "planilla",
                table: "payroll_details");

            migrationBuilder.DropColumn(
                name: "earnings_amount",
                schema: "planilla",
                table: "payroll_details");

            migrationBuilder.DropColumn(
                name: "earnings_currency",
                schema: "planilla",
                table: "payroll_details");

            migrationBuilder.DropColumn(
                name: "employee_name",
                schema: "planilla",
                table: "payroll_details");

            migrationBuilder.DropColumn(
                name: "pay_amount",
                schema: "planilla",
                table: "payroll_details");

            migrationBuilder.DropColumn(
                name: "pay_currency",
                schema: "planilla",
                table: "payroll_details");

            migrationBuilder.RenameColumn(
                name: "status",
                schema: "planilla",
                table: "loans",
                newName: "Status");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                schema: "planilla",
                table: "loans",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateIndex(
                name: "IX_loans_Status",
                schema: "planilla",
                table: "loans",
                column: "Status");
        }
    }
}
