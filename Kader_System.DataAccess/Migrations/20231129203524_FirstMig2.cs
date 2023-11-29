using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kader_System.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FirstMig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title_name_en",
                schema: "dbo",
                table: "Auth_Roles",
                newName: "Title_name_ar");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Auth_Roles",
                keyColumn: "Id",
                keyValue: "fab4fac1-c546-41de-aebc-a14da68957ab1",
                columns: new[] { "Name", "Title_name_ar" },
                values: new object[] { "Superadmin", "سوبر أدمن" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Auth_Users",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5basb1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e862278-0233-450c-91c9-87a831ade600", "AQAAAAIAAYagAAAAEI9b/69ua+Nc7UKcSdNCqZtNQX3eFTKzduA+dqWk3YnxwPBy1f2MLkGd58lbRWmp7w==", "6f245b26-e35f-4fb1-be4f-9e22668f3903" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title_name_ar",
                schema: "dbo",
                table: "Auth_Roles",
                newName: "Title_name_en");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Auth_Roles",
                keyColumn: "Id",
                keyValue: "fab4fac1-c546-41de-aebc-a14da68957ab1",
                columns: new[] { "Name", "Title_name_en" },
                values: new object[] { "سوبر أدمن", "Superadmin" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Auth_Users",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5basb1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca095bdc-699d-4a7c-b5ed-5d03a379f699", "AQAAAAIAAYagAAAAECNDuehFxs7lCByaOdZSg661GBkHd0Z2/iBRA6EjPNXJi8G1cJYPUU3+JhE2flZYXQ==", "98c5a41f-c6d2-45c5-b5a7-efecda0e8baf" });
        }
    }
}
