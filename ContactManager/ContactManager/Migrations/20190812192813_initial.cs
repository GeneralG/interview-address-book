using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactManager.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    contactItem = table.Column<string>(nullable: true),
                    Contactid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_ContactDetails_Contact_Contactid",
                        column: x => x.Contactid,
                        principalTable: "Contact",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_Contactid",
                table: "ContactDetails",
                column: "Contactid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactDetails");

            migrationBuilder.DropTable(
                name: "Contact");
        }
    }
}
