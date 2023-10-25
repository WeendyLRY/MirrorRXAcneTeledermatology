using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcneTeledermatology.Migrations
{
    /// <inheritdoc />
    public partial class addedHasFollowUpToUserDermRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasFollowUp",
                table: "UserDermRequest",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasFollowUp",
                table: "UserDermRequest");
        }
    }
}
