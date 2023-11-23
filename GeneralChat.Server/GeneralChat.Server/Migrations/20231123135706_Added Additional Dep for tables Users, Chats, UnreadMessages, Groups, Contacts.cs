using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GeneralChat.Server.Migrations
{
    public partial class AddedAdditionalDepfortablesUsersChatsUnreadMessagesGroupsContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Group_GroupId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_AspNetUsers_User1Id",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_AspNetUsers_User2Id",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_ContactUserId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_OwnerId1",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_UserInGroups_UserId",
                table: "UserInGroups");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_ContactUserId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_OwnerId1",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Chats_User1Id",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_User2Id",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GroupId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ContactUserId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "User1Id",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "User2Id",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Group",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Contacts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInGroups",
                table: "UserInGroups",
                columns: new[] { "UserId", "GroupId" });

            migrationBuilder.CreateIndex(
                name: "IX_UnreadMessages_ChatId",
                table: "UnreadMessages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_UnreadMessages_UserId",
                table: "UnreadMessages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_UserId",
                table: "Group",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactId",
                table: "Contacts",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_FirstUserId",
                table: "Chats",
                column: "FirstUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_SecondUserId",
                table: "Chats",
                column: "SecondUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_AspNetUsers_FirstUserId",
                table: "Chats",
                column: "FirstUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_AspNetUsers_SecondUserId",
                table: "Chats",
                column: "SecondUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_ContactId",
                table: "Contacts",
                column: "ContactId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_OwnerId",
                table: "Contacts",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_AspNetUsers_UserId",
                table: "Group",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UnreadMessages_AspNetUsers_UserId",
                table: "UnreadMessages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnreadMessages_Chats_ChatId",
                table: "UnreadMessages",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnreadMessages_Messages_MessageId",
                table: "UnreadMessages",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_AspNetUsers_FirstUserId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_AspNetUsers_SecondUserId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_ContactId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_OwnerId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_AspNetUsers_UserId",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_UnreadMessages_AspNetUsers_UserId",
                table: "UnreadMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_UnreadMessages_Chats_ChatId",
                table: "UnreadMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_UnreadMessages_Messages_MessageId",
                table: "UnreadMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInGroups",
                table: "UserInGroups");

            migrationBuilder.DropIndex(
                name: "IX_UnreadMessages_ChatId",
                table: "UnreadMessages");

            migrationBuilder.DropIndex(
                name: "IX_UnreadMessages_UserId",
                table: "UnreadMessages");

            migrationBuilder.DropIndex(
                name: "IX_Group_UserId",
                table: "Group");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_ContactId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Chats_FirstUserId",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_SecondUserId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Group");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Contacts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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

            migrationBuilder.AddColumn<int>(
                name: "User1Id",
                table: "Chats",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User2Id",
                table: "Chats",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInGroups_UserId",
                table: "UserInGroups",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactUserId",
                table: "Contacts",
                column: "ContactUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_OwnerId1",
                table: "Contacts",
                column: "OwnerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_User1Id",
                table: "Chats",
                column: "User1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_User2Id",
                table: "Chats",
                column: "User2Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GroupId",
                table: "AspNetUsers",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Group_GroupId",
                table: "AspNetUsers",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_AspNetUsers_User1Id",
                table: "Chats",
                column: "User1Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_AspNetUsers_User2Id",
                table: "Chats",
                column: "User2Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
