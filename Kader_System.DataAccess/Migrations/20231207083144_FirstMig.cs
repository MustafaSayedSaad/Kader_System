using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kader_System.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FirstMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Auth_Roles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title_name_ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Auth_Users",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    VisiblePassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Com_Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogType = table.Column<int>(type: "int", nullable: false),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExceptionPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExceptionInnerPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InnerException = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Com_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hr_AccountingWays",
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
                    table.PrimaryKey("PK_Hr_AccountingWays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hr_CompanyTypes",
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
                    table.PrimaryKey("PK_Hr_CompanyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hr_EmployeeTypes",
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
                    table.PrimaryKey("PK_Hr_EmployeeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hr_Genders",
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
                    table.PrimaryKey("PK_Hr_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hr_MaritalStatus",
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
                    table.PrimaryKey("PK_Hr_MaritalStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hr_MilitaryStatus",
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
                    table.PrimaryKey("PK_Hr_MilitaryStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hr_Nationalities",
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
                    table.PrimaryKey("PK_Hr_Nationalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hr_SalaryPaymentWays",
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
                    table.PrimaryKey("PK_Hr_SalaryPaymentWays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hr_VacationTypes",
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
                    table.PrimaryKey("PK_Hr_VacationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hr_ValueTypes",
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
                    table.PrimaryKey("PK_Hr_ValueTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HrRelegion",
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
                    table.PrimaryKey("PK_HrRelegion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "St_Actions",
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
                    table.PrimaryKey("PK_St_Actions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "St_MainScreenCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Screen_main_title_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Screen_main_title_ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Screen_main_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_St_MainScreenCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_AmountTypes",
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
                    table.PrimaryKey("PK_Trans_AmountTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_SalaryEffects",
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
                    table.PrimaryKey("PK_Trans_SalaryEffects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Auth_RoleClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auth_RoleClaims_Auth_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Auth_Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Auth_RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiresOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevokedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    table.PrimaryKey("PK_Auth_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auth_RefreshTokens_Auth_Users_User_Id",
                        column: x => x.User_Id,
                        principalSchema: "dbo",
                        principalTable: "Auth_Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Auth_UserClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auth_UserClaims_Auth_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Auth_Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Auth_UserDevices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    table.PrimaryKey("PK_Auth_UserDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auth_UserDevices_Auth_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Auth_Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Auth_UserLogins",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_Auth_UserLogins_Auth_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Auth_Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Auth_UserRoles",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    table.PrimaryKey("PK_Auth_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_Auth_UserRoles_Auth_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Auth_Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Auth_UserRoles_Auth_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Auth_Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Auth_UserTokens",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_Auth_UserTokens_Auth_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Auth_Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "St_MainScreens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Screen_cat_title_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Screen_cat_title_ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Screen_cat_id = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_St_MainScreens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_St_MainScreens_St_MainScreenCategories_Screen_cat_id",
                        column: x => x.Screen_cat_id,
                        principalTable: "St_MainScreenCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "St_SubMainScreens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Screen_sub_title_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Screen_sub_title_ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Screen_main_id = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_St_SubMainScreens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_St_SubMainScreens_St_MainScreens_Screen_main_id",
                        column: x => x.Screen_main_id,
                        principalTable: "St_MainScreens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "St_SubMainScreenActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubMainScreenId = table.Column<int>(type: "int", nullable: false),
                    ActionId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_St_SubMainScreenActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_St_SubMainScreenActions_St_Actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "St_Actions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_St_SubMainScreenActions_St_SubMainScreens_SubMainScreenId",
                        column: x => x.SubMainScreenId,
                        principalTable: "St_SubMainScreens",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Auth_Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "DeleteBy", "DeleteDate", "InsertBy", "InsertDate", "IsActive", "IsDeleted", "Name", "NormalizedName", "Title_name_ar", "UpdateBy", "UpdateDate" },
                values: new object[] { "fab4fac1-c546-41de-aebc-a14da68957ab1", "1", null, null, null, null, true, false, "Superadmin", "SUPERADMIN", "سوبر أدمن", null, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Auth_Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DeleteBy", "DeleteDate", "Email", "EmailConfirmed", "InsertBy", "InsertDate", "IsActive", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdateBy", "UpdateDate", "UserName", "VisiblePassword" },
                values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5basb1", 0, "a1e648ca-31a0-4780-937f-38500ea0f5af", null, null, "mohammed88@gmail.com", true, null, null, true, false, false, null, "MOHAMMED88@GMAIL.COM", "MR_MOHAMMED", "AQAAAAIAAYagAAAAEEd5pzrfXaSqJWAi3h/VbQjO1QtBFPHb7udg7GmHlnEurEj4/tny7YvvwJNH6SLKDQ==", null, false, "f62e35a7-4e71-4525-beed-012060b975b9", false, null, null, "Mr_Mohammed", "Mohammed88" });

            migrationBuilder.InsertData(
                table: "HrRelegion",
                columns: new[] { "Id", "DeleteBy", "DeleteDate", "InsertBy", "InsertDate", "IsActive", "IsDeleted", "Name", "NameInEnglish", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, null, null, null, true, false, "مسلم", "Muslim", null, null },
                    { 2, null, null, null, null, true, false, "مسيحى", "Christian", null, null },
                    { 3, null, null, null, null, true, false, "غير ذلك", "Otherwise", null, null }
                });

            migrationBuilder.InsertData(
                table: "Hr_AccountingWays",
                columns: new[] { "Id", "DeleteBy", "DeleteDate", "InsertBy", "InsertDate", "IsActive", "IsDeleted", "Name", "NameInEnglish", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, null, null, null, true, false, "كل الاتب", "All salary", null, null },
                    { 2, null, null, null, null, true, false, "الراتب الرئيسى", "Main salary", null, null },
                    { 3, null, null, null, null, true, false, "بدون راتب", "Without salary", null, null }
                });

            migrationBuilder.InsertData(
                table: "Hr_CompanyTypes",
                columns: new[] { "Id", "DeleteBy", "DeleteDate", "InsertBy", "InsertDate", "IsActive", "IsDeleted", "Name", "NameInEnglish", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, null, null, null, true, false, "شركة", "Company", null, null },
                    { 2, null, null, null, null, true, false, "مؤسسة", "Corporate", null, null }
                });

            migrationBuilder.InsertData(
                table: "Hr_EmployeeTypes",
                columns: new[] { "Id", "DeleteBy", "DeleteDate", "InsertBy", "InsertDate", "IsActive", "IsDeleted", "Name", "NameInEnglish", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, null, null, null, true, false, "مقيم", "Resident", null, null },
                    { 2, null, null, null, null, true, false, "مواطن", "Citizen", null, null }
                });

            migrationBuilder.InsertData(
                table: "Hr_Genders",
                columns: new[] { "Id", "DeleteBy", "DeleteDate", "InsertBy", "InsertDate", "IsActive", "IsDeleted", "Name", "NameInEnglish", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, null, null, null, true, false, "ذكر", "Male", null, null },
                    { 2, null, null, null, null, true, false, "أنثى", "Female", null, null }
                });

            migrationBuilder.InsertData(
                table: "Hr_MaritalStatus",
                columns: new[] { "Id", "DeleteBy", "DeleteDate", "InsertBy", "InsertDate", "IsActive", "IsDeleted", "Name", "NameInEnglish", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, null, null, null, true, false, "أعزب", "Single", null, null },
                    { 2, null, null, null, null, true, false, "خاطب", "Engaged", null, null },
                    { 3, null, null, null, null, true, false, "متزوج", "Married", null, null },
                    { 4, null, null, null, null, true, false, "مطللق", "Divorced", null, null }
                });

            migrationBuilder.InsertData(
                table: "Hr_MilitaryStatus",
                columns: new[] { "Id", "DeleteBy", "DeleteDate", "InsertBy", "InsertDate", "IsActive", "IsDeleted", "Name", "NameInEnglish", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, null, null, null, true, false, "معفى", "Exempt", null, null },
                    { 2, null, null, null, null, true, false, "مؤجل", "Delayed", null, null },
                    { 3, null, null, null, null, true, false, "انهى الخدمة", "Completed", null, null }
                });

            migrationBuilder.InsertData(
                table: "Hr_Nationalities",
                columns: new[] { "Id", "DeleteBy", "DeleteDate", "InsertBy", "InsertDate", "IsActive", "IsDeleted", "Name", "NameInEnglish", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, null, null, null, true, false, "مصرى", "Egyptian ", null, null },
                    { 2, null, null, null, null, true, false, "سعودى", "Saudian", null, null }
                });

            migrationBuilder.InsertData(
                table: "Hr_SalaryPaymentWays",
                columns: new[] { "Id", "DeleteBy", "DeleteDate", "InsertBy", "InsertDate", "IsActive", "IsDeleted", "Name", "NameInEnglish", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, null, null, null, true, false, "بنكى", "Bank", null, null },
                    { 2, null, null, null, null, true, false, "نقدى", "Cash", null, null },
                    { 3, null, null, null, null, true, false, "حوالة مالية", "Money transfer", null, null }
                });

            migrationBuilder.InsertData(
                table: "Hr_VacationTypes",
                columns: new[] { "Id", "DeleteBy", "DeleteDate", "InsertBy", "InsertDate", "IsActive", "IsDeleted", "Name", "NameInEnglish", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, null, null, null, true, false, "عام كامل", "Full year", null, null },
                    { 2, null, null, null, null, true, false, "من تاريخ التعيين", "From hiring date", null, null },
                    { 3, null, null, null, null, true, false, "من تاريخ الاستحقاق", "After hiring days", null, null }
                });

            migrationBuilder.InsertData(
                table: "Hr_ValueTypes",
                columns: new[] { "Id", "DeleteBy", "DeleteDate", "InsertBy", "InsertDate", "IsActive", "IsDeleted", "Name", "NameInEnglish", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, null, null, null, true, false, "مبلغ", "Percent", null, null },
                    { 2, null, null, null, null, true, false, "نسبة", "Amount", null, null }
                });

            migrationBuilder.InsertData(
                table: "St_Actions",
                columns: new[] { "Id", "DeleteBy", "DeleteDate", "InsertBy", "InsertDate", "IsActive", "IsDeleted", "Name", "NameInEnglish", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, null, null, null, true, false, "إظهار", "View", null, null },
                    { 2, null, null, null, null, true, false, "اضافة", "Add", null, null },
                    { 3, null, null, null, null, true, false, "تعديل", "Edit", null, null },
                    { 4, null, null, null, null, true, false, "حذف", "Delete", null, null },
                    { 5, null, null, null, null, true, false, "حذف نهائى", "ForceDelete", null, null },
                    { 6, null, null, null, null, true, false, "طباعة", "Ptint", null, null }
                });

            migrationBuilder.InsertData(
                table: "Trans_AmountTypes",
                columns: new[] { "Id", "DeleteBy", "DeleteDate", "InsertBy", "InsertDate", "IsActive", "IsDeleted", "Name", "NameInEnglish", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, null, null, null, true, false, "ساعة", "Hour", null, null },
                    { 2, null, null, null, null, true, false, "أيام عمل", "Work days", null, null },
                    { 3, null, null, null, null, true, false, "القيمة", "Value", null, null }
                });

            migrationBuilder.InsertData(
                table: "Trans_SalaryEffects",
                columns: new[] { "Id", "DeleteBy", "DeleteDate", "InsertBy", "InsertDate", "IsActive", "IsDeleted", "Name", "NameInEnglish", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, null, null, null, true, false, "قطعى", "On time", null, null },
                    { 2, null, null, null, null, true, false, "شهرى", "Monthly", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Auth_UserRoles",
                columns: new[] { "RoleId", "UserId", "DeleteBy", "DeleteDate", "InsertBy", "InsertDate", "IsActive", "IsDeleted", "UpdateBy", "UpdateDate" },
                values: new object[] { "fab4fac1-c546-41de-aebc-a14da68957ab1", "b74ddd14-6340-4840-95c2-db12554843e5basb1", null, null, null, null, true, false, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Auth_RefreshTokens_User_Id",
                table: "Auth_RefreshTokens",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Auth_RoleClaims_RoleId",
                schema: "dbo",
                table: "Auth_RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "Auth_Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Auth_UserClaims_UserId",
                schema: "dbo",
                table: "Auth_UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Auth_UserDevices_UserId",
                table: "Auth_UserDevices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Auth_UserLogins_UserId",
                schema: "dbo",
                table: "Auth_UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Auth_UserRoles_RoleId",
                schema: "dbo",
                table: "Auth_UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "Auth_Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "Auth_Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_St_MainScreens_Screen_cat_id",
                table: "St_MainScreens",
                column: "Screen_cat_id");

            migrationBuilder.CreateIndex(
                name: "IX_St_SubMainScreenActions_ActionId",
                table: "St_SubMainScreenActions",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_St_SubMainScreenActions_SubMainScreenId",
                table: "St_SubMainScreenActions",
                column: "SubMainScreenId");

            migrationBuilder.CreateIndex(
                name: "IX_St_SubMainScreens_Screen_main_id",
                table: "St_SubMainScreens",
                column: "Screen_main_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auth_RefreshTokens");

            migrationBuilder.DropTable(
                name: "Auth_RoleClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Auth_UserClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Auth_UserDevices");

            migrationBuilder.DropTable(
                name: "Auth_UserLogins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Auth_UserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Auth_UserTokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Com_Logs");

            migrationBuilder.DropTable(
                name: "Hr_AccountingWays");

            migrationBuilder.DropTable(
                name: "Hr_CompanyTypes");

            migrationBuilder.DropTable(
                name: "Hr_EmployeeTypes");

            migrationBuilder.DropTable(
                name: "Hr_Genders");

            migrationBuilder.DropTable(
                name: "Hr_MaritalStatus");

            migrationBuilder.DropTable(
                name: "Hr_MilitaryStatus");

            migrationBuilder.DropTable(
                name: "Hr_Nationalities");

            migrationBuilder.DropTable(
                name: "Hr_SalaryPaymentWays");

            migrationBuilder.DropTable(
                name: "Hr_VacationTypes");

            migrationBuilder.DropTable(
                name: "Hr_ValueTypes");

            migrationBuilder.DropTable(
                name: "HrRelegion");

            migrationBuilder.DropTable(
                name: "St_SubMainScreenActions");

            migrationBuilder.DropTable(
                name: "Trans_AmountTypes");

            migrationBuilder.DropTable(
                name: "Trans_SalaryEffects");

            migrationBuilder.DropTable(
                name: "Auth_Roles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Auth_Users",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "St_Actions");

            migrationBuilder.DropTable(
                name: "St_SubMainScreens");

            migrationBuilder.DropTable(
                name: "St_MainScreens");

            migrationBuilder.DropTable(
                name: "St_MainScreenCategories");
        }
    }
}
