using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    public partial class UpdatedFamilyTreeRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Persons",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FamilyTreeId",
                table: "Families",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_UserId",
                table: "Persons",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Families_FamilyTreeId",
                table: "Families",
                column: "FamilyTreeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Families_FamilyTrees_FamilyTreeId",
                table: "Families",
                column: "FamilyTreeId",
                principalTable: "FamilyTrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_AspNetUsers_UserId",
                table: "Persons",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Families_FamilyTrees_FamilyTreeId",
                table: "Families");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_AspNetUsers_UserId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_UserId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Families_FamilyTreeId",
                table: "Families");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "FamilyTreeId",
                table: "Families");
        }
    }
}
