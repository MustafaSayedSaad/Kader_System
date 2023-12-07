using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kader_System.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SecondtMig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tran_SalaryIncreases");

            migrationBuilder.CreateTable(
                name: "Trans_SalaryIncreases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Increase_type = table.Column<int>(type: "int", nullable: false),
                    Employee_id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_SalaryIncreases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trans_SalaryIncreases_Hr_Employees_Employee_id",
                        column: x => x.Employee_id,
                        principalTable: "Hr_Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trans_SalaryIncreases_Hr_ValueTypes_Increase_type",
                        column: x => x.Increase_type,
                        principalTable: "Hr_ValueTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Auth_Users",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5basb1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aef5203a-9a24-400d-9e7d-3bc210ab345e", "AQAAAAIAAYagAAAAEGpsmwFuOpOySB6FPCtnLqpWFxV8OC3qeiS0D/AyINnLaQ0DRjFKJ3RLaA8B9B8NAA==", "ba371f68-9714-4534-91d7-2cee6f0af117" });

            migrationBuilder.CreateIndex(
                name: "IX_Trans_SalaryIncreases_Employee_id",
                table: "Trans_SalaryIncreases",
                column: "Employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Trans_SalaryIncreases_Increase_type",
                table: "Trans_SalaryIncreases",
                column: "Increase_type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trans_SalaryIncreases");

            migrationBuilder.CreateTable(
                name: "Tran_SalaryIncreases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_id = table.Column<int>(type: "int", nullable: false),
                    Increase_type = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    DeleteBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tran_SalaryIncreases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tran_SalaryIncreases_Hr_Employees_Employee_id",
                        column: x => x.Employee_id,
                        principalTable: "Hr_Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tran_SalaryIncreases_Hr_ValueTypes_Increase_type",
                        column: x => x.Increase_type,
                        principalTable: "Hr_ValueTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Auth_Users",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5basb1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ffb8319c-c438-4911-a55c-5d867de1d734", "AQAAAAIAAYagAAAAEGlBbpIfd0W7AJYzXuedezuFs5m9xoAG32b7zBsbEp7VpFewio1I4rRDueAXrbaZ6A==", "f8a123fe-4469-411e-94d0-b798ccd643c8" });

            migrationBuilder.CreateIndex(
                name: "IX_Tran_SalaryIncreases_Employee_id",
                table: "Tran_SalaryIncreases",
                column: "Employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tran_SalaryIncreases_Increase_type",
                table: "Tran_SalaryIncreases",
                column: "Increase_type");
        }
    }
}
