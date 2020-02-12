using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pensees.CargoX.Migrations
{
    public partial class Add_Tollgate_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tollgates",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TollgateId = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    PlaceCode = table.Column<string>(maxLength: 6, nullable: false),
                    Place = table.Column<string>(maxLength: 256, nullable: true),
                    Status = table.Column<string>(maxLength: 1, nullable: false),
                    TollgateCat = table.Column<string>(maxLength: 2, nullable: false),
                    TollgateCat2 = table.Column<int>(nullable: false),
                    LaneNum = table.Column<int>(nullable: false),
                    OrgCode = table.Column<string>(maxLength: 12, nullable: true),
                    ActiveTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tollgates", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tollgates");
        }
    }
}
