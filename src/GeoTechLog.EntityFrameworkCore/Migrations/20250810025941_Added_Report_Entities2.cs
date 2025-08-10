using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoTechLog.Migrations
{
    /// <inheritdoc />
    public partial class Added_Report_Entities2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boreholes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boreholes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Geo_ReportAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportVersionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    StoragePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geo_ReportAttachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Geo_ReportBoreholes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoreholeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geo_ReportBoreholes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Geo_ReportBoreholes_Boreholes_BoreholeId",
                        column: x => x.BoreholeId,
                        principalTable: "Boreholes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Geo_Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CurrentVersionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ReportTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsSharedExternally = table.Column<bool>(type: "bit", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geo_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Geo_Reports_ReportTypes_ReportTypeId",
                        column: x => x.ReportTypeId,
                        principalTable: "ReportTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Geo_ReportVersions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VersionNumber = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geo_ReportVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Geo_ReportVersions_Geo_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Geo_Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportShares",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExternalEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShareToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiresAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportShares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportShares_Geo_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Geo_Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Geo_ReportAttachments_ReportVersionId",
                table: "Geo_ReportAttachments",
                column: "ReportVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Geo_ReportBoreholes_BoreholeId",
                table: "Geo_ReportBoreholes",
                column: "BoreholeId");

            migrationBuilder.CreateIndex(
                name: "IX_Geo_ReportBoreholes_ReportId_BoreholeId",
                table: "Geo_ReportBoreholes",
                columns: new[] { "ReportId", "BoreholeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Geo_Reports_CurrentVersionId",
                table: "Geo_Reports",
                column: "CurrentVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Geo_Reports_ReportTypeId",
                table: "Geo_Reports",
                column: "ReportTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Geo_Reports_Status",
                table: "Geo_Reports",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Geo_ReportVersions_ReportId_VersionNumber",
                table: "Geo_ReportVersions",
                columns: new[] { "ReportId", "VersionNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportShares_ReportId",
                table: "ReportShares",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Geo_ReportAttachments_Geo_ReportVersions_ReportVersionId",
                table: "Geo_ReportAttachments",
                column: "ReportVersionId",
                principalTable: "Geo_ReportVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Geo_ReportBoreholes_Geo_Reports_ReportId",
                table: "Geo_ReportBoreholes",
                column: "ReportId",
                principalTable: "Geo_Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Geo_Reports_Geo_ReportVersions_CurrentVersionId",
                table: "Geo_Reports",
                column: "CurrentVersionId",
                principalTable: "Geo_ReportVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Geo_Reports_Geo_ReportVersions_CurrentVersionId",
                table: "Geo_Reports");

            migrationBuilder.DropTable(
                name: "Geo_ReportAttachments");

            migrationBuilder.DropTable(
                name: "Geo_ReportBoreholes");

            migrationBuilder.DropTable(
                name: "ReportShares");

            migrationBuilder.DropTable(
                name: "Boreholes");

            migrationBuilder.DropTable(
                name: "Geo_ReportVersions");

            migrationBuilder.DropTable(
                name: "Geo_Reports");

            migrationBuilder.DropTable(
                name: "ReportTypes");
        }
    }
}
