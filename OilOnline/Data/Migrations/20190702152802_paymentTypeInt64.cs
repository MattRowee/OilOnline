using Microsoft.EntityFrameworkCore.Migrations;

namespace OilOnline.Data.Migrations
{
    public partial class paymentTypeInt64 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CardNumber",
                table: "PaymentTypes",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a8cdf686-6bab-4c08-bb8b-90fe8bcd733b", "AQAAAAEAACcQAAAAEK1i5dla95tiH91I2dHoZD9S04AUJ39tyJbWAm8JFjMxzSGKek85XxVN4IAKJ4v1Xg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CardNumber",
                table: "PaymentTypes",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ab0ab3c6-edaa-4c35-a98c-4dfa88ebc170", "AQAAAAEAACcQAAAAEOWKooZiAKAEEAvqSAVAOzqdVjD7OdRX6VIn82Hh5HWsxWDFaF2j55Hg0vL9p7qyjA==" });
        }
    }
}
