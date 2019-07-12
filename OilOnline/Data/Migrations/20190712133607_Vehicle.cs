using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OilOnline.Data.Migrations
{
    public partial class Vehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "Vehicles");

            migrationBuilder.AddColumn<byte[]>(
                name: "VehicleImage",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1e886f14-82b5-49eb-9d83-38f0c2d7655b", "AQAAAAEAACcQAAAAEPfgiCuQLGaCfLDtrz785HTRhSuHho22AXez1Dqc1/0Gi8A1uorcVWKY2vgOwkCnhg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleImage",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "PhotoURL",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a8cdf686-6bab-4c08-bb8b-90fe8bcd733b", "AQAAAAEAACcQAAAAEK1i5dla95tiH91I2dHoZD9S04AUJ39tyJbWAm8JFjMxzSGKek85XxVN4IAKJ4v1Xg==" });
        }
    }
}
