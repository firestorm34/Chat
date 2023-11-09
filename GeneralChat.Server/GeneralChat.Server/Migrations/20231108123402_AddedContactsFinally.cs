using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeneralChat.Server.Migrations
{
    public partial class AddedContactsFinally : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContactUserId",
                table: "Contacts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId1",
                table: "Contacts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactUserId",
                table: "Contacts",
                column: "ContactUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_OwnerId1",
                table: "Contacts",
                column: "OwnerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_ContactUserId",
                table: "Contacts",
                column: "ContactUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_OwnerId1",
                table: "Contacts",
                column: "OwnerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_ContactUserId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_OwnerId1",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_ContactUserId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_OwnerId1",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactUserId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "Contacts");
        }
    }
}
