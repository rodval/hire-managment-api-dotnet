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
                    { "1", 0, 32, "8b63f52b-8035-4f05-be06-a6fabd89a002", "rodrigovalladares1@gmail.com", false, "Robert", "Wade", false, null, null, null, "AQAAAAEAACcQAAAAEAfF8Ig3E7SyzAAlrx4V6SwF6PM0NCPv8wedWlJ0/uKS2TBuISmIaMBGPue29Ia14g==", null, false, "a1745f8c-c19b-41ab-9357-3e6e4bf546e7", false, null },
                    { "2", 0, 32, "159d3c40-1245-4f49-b175-f793ffa7af68", "rodrigovalladares@gmail.com", false, "Felix", "Feliz", false, null, null, null, "AQAAAAEAACcQAAAAEEnjbYESGA2s935hnNhLBEcNvpwHYq0y2/tDvzfewV/dEImF4J3+cr762rrVFp2ZZw==", null, false, "19b38104-0006-4af8-990b-7b833e7ae6e1", false, null }
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, 32, "3d64497d-705a-45d3-8e00-ff1d39615cb2", "rodrigovalladare1@gmail.com", false, "Omar", "Strange", false, null, null, null, "AQAAAAEAACcQAAAAEHGIsp1AETTRwaeq+D8HRyZqTlnlcX/bkqQhlrGNRLjRydz9clfKTyO1R4zZfm6dzg==", null, false, "36b97b6e-6b56-40b9-a7e5-409d421b2805", false, null },
                    { "2", 0, 32, "99f02d72-0371-498f-a9b7-3ccf2628605d", "candidate2@gmail.com", false, "Ruben", "Dario", false, null, null, null, "AQAAAAEAACcQAAAAEE3UuidZpDc4BXEdslQ7i+NXeRkpsVRPW4hOe9oNlh2oMaafWWoyPyYHJ0mPCBqPeA==", null, false, "2ddc38a3-134e-4988-b6eb-f9830b934edf", false, null }
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
                    { "1", 0, 32, 1, "5ac94066-9b30-45a6-81d0-42043987813a", "rodrigovalladares1@gmail.com", false, 1, "Henry", "Walas", false, null, null, null, "AQAAAAEAACcQAAAAEGNplMb3wsT6/R9PM5psA3b5TCx7aDLtvcY0bLJxO5AFdIpkqtxwaQbSuvfqdNlfbw==", null, false, "ac84606c-e8a0-4f5e-a942-53dd4d1166ba", false, null },
                    { "2", 0, 32, 1, "5c1ab5c9-84eb-40ad-9859-e39758cf1384", "employee2@gmail.com", false, 2, "Brook", "Bane", false, null, null, null, "AQAAAAEAACcQAAAAEI64hA5LqcYyL//pICw7ANbebxFNU/IQoxy4j0dRd+fOE24+ICBDi3/whgXtJ+i0Pg==", null, false, "0de9452f-8c28-49cc-9de5-25b18821821e", false, null },
                    { "3", 0, 32, 2, "83f3ad9c-c586-4751-b28a-2cd58850406a", "employee3@gmail.com", false, 1, "Harry", "Stevens", false, null, null, null, "AQAAAAEAACcQAAAAENLCS+KVb+Lf019Cs94UXBD0ye/fCeWdn/cnr69Ujk6W3FMHRU/uG02ZFpB/vQ26jQ==", null, false, "a1a65ab2-a6da-4b2d-bf96-ac181defa5fc", false, null },
                    { "4", 0, 32, 3, "0e32f1ab-dc22-4027-85b4-2e062d03edb6", "employee4@gmail.com", false, 1, "Alfonse", "Elric", false, null, null, null, "AQAAAAEAACcQAAAAEOP/ew46HKKrQdfl9iRD6ECcnDbfJkYmGo0t4n97dgM8oTzl2TMqca8ChRq3yLFj4Q==", null, false, "3b377a9d-ee26-41a8-aeba-d206ff782226", false, null }
                });

            migrationBuilder.InsertData(
                table: "Openings",
                columns: new[] { "Id", "CompanyEmployeeId", "DateCreated", "DateExpiration", "Description", "OpeningType", "Title" },
                values: new object[] { 1, "1", new DateTime(2022, 9, 7, 18, 10, 56, 780, DateTimeKind.Local).AddTicks(9004), new DateTime(2022, 9, 17, 18, 10, 56, 780, DateTimeKind.Local).AddTicks(9017), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.", 1, "New Vancancy" });

            migrationBuilder.InsertData(
                table: "Openings",
                columns: new[] { "Id", "CompanyEmployeeId", "DateCreated", "DateExpiration", "Description", "OpeningType", "Title" },
                values: new object[] { 2, "3", new DateTime(2022, 9, 7, 18, 10, 56, 780, DateTimeKind.Local).AddTicks(9023), new DateTime(2022, 10, 2, 18, 10, 56, 780, DateTimeKind.Local).AddTicks(9024), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.", 1, "New Vancancy 2" });

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
