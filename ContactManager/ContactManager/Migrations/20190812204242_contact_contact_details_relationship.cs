using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactManager.Migrations
{
    public partial class contact_contact_details_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_Contact_Contactid",
                table: "ContactDetails");

            migrationBuilder.RenameColumn(
                name: "Contactid",
                table: "ContactDetails",
                newName: "contactID");

            migrationBuilder.RenameIndex(
                name: "IX_ContactDetails_Contactid",
                table: "ContactDetails",
                newName: "IX_ContactDetails_contactID");

            migrationBuilder.AlterColumn<string>(
                name: "contactItem",
                table: "ContactDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "contactID",
                table: "ContactDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "contact",
                table: "ContactDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "lastName",
                table: "Contact",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "firstName",
                table: "Contact",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_Contact_contactID",
                table: "ContactDetails",
                column: "contactID",
                principalTable: "Contact",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_Contact_contactID",
                table: "ContactDetails");

            migrationBuilder.DropColumn(
                name: "contact",
                table: "ContactDetails");

            migrationBuilder.RenameColumn(
                name: "contactID",
                table: "ContactDetails",
                newName: "Contactid");

            migrationBuilder.RenameIndex(
                name: "IX_ContactDetails_contactID",
                table: "ContactDetails",
                newName: "IX_ContactDetails_Contactid");

            migrationBuilder.AlterColumn<string>(
                name: "contactItem",
                table: "ContactDetails",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Contactid",
                table: "ContactDetails",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "lastName",
                table: "Contact",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "firstName",
                table: "Contact",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_Contact_Contactid",
                table: "ContactDetails",
                column: "Contactid",
                principalTable: "Contact",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
