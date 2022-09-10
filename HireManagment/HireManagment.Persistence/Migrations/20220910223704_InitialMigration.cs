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
                    { "1", 0, 32, "3ad6dc80-5a57-4dbb-bd4a-ace2950d6ea7", "rodrigovalladares1@gmail.com", false, "Robert", "Wade", false, null, null, null, "AQAAAAEAACcQAAAAEESpbwMJnE3MgeJLiNAr+a4+9Y/mOUZct4hsAeISiZvTQNBjO+uBQrEqkBdf2ZMkHA==", null, false, "8d20d7b9-2ede-41b0-a305-c877052214e8", false, null },
                    { "2", 0, 32, "f7ab29ec-1f2b-4695-a3c6-28ac27375902", "rodrigovalladares@gmail.com", false, "Felix", "Feliz", false, null, null, null, "AQAAAAEAACcQAAAAEGFggnwh1al3lICNhF/S2y7x3nWmRa0/K+0ZqE9F4x83QaQDVvOZ/F+IdMfFC3lqYQ==", null, false, "11aa3d4e-535f-443e-9326-909cf5ef8a10", false, null }
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, 32, "c213e679-0fcf-48a4-9ccb-0d01b0b5f799", "rodrigovalladare1@gmail.com", false, "Omar", "Strange", false, null, null, null, "AQAAAAEAACcQAAAAEFJJBn9noHpkIiAMyk7Zgaw5vM8MlZvW30jFKbexsosA30AF8opOk+mt1Z/tbJbgcg==", null, false, "874f8260-20df-44e2-aada-5e5f3343ef74", false, null },
                    { "2", 0, 32, "c745fc44-37b0-457f-9680-578123478ff9", "candidate2@gmail.com", false, "Ruben", "Dario", false, null, null, null, "AQAAAAEAACcQAAAAEB4sLr0KjXX1K/N56Fgf64PxPi9jyPk2xnRCO5UGQygyxC0zS8V/6I+ldN3WigYxPg==", null, false, "321ff1f6-a6d9-4d22-b6d4-12e1417583fc", false, null }
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
                    { "1", 0, 32, 1, "ab5ea0c9-c79b-40be-967e-59f7cbb666a9", "rodrigovalladares1@gmail.com", false, 1, "Henry", "Walas", false, null, null, null, "AQAAAAEAACcQAAAAEIskeea3rhyHOx3rD1dcvkZ/1/yumTpraGsX6JYz98kAqFpJFd/K7XcaqxSsEkrvQw==", null, false, "c380c42a-b5c2-478d-b730-b44709aaa17f", false, null },
                    { "2", 0, 32, 1, "18f5ab04-1c23-4e6c-ab45-8b258188b7ad", "employee2@gmail.com", false, 2, "Brook", "Bane", false, null, null, null, "AQAAAAEAACcQAAAAENe4+rJGEcVdlbldyN5umnXLGBHEmfN8BZ46gZiZ3pYZIVfuS0nvXocEWLV2e1qw4g==", null, false, "a7c28d61-4c39-41bb-8d9b-59417be575be", false, null },
                    { "3", 0, 32, 2, "87d0e968-e8df-4361-ab64-71cae6f2a5f4", "employee3@gmail.com", false, 1, "Harry", "Stevens", false, null, null, null, "AQAAAAEAACcQAAAAEFHbJP87ldu7PFDIJhzDGit1/oYLS0nHlAk26z7wsLnJWqyX43QX22hBFWI0jS77xg==", null, false, "8e237d02-a9b5-4280-aab9-3921c0cce11e", false, null },
                    { "4", 0, 32, 3, "53552135-5a67-4fe6-8a0f-f704a6f511d4", "employee4@gmail.com", false, 1, "Alfonse", "Elric", false, null, null, null, "AQAAAAEAACcQAAAAEEy/1azTnM727xJxVv2GqKKCMlm3jLMJDwC1P03+jsqOU53nOvz+k9Vty+rr2q9OQA==", null, false, "ceea3ff2-56d3-4e94-92ee-800f9d8323bb", false, null }
                });

            migrationBuilder.InsertData(
                table: "Openings",
                columns: new[] { "Id", "CompanyEmployeeId", "DateCreated", "DateExpiration", "Description", "OpeningType", "Title" },
                values: new object[] { 1, "1", new DateTime(2022, 9, 10, 16, 37, 4, 494, DateTimeKind.Local).AddTicks(6865), new DateTime(2022, 9, 20, 16, 37, 4, 494, DateTimeKind.Local).AddTicks(6878), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.", 1, "New Vancancy" });

            migrationBuilder.InsertData(
                table: "Openings",
                columns: new[] { "Id", "CompanyEmployeeId", "DateCreated", "DateExpiration", "Description", "OpeningType", "Title" },
                values: new object[] { 2, "3", new DateTime(2022, 9, 10, 16, 37, 4, 494, DateTimeKind.Local).AddTicks(6890), new DateTime(2022, 10, 5, 16, 37, 4, 494, DateTimeKind.Local).AddTicks(6890), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.", 1, "New Vancancy 2" });

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
