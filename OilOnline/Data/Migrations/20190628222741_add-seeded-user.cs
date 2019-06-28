using Microsoft.EntityFrameworkCore.Migrations;

namespace OilOnline.Data.Migrations
{
    public partial class addseededuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Description", "FirstName", "IsMechanic", "LastName", "PhotoURL" },
                values: new object[] { "00000000-ffff-ffff-ffff-ffffffffffff", 0, "e3b07e33-1e7c-4bbf-a91e-8c6b53a92b96", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEOt9ZS8YM1yMye6rGdQWXCZ6ZMogzQxRK+cEXdiJsJyHDxi7CFUJZ1dEao1ZtPcf3Q==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", false, "admin@admin.com", null, "Admina", false, "Straytor", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff");
        }
    }
}
