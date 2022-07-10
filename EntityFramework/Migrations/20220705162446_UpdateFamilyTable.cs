using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    public partial class UpdateFamilyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Families_Persons_HusbandId",
                table: "Families");

            migrationBuilder.DropForeignKey(
                name: "FK_Families_Persons_WifeId",
                table: "Families");

            migrationBuilder.AlterColumn<int>(
                name: "WifeId",
                table: "Families",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "HusbandId",
                table: "Families",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Families_Persons_HusbandId",
                table: "Families",
                column: "HusbandId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Families_Persons_WifeId",
                table: "Families",
                column: "WifeId",
                principalTable: "Persons",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Families_Persons_HusbandId",
                table: "Families");

            migrationBuilder.DropForeignKey(
                name: "FK_Families_Persons_WifeId",
                table: "Families");

            migrationBuilder.AlterColumn<int>(
                name: "WifeId",
                table: "Families",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HusbandId",
                table: "Families",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Families_Persons_HusbandId",
                table: "Families",
                column: "HusbandId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Families_Persons_WifeId",
                table: "Families",
                column: "WifeId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
