using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcneTeledermatology.Migrations
{
    /// <inheritdoc />
    public partial class oraya : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCaseClosed",
                table: "UserDermRequestResponse",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPhysicalConsultationRequired",
                table: "UserDermRequestResponse",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsVirtualConsultationPossible",
                table: "UserDermRequestResponse",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IDState",
                table: "UserDermRequest",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAcneConditionHealing",
                table: "UserDermRequest",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFollowUp",
                table: "UserDermRequest",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInConsultation",
                table: "UserDermRequest",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreviousConsultationID",
                table: "UserDermRequest",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDermRequest_PreviousConsultationID",
                table: "UserDermRequest",
                column: "PreviousConsultationID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDermRequest_UserDermRequest_PreviousConsultationID",
                table: "UserDermRequest",
                column: "PreviousConsultationID",
                principalTable: "UserDermRequest",
                principalColumn: "IDUserDermRequest");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDermRequest_UserDermRequest_PreviousConsultationID",
                table: "UserDermRequest");

            migrationBuilder.DropIndex(
                name: "IX_UserDermRequest_PreviousConsultationID",
                table: "UserDermRequest");

            migrationBuilder.DropColumn(
                name: "IsCaseClosed",
                table: "UserDermRequestResponse");

            migrationBuilder.DropColumn(
                name: "IsPhysicalConsultationRequired",
                table: "UserDermRequestResponse");

            migrationBuilder.DropColumn(
                name: "IsVirtualConsultationPossible",
                table: "UserDermRequestResponse");

            migrationBuilder.DropColumn(
                name: "IDState",
                table: "UserDermRequest");

            migrationBuilder.DropColumn(
                name: "IsAcneConditionHealing",
                table: "UserDermRequest");

            migrationBuilder.DropColumn(
                name: "IsFollowUp",
                table: "UserDermRequest");

            migrationBuilder.DropColumn(
                name: "IsInConsultation",
                table: "UserDermRequest");

            migrationBuilder.DropColumn(
                name: "PreviousConsultationID",
                table: "UserDermRequest");
        }
    }
}
