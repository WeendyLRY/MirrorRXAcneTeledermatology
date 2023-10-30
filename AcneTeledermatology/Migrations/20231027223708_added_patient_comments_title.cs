using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcneTeledermatology.Migrations
{
    /// <inheritdoc />
    public partial class added_patient_comments_title : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "UserDermRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "UserDermRequest");
        }
    }
}
