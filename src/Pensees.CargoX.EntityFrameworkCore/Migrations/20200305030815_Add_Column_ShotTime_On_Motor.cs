using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pensees.CargoX.Migrations
{
    public partial class Add_Column_ShotTime_On_Motor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ShotTime",
                table: "Motors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShotTime",
                table: "Motors");
        }
    }
}
