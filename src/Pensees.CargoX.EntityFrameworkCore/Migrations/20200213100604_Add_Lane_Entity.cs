using Microsoft.EntityFrameworkCore.Migrations;

namespace Pensees.CargoX.Migrations
{
    public partial class Add_Lane_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lanes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TollgateId = table.Column<string>(maxLength: 20, nullable: false),
                    LaneId = table.Column<int>(nullable: false),
                    LaneNo = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Direction = table.Column<string>(maxLength: 1, nullable: false),
                    Desc = table.Column<string>(maxLength: 256, nullable: true),
                    MaxSpeed = table.Column<int>(nullable: false),
                    CityPass = table.Column<int>(nullable: false),
                    ApeId = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lanes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lanes");
        }
    }
}
