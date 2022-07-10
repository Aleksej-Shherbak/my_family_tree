using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    public partial class UpdatePersonTableAndAddRelationWithFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Families_ParentFamilyId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_FamilyTrees_FamilyTreeId",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "ParentFamilyId",
                table: "Persons",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "Persons",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Persons",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Persons",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "FamilyTreeId",
                table: "Persons",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "AvatarId",
                table: "Persons",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AvatarId",
                table: "Persons",
                column: "AvatarId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Families_ParentFamilyId",
                table: "Persons",
                column: "ParentFamilyId",
                principalTable: "Families",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_FamilyTrees_FamilyTreeId",
                table: "Persons",
                column: "FamilyTreeId",
                principalTable: "FamilyTrees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Files_AvatarId",
                table: "Persons",
                column: "AvatarId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Families_ParentFamilyId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_FamilyTrees_FamilyTreeId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Files_AvatarId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_AvatarId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "AvatarId",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "ParentFamilyId",
                table: "Persons",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "Persons",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Persons",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Persons",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FamilyTreeId",
                table: "Persons",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Families_ParentFamilyId",
                table: "Persons",
                column: "ParentFamilyId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_FamilyTrees_FamilyTreeId",
                table: "Persons",
                column: "FamilyTreeId",
                principalTable: "FamilyTrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
