using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechTestIBI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organisations",
                columns: table => new
                {
                    OrganisationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrgName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisations", x => x.OrganisationId);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ContractGroups",
                columns: table => new
                {
                    ContractGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganisationId = table.Column<int>(type: "int", nullable: false),
                    ContractOrganisationOrganisationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractGroups", x => x.ContractGroupId);
                    table.ForeignKey(
                        name: "FK_ContractGroups_Organisations_ContractOrganisationOrganisationId",
                        column: x => x.ContractOrganisationOrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "OrganisationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_Contracts_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractGroupContracts",
                columns: table => new
                {
                    ContractGroupId = table.Column<int>(type: "int", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractGroupContracts", x => new { x.ContractGroupId, x.ContractId });
                    table.ForeignKey(
                        name: "FK_ContractGroupContracts_ContractGroups_ContractGroupId",
                        column: x => x.ContractGroupId,
                        principalTable: "ContractGroups",
                        principalColumn: "ContractGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractGroupContracts_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceNumber = table.Column<int>(type: "int", nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Services_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ContractGroups",
                columns: new[] { "ContractGroupId", "ContractOrganisationOrganisationId", "Name", "OrganisationId" },
                values: new object[,]
                {
                    { 1, null, "Group1", 130 },
                    { 2, null, "Group2", 113 },
                    { 3, null, "Group3", 147 }
                });

            migrationBuilder.InsertData(
                table: "Organisations",
                columns: new[] { "OrganisationId", "OrgName" },
                values: new object[,]
                {
                    { 130, "Sweden Rail" },
                    { 113, "FinnRail" },
                    { 142, "Norway Transport" },
                    { 147, "Denmark Transport" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionId", "RegionName" },
                values: new object[,]
                {
                    { 208, "Denmark" },
                    { 246, "Finland" },
                    { 578, "Norway" },
                    { 752, "Sweden" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Name" },
                values: new object[,]
                {
                    { new Guid("349271d8-1eb8-4356-bf25-afdd098fae7f"), "Jeff" },
                    { new Guid("cdf4bb34-255a-49ab-80a2-9dedd3363402"), "Chuck" },
                    { new Guid("cae0726c-a81c-49c0-ab47-757f65432c38"), "Sarah" },
                    { new Guid("f4db5c23-b6ca-40ff-9f82-4956da9174bd"), "Morgan" }
                });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "ContractId", "EndDateTime", "RegionId", "StartDateTime" },
                values: new object[] { 3, new DateTime(2050, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 208, new DateTime(2021, 7, 1, 0, 11, 30, 393, DateTimeKind.Local).AddTicks(4623) });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "ContractId", "EndDateTime", "RegionId", "StartDateTime" },
                values: new object[] { 2, new DateTime(2050, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 246, new DateTime(2021, 7, 1, 0, 11, 30, 393, DateTimeKind.Local).AddTicks(4560) });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "ContractId", "EndDateTime", "RegionId", "StartDateTime" },
                values: new object[] { 1, new DateTime(2050, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 578, new DateTime(2021, 7, 1, 0, 11, 30, 390, DateTimeKind.Local).AddTicks(1995) });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "ContractId", "ServiceNumber" },
                values: new object[] { 103, 3, 26 });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "ContractId", "ServiceNumber" },
                values: new object[] { 102, 2, 25 });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "ContractId", "ServiceNumber" },
                values: new object[] { 101, 1, 24 });

            migrationBuilder.CreateIndex(
                name: "IX_ContractGroupContracts_ContractGroupId",
                table: "ContractGroupContracts",
                column: "ContractGroupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContractGroupContracts_ContractId",
                table: "ContractGroupContracts",
                column: "ContractId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContractGroups_ContractOrganisationOrganisationId",
                table: "ContractGroups",
                column: "ContractOrganisationOrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_RegionId",
                table: "Contracts",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ContractId",
                table: "Services",
                column: "ContractId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractGroupContracts");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ContractGroups");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Organisations");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
