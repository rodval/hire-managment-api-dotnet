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
                    { "1", 0, 32, "bd0043b2-72fc-4dbd-927c-5d8d29f6650f", "rodrigovalladares1@gmail.com", true, "Robert", "Wade", false, null, "RODRIGOVALLADARES1@GMAIL.COM", null, "P@ssword1", null, false, "e1240412-5d10-4d15-9a0d-12e60d0ba6b5", false, null },
                    { "2", 0, 32, "8c48ec46-6c47-4509-82e9-7b2f3a6c3664", "rodrigovalladares@gmail.com", true, "Felix", "Feliz", false, null, "RODRIGOVALLADARES@GMAIL.COM", null, "P@ssword2", null, false, "feaa3ad9-bef1-4f2f-b916-12aa9be0177d", false, null }
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, 32, "fcafee69-f0df-4cf2-8df0-bbfffd45c86a", "rodrigovalladares1@gmail.com", false, "Omar", "Strange", false, null, null, null, "AQAAAAEAACcQAAAAEF1NhaNf9Hxqmm5dvakedkZRo7siYHM5CqVDWsHCc9ZlxIW/HIcriADVzAi0ltf7Zw==", null, false, "7278de99-f87e-43fd-918d-f16d41152953", false, null },
                    { "2", 0, 32, "05d325f1-b2f3-45d7-8955-6fcc84a11908", "rodrigovalladares1@gmail.com", false, "Ruben", "Dario", false, null, null, null, "AQAAAAEAACcQAAAAEK8tWdUnK0mdq9FtmcNCTS4+EEuay0avZ+UYz6KcJIdJlZ4NUplily2QWVihcGwyIA==", null, false, "3dbfec05-39b2-483d-aa09-c66f9c010558", false, null }
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
                    { "1", 0, 32, 1, "47406352-21b8-4428-b275-ce7e10be08d2", "rodrigovalladares1@gmail.com", false, 1, "Henry", "Walas", false, null, null, null, "AQAAAAEAACcQAAAAEE33HJJmO1XHufC3DShs63JkU4AcEqt1NGKnFPzvRY9vniAxBEzab1L49aC48XCTYQ==", null, false, "79a290f6-b20d-478b-963d-e38b2d051cda", false, null },
                    { "2", 0, 32, 1, "5acdec28-5681-4409-9ab3-731a5bf4b36b", "rodrigovalladares1@gmail.com", false, 2, "Brook", "Bane", false, null, null, null, "AQAAAAEAACcQAAAAEHQ/nFvtAhmMUnV68C9sXYVRXTUHn7NmP+mAw8/WBZFGu7SnaYT5jk0MOqoIU3o87A==", null, false, "3cc5a908-924b-46bc-9fb8-fee4537e1834", false, null },
                    { "3", 0, 32, 2, "16af50ab-d3e2-4eba-9116-7c3a9c81f7bc", "rodrigovalladares1@gmail.com", false, 1, "Harry", "Stevens", false, null, null, null, "AQAAAAEAACcQAAAAEG5bEpBjwgaXiRWgc5UBJr3mYHxc03qWcs3+upD1c/qJN8tyixNdbwA37AuSnkL3GA==", null, false, "34f89b8e-3313-408d-8574-189ecc084dae", false, null },
                    { "4", 0, 32, 3, "d5831544-ce92-412d-aa55-d62bd1a15319", "rodrigovalladares1@gmail.com", false, 1, "Alfonse", "Elric", false, null, null, null, "AQAAAAEAACcQAAAAENr8FE3CyfB0L9OBkC4UXJHwwPZCeZ4xTXWXzZ0dtvQORsW5ue3tg24PaR4w5lp15Q==", null, false, "04dfab9a-a628-46e5-b8fb-06450d243be6", false, null }
                });

            migrationBuilder.InsertData(
                table: "Openings",
                columns: new[] { "Id", "CompanyEmployeeId", "DateCreated", "DateExpiration", "Description", "OpeningType", "Title" },
                values: new object[] { 1, "1", new DateTime(2022, 9, 7, 13, 11, 38, 644, DateTimeKind.Local).AddTicks(6457), new DateTime(2022, 9, 17, 13, 11, 38, 644, DateTimeKind.Local).AddTicks(6471), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.", 1, "New Vancancy" });

            migrationBuilder.InsertData(
                table: "Openings",
                columns: new[] { "Id", "CompanyEmployeeId", "DateCreated", "DateExpiration", "Description", "OpeningType", "Title" },
                values: new object[] { 2, "3", new DateTime(2022, 9, 7, 13, 11, 38, 644, DateTimeKind.Local).AddTicks(6476), new DateTime(2022, 10, 2, 13, 11, 38, 644, DateTimeKind.Local).AddTicks(6476), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.", 1, "New Vancancy 2" });

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
