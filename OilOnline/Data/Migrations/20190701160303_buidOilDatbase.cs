using Microsoft.EntityFrameworkCore.Migrations;

namespace OilOnline.Data.Migrations
{
    public partial class buidOilDatbase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b4940d76-73a7-46c8-8aeb-cb34c313153d", "AQAAAAEAACcQAAAAEEN3MNRjF7ttzXUrQMcgc7JcqkNKLh/5GJyskvZhoNwIDQGKmsVnR707j3nOYgPMsw==" });

            migrationBuilder.InsertData(
                table: "OilTypes",
                columns: new[] { "Id", "Name", "PricePerQuart" },
                values: new object[,]
                {
                    { 1, "Conventional", 20.0 },
                    { 2, "Full Synthetic", 24.0 },
                    { 3, "Synthetic Blend", 20.0 },
                    { 4, "High Mileage", 21.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OilTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OilTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OilTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OilTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e3b07e33-1e7c-4bbf-a91e-8c6b53a92b96", "AQAAAAEAACcQAAAAEOt9ZS8YM1yMye6rGdQWXCZ6ZMogzQxRK+cEXdiJsJyHDxi7CFUJZ1dEao1ZtPcf3Q==" });
        }
    }
}
