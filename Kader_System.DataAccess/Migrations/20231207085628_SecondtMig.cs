using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kader_System.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SecondtMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hr_Allowances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Hr_Allowances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hr_Benefits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Hr_Benefits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hr_Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company_owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company_type = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Hr_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hr_Companies_Hr_CompanyTypes_Company_type",
                        column: x => x.Company_type,
                        principalTable: "Hr_CompanyTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hr_Deductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Hr_Deductions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hr_Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameInEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hr_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hr_Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Has_need_license = table.Column<bool>(type: "bit", nullable: false),
                    Has_additional_time = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_Hr_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hr_Qualifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Has_additional_time = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_Hr_Qualifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hr_Shifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start_shift = table.Column<TimeOnly>(type: "time", nullable: false),
                    End_shift = table.Column<TimeOnly>(type: "time", nullable: false),
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
                    table.PrimaryKey("PK_Hr_Shifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hr_Vacations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apply_months = table.Column<int>(type: "int", nullable: false),
                    Total_vacation = table.Column<int>(type: "int", nullable: false),
                    Transfer_vacation = table.Column<bool>(type: "bit", nullable: false),
                    Name_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vacation_type = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Hr_Vacations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hr_Vacations_Hr_VacationTypes_Vacation_type",
                        column: x => x.Vacation_type,
                        principalTable: "Hr_VacationTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hr_FingerPrints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ip = table.Column<int>(type: "int", nullable: false),
                    Name_ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Port = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company_id = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Hr_FingerPrints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hr_FingerPrints_Hr_Companies_Company_id",
                        column: x => x.Company_id,
                        principalTable: "Hr_Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hr_Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameInEnglish = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hr_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hr_Sections_Hr_Companies_Company_id",
                        column: x => x.Company_id,
                        principalTable: "Hr_Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hr_Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_name_ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employee_name_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Father_name_ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Father_name_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grand_father_name_ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grand_father_name_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family_name_ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family_name_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fixed_salary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hiring_date = table.Column<DateOnly>(type: "date", nullable: false),
                    Immediately_date = table.Column<DateOnly>(type: "date", nullable: false),
                    Total_salary = table.Column<double>(type: "float", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Children_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employee_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employee_image_extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender_id = table.Column<int>(type: "int", nullable: false),
                    Relegion_id = table.Column<int>(type: "int", nullable: false),
                    SalaryPaymentWay_id = table.Column<int>(type: "int", nullable: false),
                    Shift_id = table.Column<int>(type: "int", nullable: false),
                    Department_id = table.Column<int>(type: "int", nullable: false),
                    Nationality_id = table.Column<int>(type: "int", nullable: false),
                    Qualification_id = table.Column<int>(type: "int", nullable: false),
                    AccountingWay_id = table.Column<int>(type: "int", nullable: false),
                    Vacation_id = table.Column<int>(type: "int", nullable: false),
                    EmployeeType_id = table.Column<int>(type: "int", nullable: false),
                    Job_id = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Hr_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hr_Employees_HrRelegion_Relegion_id",
                        column: x => x.Relegion_id,
                        principalTable: "HrRelegion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hr_Employees_Hr_AccountingWays_AccountingWay_id",
                        column: x => x.AccountingWay_id,
                        principalTable: "Hr_AccountingWays",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hr_Employees_Hr_Departments_Department_id",
                        column: x => x.Department_id,
                        principalTable: "Hr_Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hr_Employees_Hr_EmployeeTypes_EmployeeType_id",
                        column: x => x.EmployeeType_id,
                        principalTable: "Hr_EmployeeTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hr_Employees_Hr_Genders_Gender_id",
                        column: x => x.Gender_id,
                        principalTable: "Hr_Genders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hr_Employees_Hr_Jobs_Job_id",
                        column: x => x.Job_id,
                        principalTable: "Hr_Jobs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hr_Employees_Hr_Nationalities_Nationality_id",
                        column: x => x.Nationality_id,
                        principalTable: "Hr_Nationalities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hr_Employees_Hr_Qualifications_Qualification_id",
                        column: x => x.Qualification_id,
                        principalTable: "Hr_Qualifications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hr_Employees_Hr_SalaryPaymentWays_SalaryPaymentWay_id",
                        column: x => x.SalaryPaymentWay_id,
                        principalTable: "Hr_SalaryPaymentWays",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hr_Employees_Hr_Shifts_Shift_id",
                        column: x => x.Shift_id,
                        principalTable: "Hr_Shifts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hr_Employees_Hr_Vacations_Vacation_id",
                        column: x => x.Vacation_id,
                        principalTable: "Hr_Vacations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hr_VacationDistributions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Days_count = table.Column<int>(type: "int", nullable: false),
                    AccountingWay_id = table.Column<int>(type: "int", nullable: false),
                    Vacation_id = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Hr_VacationDistributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hr_VacationDistributions_Hr_AccountingWays_AccountingWay_id",
                        column: x => x.AccountingWay_id,
                        principalTable: "Hr_AccountingWays",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hr_VacationDistributions_Hr_Vacations_Vacation_id",
                        column: x => x.Vacation_id,
                        principalTable: "Hr_Vacations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hr_SectionDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Section_id = table.Column<int>(type: "int", nullable: false),
                    Department_id = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Hr_SectionDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hr_SectionDepartments_Hr_Departments_Department_id",
                        column: x => x.Department_id,
                        principalTable: "Hr_Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hr_SectionDepartments_Hr_Sections_Section_id",
                        column: x => x.Section_id,
                        principalTable: "Hr_Sections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hr_Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salary_total = table.Column<double>(type: "float", nullable: false),
                    Salary_fixed = table.Column<double>(type: "float", nullable: false),
                    Start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    End_date = table.Column<DateOnly>(type: "date", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Hr_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hr_Contracts_Hr_Employees_Employee_id",
                        column: x => x.Employee_id,
                        principalTable: "Hr_Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hr_EmployeeAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Hr_EmployeeAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hr_EmployeeAttachments_Hr_Employees_Employee_id",
                        column: x => x.Employee_id,
                        principalTable: "Hr_Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tran_SalaryIncreases",
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

            migrationBuilder.CreateTable(
                name: "Trans_Allowances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action_month = table.Column<DateOnly>(type: "date", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Salary_effect_id = table.Column<int>(type: "int", nullable: false),
                    Employee_id = table.Column<int>(type: "int", nullable: false),
                    Allowance_id = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Trans_Allowances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trans_Allowances_Hr_Allowances_Allowance_id",
                        column: x => x.Allowance_id,
                        principalTable: "Hr_Allowances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trans_Allowances_Hr_Employees_Employee_id",
                        column: x => x.Employee_id,
                        principalTable: "Hr_Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trans_Allowances_Trans_SalaryEffects_Salary_effect_id",
                        column: x => x.Salary_effect_id,
                        principalTable: "Trans_SalaryEffects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trans_Benefits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action_month = table.Column<DateOnly>(type: "date", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachmentExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value_type = table.Column<int>(type: "int", nullable: false),
                    Salary_effect_id = table.Column<int>(type: "int", nullable: false),
                    Employee_id = table.Column<int>(type: "int", nullable: false),
                    Benefit_id = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Trans_Benefits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trans_Benefits_Hr_Benefits_Benefit_id",
                        column: x => x.Benefit_id,
                        principalTable: "Hr_Benefits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trans_Benefits_Hr_Employees_Employee_id",
                        column: x => x.Employee_id,
                        principalTable: "Hr_Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trans_Benefits_Trans_AmountTypes_Value_type",
                        column: x => x.Value_type,
                        principalTable: "Trans_AmountTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trans_Benefits_Trans_SalaryEffects_Salary_effect_id",
                        column: x => x.Salary_effect_id,
                        principalTable: "Trans_SalaryEffects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trans_Covenants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Covenant_amount = table.Column<double>(type: "float", nullable: false),
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
                    table.PrimaryKey("PK_Trans_Covenants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trans_Covenants_Hr_Employees_Employee_id",
                        column: x => x.Employee_id,
                        principalTable: "Hr_Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trans_Deductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action_month = table.Column<DateOnly>(type: "date", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachmentExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value_type = table.Column<int>(type: "int", nullable: false),
                    Salary_effect_id = table.Column<int>(type: "int", nullable: false),
                    Employee_id = table.Column<int>(type: "int", nullable: false),
                    Deduction_id = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Trans_Deductions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trans_Deductions_Hr_Deductions_Deduction_id",
                        column: x => x.Deduction_id,
                        principalTable: "Hr_Deductions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trans_Deductions_Hr_Employees_Employee_id",
                        column: x => x.Employee_id,
                        principalTable: "Hr_Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trans_Deductions_Trans_AmountTypes_Value_type",
                        column: x => x.Value_type,
                        principalTable: "Trans_AmountTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trans_Deductions_Trans_SalaryEffects_Salary_effect_id",
                        column: x => x.Salary_effect_id,
                        principalTable: "Trans_SalaryEffects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trans_Vacations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    Days_count = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employee_id = table.Column<int>(type: "int", nullable: false),
                    Vacation_system_d_id = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Trans_Vacations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trans_Vacations_Hr_Employees_Employee_id",
                        column: x => x.Employee_id,
                        principalTable: "Hr_Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trans_Vacations_Hr_Vacations_Vacation_system_d_id",
                        column: x => x.Vacation_system_d_id,
                        principalTable: "Hr_Vacations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hr_ContractAllowancesDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Value_type = table.Column<int>(type: "int", nullable: false),
                    Salary_effect_id = table.Column<int>(type: "int", nullable: false),
                    Contract_id = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Hr_ContractAllowancesDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hr_ContractAllowancesDetails_Hr_Allowances_Salary_effect_id",
                        column: x => x.Salary_effect_id,
                        principalTable: "Hr_Allowances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hr_ContractAllowancesDetails_Hr_Contracts_Contract_id",
                        column: x => x.Contract_id,
                        principalTable: "Hr_Contracts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hr_ContractAllowancesDetails_Hr_ValueTypes_Value_type",
                        column: x => x.Value_type,
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
                name: "IX_Hr_Companies_Company_type",
                table: "Hr_Companies",
                column: "Company_type");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_ContractAllowancesDetails_Contract_id",
                table: "Hr_ContractAllowancesDetails",
                column: "Contract_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_ContractAllowancesDetails_Salary_effect_id",
                table: "Hr_ContractAllowancesDetails",
                column: "Salary_effect_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_ContractAllowancesDetails_Value_type",
                table: "Hr_ContractAllowancesDetails",
                column: "Value_type");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Contracts_Employee_id",
                table: "Hr_Contracts",
                column: "Employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_EmployeeAttachments_Employee_id",
                table: "Hr_EmployeeAttachments",
                column: "Employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Employees_AccountingWay_id",
                table: "Hr_Employees",
                column: "AccountingWay_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Employees_Department_id",
                table: "Hr_Employees",
                column: "Department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Employees_EmployeeType_id",
                table: "Hr_Employees",
                column: "EmployeeType_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Employees_Gender_id",
                table: "Hr_Employees",
                column: "Gender_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Employees_Job_id",
                table: "Hr_Employees",
                column: "Job_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Employees_Nationality_id",
                table: "Hr_Employees",
                column: "Nationality_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Employees_Qualification_id",
                table: "Hr_Employees",
                column: "Qualification_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Employees_Relegion_id",
                table: "Hr_Employees",
                column: "Relegion_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Employees_SalaryPaymentWay_id",
                table: "Hr_Employees",
                column: "SalaryPaymentWay_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Employees_Shift_id",
                table: "Hr_Employees",
                column: "Shift_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Employees_Vacation_id",
                table: "Hr_Employees",
                column: "Vacation_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_FingerPrints_Company_id",
                table: "Hr_FingerPrints",
                column: "Company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_SectionDepartments_Department_id",
                table: "Hr_SectionDepartments",
                column: "Department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_SectionDepartments_Section_id",
                table: "Hr_SectionDepartments",
                column: "Section_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Sections_Company_id",
                table: "Hr_Sections",
                column: "Company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_VacationDistributions_AccountingWay_id",
                table: "Hr_VacationDistributions",
                column: "AccountingWay_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_VacationDistributions_Vacation_id",
                table: "Hr_VacationDistributions",
                column: "Vacation_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Vacations_Vacation_type",
                table: "Hr_Vacations",
                column: "Vacation_type");

            migrationBuilder.CreateIndex(
                name: "IX_Tran_SalaryIncreases_Employee_id",
                table: "Tran_SalaryIncreases",
                column: "Employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Tran_SalaryIncreases_Increase_type",
                table: "Tran_SalaryIncreases",
                column: "Increase_type");

            migrationBuilder.CreateIndex(
                name: "IX_Trans_Allowances_Allowance_id",
                table: "Trans_Allowances",
                column: "Allowance_id");

            migrationBuilder.CreateIndex(
                name: "IX_Trans_Allowances_Employee_id",
                table: "Trans_Allowances",
                column: "Employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Trans_Allowances_Salary_effect_id",
                table: "Trans_Allowances",
                column: "Salary_effect_id");

            migrationBuilder.CreateIndex(
                name: "IX_Trans_Benefits_Benefit_id",
                table: "Trans_Benefits",
                column: "Benefit_id");

            migrationBuilder.CreateIndex(
                name: "IX_Trans_Benefits_Employee_id",
                table: "Trans_Benefits",
                column: "Employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Trans_Benefits_Salary_effect_id",
                table: "Trans_Benefits",
                column: "Salary_effect_id");

            migrationBuilder.CreateIndex(
                name: "IX_Trans_Benefits_Value_type",
                table: "Trans_Benefits",
                column: "Value_type");

            migrationBuilder.CreateIndex(
                name: "IX_Trans_Covenants_Employee_id",
                table: "Trans_Covenants",
                column: "Employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Trans_Deductions_Deduction_id",
                table: "Trans_Deductions",
                column: "Deduction_id");

            migrationBuilder.CreateIndex(
                name: "IX_Trans_Deductions_Employee_id",
                table: "Trans_Deductions",
                column: "Employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Trans_Deductions_Salary_effect_id",
                table: "Trans_Deductions",
                column: "Salary_effect_id");

            migrationBuilder.CreateIndex(
                name: "IX_Trans_Deductions_Value_type",
                table: "Trans_Deductions",
                column: "Value_type");

            migrationBuilder.CreateIndex(
                name: "IX_Trans_Vacations_Employee_id",
                table: "Trans_Vacations",
                column: "Employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Trans_Vacations_Vacation_system_d_id",
                table: "Trans_Vacations",
                column: "Vacation_system_d_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hr_ContractAllowancesDetails");

            migrationBuilder.DropTable(
                name: "Hr_EmployeeAttachments");

            migrationBuilder.DropTable(
                name: "Hr_FingerPrints");

            migrationBuilder.DropTable(
                name: "Hr_SectionDepartments");

            migrationBuilder.DropTable(
                name: "Hr_VacationDistributions");

            migrationBuilder.DropTable(
                name: "Tran_SalaryIncreases");

            migrationBuilder.DropTable(
                name: "Trans_Allowances");

            migrationBuilder.DropTable(
                name: "Trans_Benefits");

            migrationBuilder.DropTable(
                name: "Trans_Covenants");

            migrationBuilder.DropTable(
                name: "Trans_Deductions");

            migrationBuilder.DropTable(
                name: "Trans_Vacations");

            migrationBuilder.DropTable(
                name: "Hr_Contracts");

            migrationBuilder.DropTable(
                name: "Hr_Sections");

            migrationBuilder.DropTable(
                name: "Hr_Allowances");

            migrationBuilder.DropTable(
                name: "Hr_Benefits");

            migrationBuilder.DropTable(
                name: "Hr_Deductions");

            migrationBuilder.DropTable(
                name: "Hr_Employees");

            migrationBuilder.DropTable(
                name: "Hr_Companies");

            migrationBuilder.DropTable(
                name: "Hr_Departments");

            migrationBuilder.DropTable(
                name: "Hr_Jobs");

            migrationBuilder.DropTable(
                name: "Hr_Qualifications");

            migrationBuilder.DropTable(
                name: "Hr_Shifts");

            migrationBuilder.DropTable(
                name: "Hr_Vacations");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Auth_Users",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5basb1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1e648ca-31a0-4780-937f-38500ea0f5af", "AQAAAAIAAYagAAAAEEd5pzrfXaSqJWAi3h/VbQjO1QtBFPHb7udg7GmHlnEurEj4/tny7YvvwJNH6SLKDQ==", "f62e35a7-4e71-4525-beed-012060b975b9" });
        }
    }
}
