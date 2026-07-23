using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EM.Planilla.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class misnuevoscambios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "planilla");

            migrationBuilder.CreateTable(
                name: "employees",
                schema: "planilla",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    document_type = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    document_number = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    HireDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    amount_salary = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "payrolls",
                schema: "planilla",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    month = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    year = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payrolls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loans",
                schema: "planilla",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount_currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    term_months = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    reason_status = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_loans_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "planilla",
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "payroll_details",
                schema: "planilla",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PayrollId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payroll_details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_payroll_details_payrolls_PayrollId",
                        column: x => x.PayrollId,
                        principalSchema: "planilla",
                        principalTable: "payrolls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employees_document_type_document_number",
                schema: "planilla",
                table: "employees",
                columns: new[] { "document_type", "document_number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_loans_EmployeeId",
                schema: "planilla",
                table: "loans",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_loans_Status",
                schema: "planilla",
                table: "loans",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_payroll_details_PayrollId",
                schema: "planilla",
                table: "payroll_details",
                column: "PayrollId");

            migrationBuilder.CreateIndex(
                name: "IX_payrolls_status",
                schema: "planilla",
                table: "payrolls",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_payrolls_year_month",
                schema: "planilla",
                table: "payrolls",
                columns: new[] { "year", "month" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "loans",
                schema: "planilla");

            migrationBuilder.DropTable(
                name: "payroll_details",
                schema: "planilla");

            migrationBuilder.DropTable(
                name: "employees",
                schema: "planilla");

            migrationBuilder.DropTable(
                name: "payrolls",
                schema: "planilla");
        }
    }
}
