using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcneTeledermatology.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Derm",
                columns: table => new
                {
                    IDDerm = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Derm", x => x.IDDerm);
                });

            migrationBuilder.CreateTable(
                name: "DermPatientHistory",
                columns: table => new
                {
                    IDDermPatientHistory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDDerm = table.Column<int>(type: "int", nullable: false),
                    IDUserDermRequestResponse = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DermPatientHistory", x => x.IDDermPatientHistory);
                });

            migrationBuilder.CreateTable(
                name: "DermProfile",
                columns: table => new
                {
                    IDDermProfile = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDDerm = table.Column<int>(type: "int", nullable: false),
                    DermName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DermEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DermPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DermDateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DermProfile", x => x.IDDermProfile);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IDUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IDUser);
                });

            migrationBuilder.CreateTable(
                name: "UserAssessment",
                columns: table => new
                {
                    IDUserAssessment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAssessment", x => x.IDUserAssessment);
                });

            migrationBuilder.CreateTable(
                name: "UserAssessmentHistory",
                columns: table => new
                {
                    IDUserAssessmentHistory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUserAssessment = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAssessmentHistory", x => x.IDUserAssessmentHistory);
                });

            migrationBuilder.CreateTable(
                name: "UserDermRequest",
                columns: table => new
                {
                    IDUserDermRequest = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    IDUserSupplementalAcneProfile = table.Column<int>(type: "int", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDermRequest", x => x.IDUserDermRequest);
                });

            migrationBuilder.CreateTable(
                name: "UserDermRequestResponse",
                columns: table => new
                {
                    IDUserDermRequestResponse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDDerm = table.Column<int>(type: "int", nullable: false),
                    IDUserDermRequest = table.Column<int>(type: "int", nullable: true),
                    DermComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DermPrescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DermSuggestion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDermRequestResponse", x => x.IDUserDermRequestResponse);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    IDUserProfile = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProfileImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.IDUserProfile);
                });

            migrationBuilder.CreateTable(
                name: "UserSupplementalAcneProfile",
                columns: table => new
                {
                    IDUserSupplementalAcneProfile = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUser = table.Column<int>(type: "int", nullable: false),
                    IDUserProfile = table.Column<int>(type: "int", nullable: false),
                    SleepingPattern = table.Column<int>(type: "int", nullable: false),
                    SunblockHabit = table.Column<int>(type: "int", nullable: false),
                    DietHabit = table.Column<int>(type: "int", nullable: false),
                    SkincareProducts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SunExposure = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSupplementalAcneProfile", x => x.IDUserSupplementalAcneProfile);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Derm");

            migrationBuilder.DropTable(
                name: "DermPatientHistory");

            migrationBuilder.DropTable(
                name: "DermProfile");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserAssessment");

            migrationBuilder.DropTable(
                name: "UserAssessmentHistory");

            migrationBuilder.DropTable(
                name: "UserDermRequest");

            migrationBuilder.DropTable(
                name: "UserDermRequestResponse");

            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropTable(
                name: "UserSupplementalAcneProfile");
        }
    }
}
