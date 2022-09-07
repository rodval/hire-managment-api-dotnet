using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HireManagment.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyEmployees",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeType = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyEmployees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpeningApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateApplication = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CompanyEmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CandidateId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpeningApplications_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpeningApplications_CompanyEmployees_CompanyEmployeeId",
                        column: x => x.CompanyEmployeeId,
                        principalTable: "CompanyEmployees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Openings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateExpiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OpeningType = table.Column<int>(type: "int", nullable: false),
                    CompanyEmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Openings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Openings_CompanyEmployees_CompanyEmployeeId",
                        column: x => x.CompanyEmployeeId,
                        principalTable: "CompanyEmployees",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, 32, "1f76d559-2687-49bc-9005-6e2779760be9", "rodrigovalladares1@gmail.com", true, "Robert", "Wade", false, null, "RODRIGOVALLADARES1@GMAIL.COM", null, "AQAAAAEAACcQAAAAEN97q9dEcZEDv936tnAmuAmQlaFlZfyZjNlpNhcpIklb4wLkZq3VyTctdJkmPvP8qQ==", null, false, "4b5c0945-ed4b-48f9-b0cc-aff93b5f1ae4", false, null },
                    { "2", 0, 32, "512eab08-3a85-481a-9dac-fad5d81f0cc0", "rodrigovalladares@gmail.com", true, "Felix", "Feliz", false, null, "RODRIGOVALLADARES@GMAIL.COM", null, "AQAAAAEAACcQAAAAEA7VZu3mtXCt7woOgBsXk/GJ8/wUF7iUDX8kDWmYBzZNfvKQIRWouPy2ICoSwUWpcg==", null, false, "61f014af-ba87-4188-9bfb-480f3907894a", false, null }
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, 32, "f6f5f584-ad5d-4412-bb28-7abf1a91c64c", "rodrigovalladares1@gmail.com", false, "Omar", "Strange", false, null, null, null, "AQAAAAEAACcQAAAAEHbbemvGYxZBwMhYWURMAeuT4eYAjmuV1VfrpDbdC6ogalTgKhGOIwgWq6WUgMfSCA==", null, false, "2d2dde7a-c87c-413b-8749-5a4b42184ec0", false, null },
                    { "2", 0, 32, "7bce37d2-fd72-4b5c-8c1c-2de9914807c7", "rodrigovalladares1@gmail.com", false, "Ruben", "Dario", false, null, null, null, "AQAAAAEAACcQAAAAEENbA9mcPykBAEh+OJOQ2LstU8rvzk/MNz9mKEYCtaG0Djw/UWKiPfRnZkwzYNCWjw==", null, false, "7b6bd382-6d17-47d4-b71b-a2da193ad13f", false, null }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "AdminId", "Description", "Name" },
                values: new object[] { 1, "address", "1", "company 1", "Naughty Dog" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "AdminId", "Description", "Name" },
                values: new object[] { 2, "address", "2", "company 2", "Riot Games" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "AdminId", "Description", "Name" },
                values: new object[] { 3, "address", "2", "company 3", "Miami Heat" });

            migrationBuilder.InsertData(
                table: "CompanyEmployees",
                columns: new[] { "Id", "AccessFailedCount", "Age", "CompanyId", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeType", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, 32, 1, "4ab45ec9-ad90-41c7-8fc3-85193824e097", "rodrigovalladares1@gmail.com", false, 1, "Henry", "Walas", false, null, null, null, "AQAAAAEAACcQAAAAENQQMLDzADpifLoJc+Pi0Rgw20xjSL8SQoHUKA77szYLqdai/2OUrB2UuiJHBtdwYg==", null, false, "63e00e9a-e074-4f6b-917a-1477eb0d927f", false, null },
                    { "2", 0, 32, 1, "2b115c83-89c8-448b-aec1-65eb3c864fb0", "rodrigovalladares1@gmail.com", false, 2, "Brook", "Bane", false, null, null, null, "AQAAAAEAACcQAAAAEN1ErhleWe1TEpiyCBYP2NGsPJK2onlrXTqSrGVCqywNy1748KlFx6SGhUyuTjZuzA==", null, false, "a817960f-0cab-448a-89bf-7f142c6cdc77", false, null },
                    { "3", 0, 32, 2, "c22532f9-ceb7-4591-8bcf-c80ae20bb27b", "rodrigovalladares1@gmail.com", false, 1, "Harry", "Stevens", false, null, null, null, "AQAAAAEAACcQAAAAEJJ3QkqnVkkr61a4m5pmLZP9o+yu3k78Egc4yxQvCPtJYWRvPLie+MrXP27Ut04WfQ==", null, false, "e84df656-0880-4c4b-b68c-d52603070305", false, null },
                    { "4", 0, 32, 3, "e841f60f-2680-4944-b9d2-02ca05ef9b06", "rodrigovalladares1@gmail.com", false, 1, "Alfonse", "Elric", false, null, null, null, "AQAAAAEAACcQAAAAEA7W3Kw0zpMFlLLPOMNOgQT9AmFzWNT9VW9q5R9NDifk3NIxXdHm/n+n87TPI7Xh4w==", null, false, "c133f61d-ce8a-467e-b51a-eb085905be98", false, null }
                });

            migrationBuilder.InsertData(
                table: "Openings",
                columns: new[] { "Id", "CompanyEmployeeId", "DateCreated", "DateExpiration", "Description", "OpeningType", "Title" },
                values: new object[] { 1, "1", new DateTime(2022, 9, 7, 11, 50, 8, 63, DateTimeKind.Local).AddTicks(4608), new DateTime(2022, 9, 17, 11, 50, 8, 63, DateTimeKind.Local).AddTicks(4625), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.", 1, "New Vancancy" });

            migrationBuilder.InsertData(
                table: "Openings",
                columns: new[] { "Id", "CompanyEmployeeId", "DateCreated", "DateExpiration", "Description", "OpeningType", "Title" },
                values: new object[] { 2, "3", new DateTime(2022, 9, 7, 11, 50, 8, 63, DateTimeKind.Local).AddTicks(4630), new DateTime(2022, 10, 2, 11, 50, 8, 63, DateTimeKind.Local).AddTicks(4631), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.", 1, "New Vancancy 2" });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AdminId",
                table: "Companies",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEmployees_CompanyId",
                table: "CompanyEmployees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningApplications_CandidateId",
                table: "OpeningApplications",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningApplications_CompanyEmployeeId",
                table: "OpeningApplications",
                column: "CompanyEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Openings_CompanyEmployeeId",
                table: "Openings",
                column: "CompanyEmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpeningApplications");

            migrationBuilder.DropTable(
                name: "Openings");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "CompanyEmployees");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Admins");
        }
    }
}
