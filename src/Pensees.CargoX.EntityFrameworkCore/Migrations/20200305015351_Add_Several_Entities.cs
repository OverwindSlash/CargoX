using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pensees.CargoX.Migrations
{
    public partial class Add_Several_Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubImageInfo_Faces_FaceId",
                table: "SubImageInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_SubImageInfo_Persons_PersonId",
                table: "SubImageInfo");

            migrationBuilder.DropColumn(
                name: "InfoType",
                table: "Persons");

            migrationBuilder.AddColumn<long>(
                name: "MotorId",
                table: "SubImageInfo",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "NonMotorId",
                table: "SubImageInfo",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SceneId",
                table: "SubImageInfo",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ThingId",
                table: "SubImageInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InfoKind",
                table: "Persons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserNameOrEmailAddress",
                table: "AbpUserLoginAttempts",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "AbpSettings",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2000) CHARACTER SET utf8mb4",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AbpWebhookEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    WebhookName = table.Column<string>(nullable: false),
                    Data = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpWebhookEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpWebhookSubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    WebhookUri = table.Column<string>(nullable: false),
                    Secret = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Webhooks = table.Column<string>(nullable: true),
                    Headers = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpWebhookSubscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Apes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApeID = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Model = table.Column<string>(maxLength: 100, nullable: false),
                    IPAddr = table.Column<string>(maxLength: 30, nullable: false),
                    IPV6Addr = table.Column<string>(maxLength: 64, nullable: true),
                    Port = table.Column<int>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    PlaceCode = table.Column<string>(maxLength: 6, nullable: false),
                    Place = table.Column<string>(maxLength: 256, nullable: true),
                    OrgCode = table.Column<string>(maxLength: 12, nullable: true),
                    CapDirection = table.Column<int>(nullable: false),
                    MonitorDirection = table.Column<string>(nullable: true),
                    MonitorAreaDesc = table.Column<string>(maxLength: 256, nullable: true),
                    IsOnline = table.Column<string>(maxLength: 1, nullable: false),
                    OwnerApsID = table.Column<string>(maxLength: 20, nullable: true),
                    UserId = table.Column<string>(maxLength: 64, nullable: true),
                    Password = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Apss",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ApsID = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    IPAddr = table.Column<string>(maxLength: 30, nullable: false),
                    IPV6Addr = table.Column<string>(maxLength: 64, nullable: true),
                    Port = table.Column<int>(nullable: false),
                    IsOnline = table.Column<string>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseInfos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CaseID = table.Column<string>(maxLength: 30, nullable: false),
                    CaseLinkMark = table.Column<string>(maxLength: 23, nullable: true),
                    CaseName = table.Column<string>(maxLength: 120, nullable: false),
                    CaseAbstract = table.Column<string>(maxLength: 4000, nullable: false),
                    ClueID = table.Column<string>(maxLength: 1024, nullable: false),
                    TimeUpLimit = table.Column<DateTime>(nullable: false),
                    TimeLowLimit = table.Column<DateTime>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    PlaceCode = table.Column<string>(maxLength: 6, nullable: false),
                    PlaceFullAddress = table.Column<string>(maxLength: 100, nullable: false),
                    SuspectNumber = table.Column<int>(nullable: false),
                    WitnessIDs = table.Column<string>(maxLength: 1024, nullable: true),
                    CreatorName = table.Column<string>(maxLength: 50, nullable: true),
                    CreatorIDType = table.Column<string>(maxLength: 3, nullable: true),
                    CreatorID = table.Column<string>(maxLength: 30, nullable: true),
                    CreatorOrg = table.Column<string>(maxLength: 100, nullable: true),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    MotorVehicleIDs = table.Column<string>(maxLength: 1024, nullable: true),
                    NonMotorVehicleIDs = table.Column<string>(maxLength: 1024, nullable: true),
                    PersonIDs = table.Column<string>(maxLength: 1024, nullable: true),
                    FaceIDs = table.Column<string>(maxLength: 1024, nullable: true),
                    ThingIDs = table.Column<string>(maxLength: 1024, nullable: true),
                    FileIDs = table.Column<string>(maxLength: 1024, nullable: true),
                    SceneIDs = table.Column<string>(maxLength: 1024, nullable: true),
                    RelateCaseIdList = table.Column<string>(maxLength: 1024, nullable: true),
                    ParentCaseId = table.Column<string>(maxLength: 30, nullable: true),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MotorVehicleID = table.Column<string>(maxLength: 48, nullable: false),
                    InfoKind = table.Column<int>(nullable: false),
                    SourceId = table.Column<string>(maxLength: 41, nullable: false),
                    TollgateId = table.Column<string>(maxLength: 20, nullable: true),
                    DeviceId = table.Column<string>(maxLength: 20, nullable: true),
                    StorageUrl1 = table.Column<string>(maxLength: 256, nullable: false),
                    StorageUrl2 = table.Column<string>(maxLength: 256, nullable: false),
                    StorageUrl3 = table.Column<string>(maxLength: 256, nullable: false),
                    StorageUrl4 = table.Column<string>(maxLength: 256, nullable: false),
                    StorageUrl5 = table.Column<string>(maxLength: 256, nullable: false),
                    LeftTopX = table.Column<int>(nullable: false),
                    LeftTopY = table.Column<int>(nullable: false),
                    RightBtmX = table.Column<int>(nullable: false),
                    RightBtmY = table.Column<int>(nullable: false),
                    MarkTime = table.Column<DateTime>(nullable: false),
                    AppearTime = table.Column<DateTime>(nullable: false),
                    DisappearTime = table.Column<DateTime>(nullable: false),
                    LaneNo = table.Column<int>(nullable: false),
                    HasPlate = table.Column<bool>(nullable: false),
                    PlateClass = table.Column<string>(maxLength: 2, nullable: true),
                    PlateColor = table.Column<string>(maxLength: 2, nullable: true),
                    PlateNo = table.Column<string>(maxLength: 15, nullable: true),
                    PlateNoAttach = table.Column<string>(maxLength: 15, nullable: true),
                    PlateDescribe = table.Column<string>(maxLength: 64, nullable: true),
                    IsDecked = table.Column<bool>(nullable: false),
                    IsAltered = table.Column<bool>(nullable: false),
                    IsCovered = table.Column<bool>(nullable: false),
                    Speed = table.Column<double>(nullable: false),
                    Direction = table.Column<string>(maxLength: 1, nullable: true),
                    DrivingStatusCode = table.Column<string>(maxLength: 4, nullable: true),
                    UsingPropertiesCode = table.Column<int>(nullable: false),
                    VehicleClass = table.Column<string>(maxLength: 3, nullable: true),
                    VehicleBrand = table.Column<string>(maxLength: 3, nullable: true),
                    VehicleModel = table.Column<string>(maxLength: 32, nullable: true),
                    VehicleStyles = table.Column<string>(maxLength: 16, nullable: true),
                    VehicleLength = table.Column<int>(nullable: false),
                    VehicleWidth = table.Column<int>(nullable: false),
                    VehicleHeight = table.Column<int>(nullable: false),
                    VehicleColor = table.Column<string>(maxLength: 2, nullable: false),
                    VehicleColorDepth = table.Column<string>(nullable: true),
                    VehicleHood = table.Column<string>(maxLength: 64, nullable: true),
                    VehicleTrunk = table.Column<string>(maxLength: 64, nullable: true),
                    VehicleWheel = table.Column<string>(maxLength: 64, nullable: true),
                    WheelPrintedPattern = table.Column<string>(maxLength: 2, nullable: true),
                    VehicleWindow = table.Column<string>(maxLength: 64, nullable: true),
                    VehicleRoof = table.Column<string>(maxLength: 64, nullable: true),
                    VehicleDoor = table.Column<string>(maxLength: 64, nullable: true),
                    SideOfVehicle = table.Column<string>(maxLength: 64, nullable: true),
                    CarOfVehicle = table.Column<string>(maxLength: 64, nullable: true),
                    RearviewMirror = table.Column<string>(maxLength: 64, nullable: true),
                    VehicleChassis = table.Column<string>(maxLength: 64, nullable: true),
                    VehicleShielding = table.Column<string>(maxLength: 64, nullable: true),
                    FilmColor = table.Column<string>(nullable: true),
                    IsModified = table.Column<bool>(nullable: false),
                    HitMarkInfo = table.Column<string>(nullable: true),
                    VehicleBodyDesc = table.Column<string>(maxLength: 128, nullable: true),
                    VehicleFrontItem = table.Column<string>(maxLength: 128, nullable: true),
                    DescOfFrontItem = table.Column<string>(maxLength: 256, nullable: true),
                    VehicleRearItem = table.Column<string>(maxLength: 128, nullable: true),
                    DescOfRearItem = table.Column<string>(maxLength: 256, nullable: true),
                    NumOfPassenger = table.Column<int>(nullable: false),
                    PassTime = table.Column<DateTime>(nullable: false),
                    NameOfPassedRoad = table.Column<string>(maxLength: 64, nullable: true),
                    IsSuspicious = table.Column<bool>(nullable: false),
                    Sunvisor = table.Column<int>(nullable: false),
                    SafetyBelt = table.Column<int>(nullable: false),
                    Calling = table.Column<int>(nullable: false),
                    PlateReliability = table.Column<string>(maxLength: 3, nullable: true),
                    PlateCharReliability = table.Column<string>(maxLength: 64, nullable: true),
                    BrandReliability = table.Column<string>(maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NonMotors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NonMotorVehicleID = table.Column<string>(maxLength: 48, nullable: false),
                    InfoKind = table.Column<int>(nullable: false),
                    SourceId = table.Column<string>(maxLength: 41, nullable: false),
                    DeviceId = table.Column<string>(maxLength: 20, nullable: true),
                    LeftTopX = table.Column<int>(nullable: false),
                    LeftTopY = table.Column<int>(nullable: false),
                    RightBtmX = table.Column<int>(nullable: false),
                    RightBtmY = table.Column<int>(nullable: false),
                    MarkTime = table.Column<DateTime>(nullable: false),
                    AppearTime = table.Column<DateTime>(nullable: false),
                    DisappearTime = table.Column<DateTime>(nullable: false),
                    HasPlate = table.Column<bool>(nullable: false),
                    PlateClass = table.Column<string>(maxLength: 2, nullable: true),
                    PlateColor = table.Column<string>(maxLength: 2, nullable: true),
                    PlateNo = table.Column<string>(maxLength: 16, nullable: true),
                    PlateNoAttach = table.Column<string>(maxLength: 16, nullable: true),
                    PlateDescribe = table.Column<string>(maxLength: 64, nullable: true),
                    IsDecked = table.Column<bool>(nullable: false),
                    IsAltered = table.Column<bool>(nullable: false),
                    IsCovered = table.Column<bool>(nullable: false),
                    Speed = table.Column<double>(nullable: false),
                    DrivingStatusCode = table.Column<string>(maxLength: 4, nullable: true),
                    UsingPropertiesCode = table.Column<int>(nullable: false),
                    VehicleBrand = table.Column<string>(maxLength: 32, nullable: true),
                    VehicleType = table.Column<string>(maxLength: 64, nullable: true),
                    VehicleLength = table.Column<int>(nullable: false),
                    VehicleWidth = table.Column<int>(nullable: false),
                    VehicleHeight = table.Column<int>(nullable: false),
                    VehicleColor = table.Column<string>(maxLength: 2, nullable: false),
                    VehicleHood = table.Column<string>(maxLength: 64, nullable: true),
                    VehicleTrunk = table.Column<string>(maxLength: 64, nullable: true),
                    VehicleWheel = table.Column<string>(maxLength: 64, nullable: true),
                    WheelPrintedPattern = table.Column<string>(maxLength: 2, nullable: true),
                    VehicleWindow = table.Column<string>(maxLength: 64, nullable: true),
                    VehicleRoof = table.Column<string>(maxLength: 64, nullable: true),
                    VehicleDoor = table.Column<string>(maxLength: 64, nullable: true),
                    SideOfVehicle = table.Column<string>(maxLength: 64, nullable: true),
                    CarOfVehicle = table.Column<string>(maxLength: 64, nullable: true),
                    RearviewMirror = table.Column<string>(maxLength: 64, nullable: true),
                    VehicleChassis = table.Column<string>(maxLength: 64, nullable: true),
                    VehicleShielding = table.Column<string>(maxLength: 64, nullable: true),
                    FilmColor = table.Column<string>(nullable: true),
                    IsModified = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonMotors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NotificationID = table.Column<string>(maxLength: 33, nullable: false),
                    SubscribeID = table.Column<string>(maxLength: 33, nullable: false),
                    Title = table.Column<string>(maxLength: 256, nullable: false),
                    TriggerTime = table.Column<DateTime>(nullable: false),
                    InfoIDs = table.Column<string>(maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scenes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SceneID = table.Column<string>(maxLength: 48, nullable: false),
                    InfoKind = table.Column<int>(nullable: false),
                    SourceId = table.Column<string>(maxLength: 41, nullable: false),
                    BeginTime = table.Column<DateTime>(nullable: false),
                    PlaceType = table.Column<string>(maxLength: 4, nullable: true),
                    WeatherType = table.Column<string>(maxLength: 2, nullable: true),
                    SceneDescribe = table.Column<string>(maxLength: 256, nullable: true),
                    SceneType = table.Column<string>(maxLength: 2, nullable: true),
                    RoadAlignmentType = table.Column<string>(maxLength: 2, nullable: true),
                    RoadTerraintype = table.Column<int>(nullable: false),
                    RoadSurfaceType = table.Column<string>(maxLength: 1, nullable: true),
                    RoadCoditionType = table.Column<string>(maxLength: 1, nullable: true),
                    RoadJunctionSectionType = table.Column<string>(maxLength: 2, nullable: true),
                    RoadLightingType = table.Column<string>(maxLength: 1, nullable: true),
                    Illustration = table.Column<string>(maxLength: 2, nullable: true),
                    WindDirection = table.Column<string>(maxLength: 2, nullable: true),
                    Illumination = table.Column<string>(nullable: true),
                    FieldCondition = table.Column<string>(nullable: true),
                    Temperature = table.Column<double>(nullable: false),
                    Humidity = table.Column<string>(nullable: true),
                    PopulationDensity = table.Column<string>(nullable: true),
                    DenseDegree = table.Column<string>(nullable: true),
                    Importance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscribes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SubscribeID = table.Column<string>(maxLength: 33, nullable: true),
                    Title = table.Column<string>(maxLength: 256, nullable: true),
                    SubscribeDetail = table.Column<string>(nullable: true),
                    ResourceURI = table.Column<string>(maxLength: 256, nullable: true),
                    ApplicantName = table.Column<string>(maxLength: 50, nullable: true),
                    ApplicantOrg = table.Column<string>(maxLength: 100, nullable: true),
                    BeginTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    ReceiveAddr = table.Column<string>(maxLength: 256, nullable: true),
                    ReportInterval = table.Column<int>(nullable: false),
                    Reason = table.Column<string>(maxLength: 256, nullable: true),
                    OperateType = table.Column<int>(nullable: false),
                    SubscribeStatus = table.Column<int>(nullable: false),
                    SubscribeCancelOrg = table.Column<string>(maxLength: 100, nullable: true),
                    SubscribeCancelPerson = table.Column<string>(maxLength: 32, nullable: true),
                    CancelTime = table.Column<DateTime>(nullable: false),
                    CancelReason = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Things",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ThingID = table.Column<string>(maxLength: 48, nullable: false),
                    InfoKind = table.Column<int>(nullable: false),
                    SourceId = table.Column<string>(maxLength: 41, nullable: false),
                    DeviceId = table.Column<string>(maxLength: 20, nullable: true),
                    LeftTopX = table.Column<int>(nullable: false),
                    LeftTopY = table.Column<int>(nullable: false),
                    RightBtmX = table.Column<int>(nullable: false),
                    RightBtmY = table.Column<int>(nullable: false),
                    MarkTime = table.Column<DateTime>(nullable: false),
                    AppearTime = table.Column<DateTime>(nullable: false),
                    DisappearTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    Shape = table.Column<string>(maxLength: 64, nullable: true),
                    Color = table.Column<string>(maxLength: 2, nullable: false),
                    Size = table.Column<string>(maxLength: 64, nullable: true),
                    Material = table.Column<string>(maxLength: 256, nullable: true),
                    Characteristic = table.Column<string>(maxLength: 256, nullable: true),
                    Propertiy = table.Column<string>(maxLength: 2, nullable: true),
                    InvolvedObjType = table.Column<string>(maxLength: 5, nullable: true),
                    FirearmsAmmunitionType = table.Column<string>(maxLength: 2, nullable: true),
                    ToolTraceType = table.Column<string>(maxLength: 2, nullable: true),
                    EvidenceType = table.Column<string>(maxLength: 5, nullable: true),
                    CaseEvidenceType = table.Column<string>(maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Things", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoSliceInfos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VideoID = table.Column<string>(maxLength: 41, nullable: true),
                    InfoKind = table.Column<int>(nullable: false),
                    VideoSource = table.Column<string>(maxLength: 2, nullable: false),
                    IsAbstractVideo = table.Column<bool>(nullable: false),
                    OriginVideoID = table.Column<string>(maxLength: 41, nullable: true),
                    OriginVideoURL = table.Column<string>(maxLength: 256, nullable: true),
                    EventSort = table.Column<int>(nullable: false),
                    DeviceId = table.Column<string>(maxLength: 20, nullable: true),
                    StoragePath = table.Column<string>(maxLength: 256, nullable: true),
                    ThumbnailStoragePath = table.Column<string>(maxLength: 256, nullable: true),
                    FileHash = table.Column<string>(maxLength: 128, nullable: true),
                    FileFormat = table.Column<string>(maxLength: 6, nullable: false),
                    CodedFormat = table.Column<string>(maxLength: 2, nullable: false),
                    AudioFlag = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 128, nullable: false),
                    TitleNote = table.Column<string>(maxLength: 128, nullable: true),
                    SpecialName = table.Column<string>(maxLength: 128, nullable: true),
                    Keyword = table.Column<string>(maxLength: 200, nullable: true),
                    ContentDescription = table.Column<string>(maxLength: 1024, nullable: false),
                    MainCharacter = table.Column<string>(maxLength: 256, nullable: true),
                    ShotPlaceCode = table.Column<string>(maxLength: 6, nullable: false),
                    ShotPlaceFullAdress = table.Column<string>(maxLength: 100, nullable: false),
                    ShotPlaceLongitude = table.Column<double>(nullable: false),
                    ShotPlacetLatitude = table.Column<double>(nullable: false),
                    HorizontalShotDirection = table.Column<string>(maxLength: 1, nullable: true),
                    VerticalShotDirection = table.Column<string>(maxLength: 1, nullable: true),
                    SecurityLevel = table.Column<string>(maxLength: 1, nullable: true),
                    VidelLen = table.Column<double>(nullable: false),
                    BeginTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    TimeErr = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    QualityGrade = table.Column<string>(nullable: true),
                    CollectorName = table.Column<string>(maxLength: 50, nullable: true),
                    CollectorOrg = table.Column<string>(maxLength: 100, nullable: true),
                    CollectorIDType = table.Column<string>(maxLength: 3, nullable: true),
                    CollectorID = table.Column<string>(maxLength: 30, nullable: true),
                    EntryClerk = table.Column<string>(maxLength: 50, nullable: true),
                    EntryClerkOrg = table.Column<string>(maxLength: 100, nullable: true),
                    EntryClerkIDType = table.Column<string>(maxLength: 3, nullable: true),
                    EntryClerkID = table.Column<string>(maxLength: 30, nullable: true),
                    EntryTime = table.Column<DateTime>(nullable: false),
                    VideoProcFlag = table.Column<int>(nullable: false),
                    FileSize = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoSliceInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpWebhookSendAttempts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    WebhookEventId = table.Column<Guid>(nullable: false),
                    WebhookSubscriptionId = table.Column<Guid>(nullable: false),
                    Response = table.Column<string>(nullable: true),
                    ResponseStatusCode = table.Column<int>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpWebhookSendAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpWebhookSendAttempts_AbpWebhookEvents_WebhookEventId",
                        column: x => x.WebhookEventId,
                        principalTable: "AbpWebhookEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CaseInfoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cases_CaseInfos_CaseInfoId",
                        column: x => x.CaseInfoId,
                        principalTable: "CaseInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubImageInfo_MotorId",
                table: "SubImageInfo",
                column: "MotorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubImageInfo_NonMotorId",
                table: "SubImageInfo",
                column: "NonMotorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubImageInfo_SceneId",
                table: "SubImageInfo",
                column: "SceneId");

            migrationBuilder.CreateIndex(
                name: "IX_SubImageInfo_ThingId",
                table: "SubImageInfo",
                column: "ThingId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpWebhookSendAttempts_WebhookEventId",
                table: "AbpWebhookSendAttempts",
                column: "WebhookEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CaseInfoId",
                table: "Cases",
                column: "CaseInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubImageInfo_Faces_FaceId",
                table: "SubImageInfo",
                column: "FaceId",
                principalTable: "Faces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubImageInfo_Motors_MotorId",
                table: "SubImageInfo",
                column: "MotorId",
                principalTable: "Motors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubImageInfo_NonMotors_NonMotorId",
                table: "SubImageInfo",
                column: "NonMotorId",
                principalTable: "NonMotors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubImageInfo_Persons_PersonId",
                table: "SubImageInfo",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubImageInfo_Scenes_SceneId",
                table: "SubImageInfo",
                column: "SceneId",
                principalTable: "Scenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubImageInfo_Things_ThingId",
                table: "SubImageInfo",
                column: "ThingId",
                principalTable: "Things",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubImageInfo_Faces_FaceId",
                table: "SubImageInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_SubImageInfo_Motors_MotorId",
                table: "SubImageInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_SubImageInfo_NonMotors_NonMotorId",
                table: "SubImageInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_SubImageInfo_Persons_PersonId",
                table: "SubImageInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_SubImageInfo_Scenes_SceneId",
                table: "SubImageInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_SubImageInfo_Things_ThingId",
                table: "SubImageInfo");

            migrationBuilder.DropTable(
                name: "AbpWebhookSendAttempts");

            migrationBuilder.DropTable(
                name: "AbpWebhookSubscriptions");

            migrationBuilder.DropTable(
                name: "Apes");

            migrationBuilder.DropTable(
                name: "Apss");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Motors");

            migrationBuilder.DropTable(
                name: "NonMotors");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Scenes");

            migrationBuilder.DropTable(
                name: "Subscribes");

            migrationBuilder.DropTable(
                name: "Things");

            migrationBuilder.DropTable(
                name: "VideoSliceInfos");

            migrationBuilder.DropTable(
                name: "AbpWebhookEvents");

            migrationBuilder.DropTable(
                name: "CaseInfos");

            migrationBuilder.DropIndex(
                name: "IX_SubImageInfo_MotorId",
                table: "SubImageInfo");

            migrationBuilder.DropIndex(
                name: "IX_SubImageInfo_NonMotorId",
                table: "SubImageInfo");

            migrationBuilder.DropIndex(
                name: "IX_SubImageInfo_SceneId",
                table: "SubImageInfo");

            migrationBuilder.DropIndex(
                name: "IX_SubImageInfo_ThingId",
                table: "SubImageInfo");

            migrationBuilder.DropColumn(
                name: "MotorId",
                table: "SubImageInfo");

            migrationBuilder.DropColumn(
                name: "NonMotorId",
                table: "SubImageInfo");

            migrationBuilder.DropColumn(
                name: "SceneId",
                table: "SubImageInfo");

            migrationBuilder.DropColumn(
                name: "ThingId",
                table: "SubImageInfo");

            migrationBuilder.DropColumn(
                name: "InfoKind",
                table: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "InfoType",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserNameOrEmailAddress",
                table: "AbpUserLoginAttempts",
                type: "varchar(255) CHARACTER SET utf8mb4",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "AbpSettings",
                type: "varchar(2000) CHARACTER SET utf8mb4",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SubImageInfo_Faces_FaceId",
                table: "SubImageInfo",
                column: "FaceId",
                principalTable: "Faces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubImageInfo_Persons_PersonId",
                table: "SubImageInfo",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
