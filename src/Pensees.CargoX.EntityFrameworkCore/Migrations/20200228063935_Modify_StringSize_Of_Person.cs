using Microsoft.EntityFrameworkCore.Migrations;

namespace Pensees.CargoX.Migrations
{
    public partial class Modify_StringSize_Of_Person : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BehaviorDescription",
                table: "Persons",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppendantDescription",
                table: "Persons",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Appendant",
                table: "Persons",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2) CHARACTER SET utf8mb4",
                oldMaxLength: 2,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BehaviorDescription",
                table: "Persons",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppendantDescription",
                table: "Persons",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Appendant",
                table: "Persons",
                type: "varchar(2) CHARACTER SET utf8mb4",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);
        }
    }
}
