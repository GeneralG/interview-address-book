using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactManager.Migrations
{
    public partial class fixlinting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_Contact_contactID",
                table: "ContactDetails");

            migrationBuilder.RenameColumn(
                name: "contactID",
                table: "ContactDetails",
                newName: "contactId");

            migrationBuilder.RenameIndex(
                name: "IX_ContactDetails_contactID",
                table: "ContactDetails",
                newName: "IX_ContactDetails_contactId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_Contact_contactId",
                table: "ContactDetails",
                column: "contactId",
                principalTable: "Contact",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_Contact_contactId",
                table: "ContactDetails");

            migrationBuilder.RenameColumn(
                name: "contactId",
                table: "ContactDetails",
                newName: "contactID");

            migrationBuilder.RenameIndex(
                name: "IX_ContactDetails_contactId",
                table: "ContactDetails",
                newName: "IX_ContactDetails_contactID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_Contact_contactID",
                table: "ContactDetails",
                column: "contactID",
                principalTable: "Contact",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
