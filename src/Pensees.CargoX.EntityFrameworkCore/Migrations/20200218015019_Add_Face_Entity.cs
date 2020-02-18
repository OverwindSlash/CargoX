using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pensees.CargoX.Migrations
{
    public partial class Add_Face_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faces",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaceId = table.Column<string>(maxLength: 48, nullable: false),
                    InfoKind = table.Column<int>(nullable: false),
                    SourceId = table.Column<string>(maxLength: 41, nullable: false),
                    DeviceId = table.Column<string>(maxLength: 20, nullable: true),
                    LeftTopX = table.Column<int>(nullable: false),
                    LeftTopY = table.Column<int>(nullable: false),
                    RightBtmX = table.Column<int>(nullable: false),
                    RightBtmY = table.Column<int>(nullable: false),
                    LocationMarkTime = table.Column<DateTime>(nullable: false),
                    FaceAppearTime = table.Column<DateTime>(nullable: false),
                    FaceDisAppearTime = table.Column<DateTime>(nullable: false),
                    IdType = table.Column<string>(maxLength: 3, nullable: true),
                    IdNumber = table.Column<string>(maxLength: 30, nullable: true),
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
                    JobCategory = table.Column<string>(maxLength: 3, nullable: true),
                    AccompanyNumber = table.Column<int>(nullable: false),
                    SkinColor = table.Column<string>(nullable: true),
                    HairStyle = table.Column<string>(maxLength: 2, nullable: true),
                    HairColor = table.Column<string>(maxLength: 2, nullable: true),
                    FaceStyle = table.Column<string>(maxLength: 4, nullable: true),
                    FacialFeatureType = table.Column<string>(maxLength: 40, nullable: true),
                    PhysicalFeature = table.Column<string>(maxLength: 200, nullable: true),
                    RespiratorColor = table.Column<string>(maxLength: 2, nullable: true),
                    CapStyle = table.Column<string>(maxLength: 2, nullable: true),
                    CapColor = table.Column<string>(maxLength: 2, nullable: true),
                    GlassStyle = table.Column<string>(maxLength: 2, nullable: true),
                    GlassColor = table.Column<string>(maxLength: 2, nullable: true),
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
                    CrimeCharacterCode = table.Column<string>(maxLength: 4, nullable: true),
                    EscapedCriminalNumber = table.Column<string>(maxLength: 23, nullable: true),
                    IsDetainees = table.Column<int>(nullable: false),
                    DetentionHouseCode = table.Column<string>(maxLength: 9, nullable: true),
                    DetaineesIdentity = table.Column<string>(maxLength: 2, nullable: true),
                    DetaineesSpecialIdentity = table.Column<string>(maxLength: 2, nullable: true),
                    MemberTypeCode = table.Column<string>(maxLength: 2, nullable: true),
                    IsVictim = table.Column<int>(nullable: false),
                    VictimType = table.Column<string>(maxLength: 2, nullable: true),
                    InjuredDegree = table.Column<string>(nullable: true),
                    CorpseConditionCode = table.Column<string>(maxLength: 2, nullable: true),
                    IsSuspiciousPerson = table.Column<int>(nullable: false),
                    Attitude = table.Column<int>(nullable: false),
                    Similaritydegree = table.Column<double>(nullable: false),
                    EyebrowStyle = table.Column<string>(maxLength: 32, nullable: true),
                    NoseStyle = table.Column<string>(maxLength: 32, nullable: true),
                    MustacheStyle = table.Column<string>(maxLength: 32, nullable: true),
                    LipStyle = table.Column<string>(maxLength: 32, nullable: true),
                    WrinklePouch = table.Column<string>(maxLength: 32, nullable: true),
                    AcneStain = table.Column<string>(maxLength: 32, nullable: true),
                    FreckleBirthmark = table.Column<string>(maxLength: 32, nullable: true),
                    ScarDimple = table.Column<string>(maxLength: 32, nullable: true),
                    OtherFeature = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubImageInfo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageID = table.Column<string>(maxLength: 41, nullable: false),
                    EventSort = table.Column<int>(nullable: false),
                    DeviceId = table.Column<string>(maxLength: 20, nullable: false),
                    StoragePath = table.Column<string>(nullable: false),
                    Type = table.Column<string>(maxLength: 3, nullable: false),
                    FileFormat = table.Column<string>(nullable: false),
                    ShotTime = table.Column<DateTime>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    NodeId = table.Column<string>(nullable: false),
                    ImageKey = table.Column<string>(nullable: false),
                    FaceId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubImageInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubImageInfo_Faces_FaceId",
                        column: x => x.FaceId,
                        principalTable: "Faces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubImageInfo_FaceId",
                table: "SubImageInfo",
                column: "FaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubImageInfo");

            migrationBuilder.DropTable(
                name: "Faces");
        }
    }
}
