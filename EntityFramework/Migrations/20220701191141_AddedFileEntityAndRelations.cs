using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    public partial class AddedFileEntityAndRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "FamilyTrees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyTrees_FileName",
                table: "FamilyTrees",
                column: "FileName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyTrees_Files_FileName",
                table: "FamilyTrees",
                column: "FileName",
                principalTable: "Files",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyTrees_Files_FileName",
                table: "FamilyTrees");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropIndex(
                name: "IX_FamilyTrees_FileName",
                table: "FamilyTrees");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "FamilyTrees");
        }
    }
}
