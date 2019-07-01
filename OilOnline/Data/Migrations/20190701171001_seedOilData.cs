using Microsoft.EntityFrameworkCore.Migrations;

namespace OilOnline.Data.Migrations
{
    public partial class seedOilData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ab0ab3c6-edaa-4c35-a98c-4dfa88ebc170", "AQAAAAEAACcQAAAAEOWKooZiAKAEEAvqSAVAOzqdVjD7OdRX6VIn82Hh5HWsxWDFaF2j55Hg0vL9p7qyjA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b4940d76-73a7-46c8-8aeb-cb34c313153d", "AQAAAAEAACcQAAAAEEN3MNRjF7ttzXUrQMcgc7JcqkNKLh/5GJyskvZhoNwIDQGKmsVnR707j3nOYgPMsw==" });
        }
    }
}
