using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kader_System.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FirstMig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Auth_Users",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5basb1",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca095bdc-699d-4a7c-b5ed-5d03a379f699", "MR_MOHAMMED", "AQAAAAIAAYagAAAAECNDuehFxs7lCByaOdZSg661GBkHd0Z2/iBRA6EjPNXJi8G1cJYPUU3+JhE2flZYXQ==", "98c5a41f-c6d2-45c5-b5a7-efecda0e8baf" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Auth_Users",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5basb1",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "914b5be0-1e0a-4d48-9aec-15aadddbb86a", "Mohammed", "AQAAAAIAAYagAAAAEEO3b5f9LvA6fNEhF6Si6M4ofgqxKQ76ySJaW54Dv0pvpHB6eH6nzvymBWS5Tc8/xg==", "6e87e54d-b7b8-44f2-9476-b2d76e771f37" });
        }
    }
}
