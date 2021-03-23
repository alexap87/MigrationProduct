using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MigrationProduct.Bottling;
using MigrationProduct.Curd;
using MigrationProduct.Intake;
using MySql.EntityFrameworkCore.Metadata;

namespace MigrationProduct.MySQLMilkoscan.Create
{
    public partial class CreateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (!TestCheck.CheckTableExists<tblMfCdPredictedValueC>(new ConnectionMilkoscan()))
            {
                migrationBuilder.CreateTable(
                name: "fsprediction",
                columns: table => new
                {
                    PredictedValueID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SystemID = table.Column<int>(type: "int", nullable: false),
                    SubSampleID = table.Column<long>(type: "bigint", nullable: false),
                    ParameterLogicalID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    AggregationType = table.Column<int>(type: "int", nullable: false),
                    TextResult = table.Column<string>(type: "text", nullable: true),
                    DoubleResult = table.Column<double>(type: "double", nullable: true),
                    DataType = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: true),
                    OutlierStatus = table.Column<int>(type: "int", nullable: false),
                    ProductLimitsStatus = table.Column<int>(type: "int", nullable: false),
                    RawResult = table.Column<double>(type: "double", nullable: true),
                    IsSigned = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fsprediction", x => x.PredictedValueID);
                });
            }

            if (!TestCheck.CheckTableExists<tblMfCdProductC>(new ConnectionMilkoscan()))
            {
                migrationBuilder.CreateTable(
                name: "fsproduct",
                columns: table => new
                {
                    ProductID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SystemID = table.Column<int>(type: "int", nullable: false),
                    ProductLogicalID = table.Column<int>(type: "int", nullable: false),
                    NetworkID = table.Column<int>(type: "int", nullable: false),
                    InstrumentTypeID = table.Column<int>(type: "int", nullable: false),
                    ProductType = table.Column<int>(type: "int", nullable: false),
                    ProductGroupID = table.Column<int>(type: "int", nullable: true),
                    ProductIconID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ProductCode = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SampleType = table.Column<int>(type: "int", nullable: true),
                    InstrumentGroupLogicalID = table.Column<long>(type: "bigint", nullable: true),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Valid = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    AdvancedPredictionModels = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AdvancedInstruments = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AdvancedProductLimits = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PredictionMode = table.Column<int>(type: "int", nullable: false),
                    HierarchyFileID = table.Column<int>(type: "int", nullable: true),
                    SpecificSlopeIntercept = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NameTranslationID = table.Column<long>(type: "bigint", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false),
                    GUID = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    CreatedAtUTC = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedAtUTC = table.Column<DateTime>(type: "datetime", nullable: true),
                    Obsolete = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Latest = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fsproduct", x => x.ProductID);
                });
            }

            if (!TestCheck.CheckTableExists<tblMfCdSampleC>(new ConnectionMilkoscan()))
            {
                migrationBuilder.CreateTable(
                name: "fssample",
                columns: table => new
                {
                    SampleID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SystemID = table.Column<int>(type: "int", nullable: false),
                    InstrumentLogicalID = table.Column<int>(type: "int", nullable: false),
                    SampleType = table.Column<int>(type: "int", nullable: false),
                    SampleNumber = table.Column<string>(type: "text", nullable: true),
                    ProductLogicalID = table.Column<int>(type: "int", nullable: false),
                    AuditTrailID = table.Column<int>(type: "int", nullable: true),
                    AnalysisStartUTC = table.Column<DateTime>(type: "datetime", nullable: true),
                    AnalysisEndUTC = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedAtUTC = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedAtUTC = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    RawDataStatus = table.Column<int>(type: "int", nullable: false),
                    EventsStatus = table.Column<int>(type: "int", nullable: false),
                    OutlierStatus = table.Column<int>(type: "int", nullable: false),
                    ProductLimitsStatus = table.Column<int>(type: "int", nullable: false),
                    SampleinstrumentID = table.Column<byte[]>(type: "varbinary(16)", nullable: true),
                    Obsolete = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Signature = table.Column<string>(type: "text", nullable: true),
                    SignatureVersion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fssample", x => x.SampleID);
                });
            }

            if (!TestCheck.CheckTableExists<tblMfCdSubSampleC>(new ConnectionMilkoscan()))
            {
                migrationBuilder.CreateTable(
                name: "fssubsample",
                columns: table => new
                {
                    SubSampleID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SystemID = table.Column<int>(type: "int", nullable: false),
                    SampleID = table.Column<long>(type: "bigint", nullable: false),
                    ParentSubSampleID = table.Column<long>(type: "bigint", nullable: true),
                    SequenceNumber = table.Column<int>(type: "int", nullable: true),
                    SubSampleNumber = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Info = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    IsLeaf = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    RawDataStatus = table.Column<int>(type: "int", nullable: false),
                    EventsStatus = table.Column<int>(type: "int", nullable: false),
                    OutlierStatus = table.Column<int>(type: "int", nullable: false),
                    ProductLimitsStatus = table.Column<int>(type: "int", nullable: false),
                    Quality = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fssubsample", x => x.SubSampleID);
                });
            }

            if (!TestCheck.CheckTableExists<PredictionC>(new ConnectionMilkoscan()))
            {
                migrationBuilder.CreateTable(
                name: "prediction",
                columns: table => new
                {
                    SampRef = table.Column<int>(type: "int", nullable: false),
                    RepNoRef = table.Column<short>(type: "smallint", nullable: false),
                    CompRef = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "double", nullable: true),
                    Flags = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prediction", x => new { x.SampRef, x.RepNoRef, x.CompRef });
                });
            }

            if (!TestCheck.CheckTableExists<ProductC>(new ConnectionMilkoscan()))
            {
                migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    ProdNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CurVersion = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Protected = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    UsabilityLevel = table.Column<short>(type: "smallint", nullable: true),
                    NoOfComps = table.Column<short>(type: "smallint", nullable: true),
                    NoOfCols = table.Column<short>(type: "smallint", nullable: true),
                    IconNo = table.Column<short>(type: "smallint", nullable: true),
                    IconPos = table.Column<int>(type: "int", nullable: true),
                    Replicates = table.Column<short>(type: "smallint", nullable: true),
                    PumpStrokes = table.Column<short>(type: "smallint", nullable: true),
                    Viscosity = table.Column<short>(type: "smallint", nullable: true),
                    Preflush = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    PipetteShake = table.Column<short>(type: "smallint", nullable: true),
                    ReducedVolume = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CleaningTemperature = table.Column<short>(type: "smallint", nullable: true),
                    CleaningIntensity = table.Column<short>(type: "smallint", nullable: true),
                    PurgeAlarmTimeout = table.Column<short>(type: "smallint", nullable: true),
                    PilotMode = table.Column<short>(type: "smallint", nullable: true),
                    PilotMeanMax = table.Column<short>(type: "smallint", nullable: true),
                    CurNoOfPilots = table.Column<short>(type: "smallint", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Version = table.Column<string>(type: "text", nullable: true),
                    ProdDate = table.Column<string>(type: "text", nullable: true),
                    OrigProdRef = table.Column<int>(type: "int", nullable: true),
                    UseDilution = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    DilutionFactorMin = table.Column<double>(type: "double", nullable: true),
                    DilutionFactorIdeal = table.Column<double>(type: "double", nullable: true),
                    DilutionFactorMax = table.Column<double>(type: "double", nullable: true),
                    SampleWeightMin = table.Column<double>(type: "double", nullable: true),
                    SampleWeightideal = table.Column<double>(type: "double", nullable: true),
                    SampleWeightMax = table.Column<double>(type: "double", nullable: true),
                    PcaFailMode = table.Column<short>(type: "smallint", nullable: true),
                    AllowCheckSampleDefinition = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    HideAllGH = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    InstrumentType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.ProdNo);
                });
            }

            if (!TestCheck.CheckTableExists<ResultsC>(new ConnectionMilkoscan()))
            {
                migrationBuilder.CreateTable(
                name: "result",
                columns: table => new
                {
                    WorkstationID = table.Column<short>(type: "smallint", nullable: false),
                    SampleIndex = table.Column<int>(type: "int", nullable: false),
                    IntakeNumerator = table.Column<byte>(type: "tinyint", nullable: false),
                    SyntheticNumerator = table.Column<byte>(type: "tinyint", nullable: false),
                    ResultTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Export = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SaveForever = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    StoreOnServer = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    ResultType = table.Column<byte>(type: "tinyint", nullable: false),
                    ResultSubType = table.Column<byte>(type: "tinyint", nullable: false),
                    SetupIndex = table.Column<int>(type: "int", nullable: false),
                    JobIndex = table.Column<int>(type: "int", nullable: false),
                    Numerator = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    RackID = table.Column<int>(type: "int", nullable: false),
                    OriginalJobIndex = table.Column<int>(type: "int", nullable: false),
                    IsMosaicUploaded = table.Column<short>(type: "smallint", nullable: false),
                    IsModified = table.Column<short>(type: "smallint", nullable: false),
                    InstrumentSampleID = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    IsLinkDiagnosticUploaded = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_result", x => new { x.SampleIndex, x.IntakeNumerator, x.SyntheticNumerator, x.WorkstationID });
                });
            }

            if (!TestCheck.CheckTableExists<SampleC>(new ConnectionMilkoscan()))
            {
                migrationBuilder.CreateTable(
                name: "sample",
                columns: table => new
                {
                    SampNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SampleId = table.Column<string>(type: "text", nullable: true),
                    ProdRef = table.Column<int>(type: "int", nullable: false),
                    ZeroRef = table.Column<int>(type: "int", nullable: false),
                    NoOfReps = table.Column<short>(type: "smallint", nullable: false),
                    Kind = table.Column<short>(type: "smallint", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    DilutionFactor = table.Column<double>(type: "double", nullable: false),
                    SampleWeight = table.Column<double>(type: "double", nullable: false),
                    Excluded = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Flags = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    UDF1 = table.Column<string>(type: "text", nullable: true),
                    UDF2 = table.Column<string>(type: "text", nullable: true),
                    UDF3 = table.Column<string>(type: "text", nullable: true),
                    UDF4 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sample", x => x.SampNo);
                });
            }

            if (!TestCheck.CheckTableExists<DoubleComponentsC>(new ConnectionMilkoscan()))
            {
                migrationBuilder.CreateTable(
                name: "doublecomponent",
                columns: table => new
                {
                    WorkstationID = table.Column<short>(type: "smallint", nullable: false),
                    SampleIndex = table.Column<int>(type: "int", nullable: false),
                    IntakeNumerator = table.Column<byte>(type: "tinyint", nullable: false),
                    SyntheticNumerator = table.Column<byte>(type: "tinyint", nullable: false),
                    CID = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "double", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    ReferenceValue = table.Column<double>(type: "double", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doublecomponent", x => new { x.SampleIndex, x.CID, x.IntakeNumerator, x.SyntheticNumerator, x.WorkstationID });
                    table.ForeignKey(
                        name: "FK_doublecomponent_result_SampleIndex_IntakeNumerator_Synthetic~",
                        columns: x => new { x.SampleIndex, x.IntakeNumerator, x.SyntheticNumerator, x.WorkstationID },
                        principalTable: "result",
                        principalColumns: new[] { "SampleIndex", "IntakeNumerator", "SyntheticNumerator", "WorkstationID" },
                        onDelete: ReferentialAction.Cascade);
                });
            }

            if (!TestCheck.CheckTableExists<TextComponentsC>(new ConnectionMilkoscan()))
            {
                migrationBuilder.CreateTable(
                name: "textcomponent",
                columns: table => new
                {
                    WorkstationID = table.Column<short>(type: "smallint", nullable: false),
                    SampleIndex = table.Column<int>(type: "int", nullable: false),
                    IntakeNumerator = table.Column<byte>(type: "tinyint", nullable: false),
                    SyntheticNumerator = table.Column<byte>(type: "tinyint", nullable: false),
                    CID = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_textcomponent", x => new { x.SampleIndex, x.CID, x.IntakeNumerator, x.SyntheticNumerator, x.WorkstationID });
                    table.ForeignKey(
                        name: "FK_textcomponent_result_SampleIndex_IntakeNumerator_SyntheticNu~",
                        columns: x => new { x.SampleIndex, x.IntakeNumerator, x.SyntheticNumerator, x.WorkstationID },
                        principalTable: "result",
                        principalColumns: new[] { "SampleIndex", "IntakeNumerator", "SyntheticNumerator", "WorkstationID" },
                        onDelete: ReferentialAction.Cascade);
                });
            }

            migrationBuilder.CreateIndex(
                name: "IX_doublecomponent_SampleIndex_IntakeNumerator_SyntheticNumerat~",
                table: "doublecomponent",
                columns: new[] { "SampleIndex", "IntakeNumerator", "SyntheticNumerator", "WorkstationID" });

            migrationBuilder.CreateIndex(
                name: "IX_textcomponent_SampleIndex_IntakeNumerator_SyntheticNumerator~",
                table: "textcomponent",
                columns: new[] { "SampleIndex", "IntakeNumerator", "SyntheticNumerator", "WorkstationID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropTable(
                name: "doublecomponent");

            migrationBuilder.DropTable(
                name: "fsprediction");

            migrationBuilder.DropTable(
                name: "fsproduct");

            migrationBuilder.DropTable(
                name: "fssample");

            migrationBuilder.DropTable(
                name: "fssubsample");

            migrationBuilder.DropTable(
                name: "prediction");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "sample");

            migrationBuilder.DropTable(
                name: "textcomponent");

            migrationBuilder.DropTable(
                name: "result");*/
        }
    }
}
