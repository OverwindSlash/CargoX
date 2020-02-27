using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pensees.CargoX.Migrations
{
    public partial class Add_Person_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PersonId",
                table: "SubImageInfo",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonID = table.Column<string>(maxLength: 48, nullable: false),
                    InfoType = table.Column<int>(nullable: false),
                    SourceID = table.Column<string>(maxLength: 41, nullable: false),
                    DeviceID = table.Column<string>(maxLength: 20, nullable: true),
                    LeftTopX = table.Column<int>(nullable: false),
                    LeftTopY = table.Column<int>(nullable: false),
                    RightBtmX = table.Column<int>(nullable: false),
                    RightBtmY = table.Column<int>(nullable: false),
                    LocationMarkTime = table.Column<DateTime>(nullable: false),
                    PersonAppearTime = table.Column<DateTime>(nullable: false),
                    PersonDisAppearTime = table.Column<DateTime>(nullable: false),
                    IDType = table.Column<string>(maxLength: 3, nullable: true),
                    IDNumber = table.Column<string>(maxLength: 30, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    UsedName = table.Column<string>(maxLength: 50, nullable: true),
                    Alias = table.Column<string>(maxLength: 50, nullable: true),
                    GenderCode = table.Column<string>(nullable: true),
                    AgeUpLimit = table.Column<int>(nullable: false),
                    AgeLowerLimit = table.Column<int>(nullable: false),
                    EthicCode = table.Column<string>(maxLength: 2, nullable: true),
                    NationalityCode = table.Column<string>(maxLength: 3, nullable: true),
                    NativeCityCode = table.Column<string>(maxLength: 6, nullable: true),
                    ResidenceAdminDivision = table.Column<string>(maxLength: 6, nullable: true),
                    ChineseAccentCode = table.Column<string>(maxLength: 6, nullable: true),
                    PersonOrg = table.Column<string>(maxLength: 100, nullable: true),
                    JobCategory = table.Column<string>(maxLength: 3, nullable: true),
                    AccompanyNumber = table.Column<int>(nullable: false),
                    HeightUpLimit = table.Column<int>(nullable: false),
                    HeightLowerLimit = table.Column<int>(nullable: false),
                    BodyType = table.Column<string>(nullable: true),
                    SkinColor = table.Column<string>(nullable: true),
                    HairStyle = table.Column<string>(maxLength: 2, nullable: true),
                    HairColor = table.Column<string>(maxLength: 2, nullable: true),
                    Gesture = table.Column<string>(maxLength: 2, nullable: true),
                    Status = table.Column<string>(maxLength: 2, nullable: true),
                    FaceStyle = table.Column<string>(maxLength: 4, nullable: true),
                    FacialFeature = table.Column<string>(maxLength: 40, nullable: true),
                    PhysicalFeature = table.Column<string>(maxLength: 200, nullable: true),
                    BodyFeature = table.Column<string>(maxLength: 70, nullable: true),
                    HabitualMovement = table.Column<string>(maxLength: 2, nullable: true),
                    Behavior = table.Column<string>(maxLength: 2, nullable: true),
                    BehaviorDescription = table.Column<string>(nullable: true),
                    Appendant = table.Column<string>(maxLength: 2, nullable: true),
                    AppendantDescription = table.Column<string>(nullable: true),
                    UmbrellaColor = table.Column<string>(maxLength: 2, nullable: true),
                    RespiratorColor = table.Column<string>(maxLength: 2, nullable: true),
                    CapStyle = table.Column<string>(maxLength: 2, nullable: true),
                    CapColor = table.Column<string>(maxLength: 2, nullable: true),
                    GlassStyle = table.Column<string>(maxLength: 2, nullable: true),
                    GlassColor = table.Column<string>(maxLength: 2, nullable: true),
                    ScarfColor = table.Column<string>(maxLength: 2, nullable: true),
                    BagStyle = table.Column<string>(maxLength: 2, nullable: true),
                    BagColor = table.Column<string>(maxLength: 2, nullable: true),
                    CoatStyle = table.Column<string>(maxLength: 2, nullable: true),
                    CoatLength = table.Column<string>(nullable: true),
                    CoatColor = table.Column<string>(maxLength: 2, nullable: true),
                    TrousersStyle = table.Column<string>(maxLength: 2, nullable: true),
                    TrousersColor = table.Column<string>(maxLength: 2, nullable: true),
                    TrousersLen = table.Column<string>(nullable: true),
                    ShoesStyle = table.Column<string>(maxLength: 2, nullable: true),
                    ShoesColor = table.Column<string>(maxLength: 2, nullable: true),
                    IsDriver = table.Column<int>(nullable: false),
                    IsForeigner = table.Column<int>(nullable: false),
                    PassportType = table.Column<string>(maxLength: 2, nullable: true),
                    ImmigrantTypeCode = table.Column<string>(maxLength: 2, nullable: true),
                    IsSuspectedTerrorist = table.Column<int>(nullable: false),
                    SuspectedTerroristNumber = table.Column<string>(maxLength: 19, nullable: true),
                    IsCriminalInvolved = table.Column<int>(nullable: false),
                    CriminalInvolvedSpecilisationCode = table.Column<string>(maxLength: 2, nullable: true),
                    BodySpeciallMark = table.Column<string>(maxLength: 7, nullable: true),
                    CrimeMethod = table.Column<string>(maxLength: 4, nullable: true),
                    CrimeCharacterCode = table.Column<string>(maxLength: 3, nullable: true),
                    EscapedCriminalNumber = table.Column<string>(maxLength: 23, nullable: true),
                    IsDetainees = table.Column<int>(nullable: false),
                    DetentionHouseCode = table.Column<string>(maxLength: 9, nullable: true),
                    DetaineesIdentity = table.Column<string>(maxLength: 2, nullable: true),
                    DetaineesSpecialIdentity = table.Column<string>(maxLength: 2, nullable: true),
                    MemberTypeCode = table.Column<string>(maxLength: 2, nullable: true),
                    IsVictim = table.Column<int>(nullable: false),
                    VictimType = table.Column<string>(maxLength: 3, nullable: true),
                    InjuredDegree = table.Column<string>(nullable: true),
                    CorpseConditionCode = table.Column<string>(maxLength: 2, nullable: true),
                    IsSuspiciousPerson = table.Column<int>(nullable: false),
                    Orientation = table.Column<string>(nullable: true),
                    CoatPattern = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubImageInfo_PersonId",
                table: "SubImageInfo",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubImageInfo_Persons_PersonId",
                table: "SubImageInfo",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubImageInfo_Persons_PersonId",
                table: "SubImageInfo");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_SubImageInfo_PersonId",
                table: "SubImageInfo");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "SubImageInfo");
        }
    }
}
