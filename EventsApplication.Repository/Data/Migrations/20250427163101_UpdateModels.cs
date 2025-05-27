using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsApplication.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Registrations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_OwnerId",
                table: "Registrations",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_AspNetUsers_OwnerId",
                table: "Registrations",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_AspNetUsers_OwnerId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_OwnerId",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Events");
        }
    }
}
