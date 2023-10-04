using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcneTeledermatology.Migrations
{
    /// <inheritdoc />
    public partial class SixthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageRelativePath",
                table: "UserAssessment",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageRelativePath",
                table: "UserAssessment");
        }
    }
}
