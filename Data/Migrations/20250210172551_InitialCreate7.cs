using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Menu.Data.Migrations
{
    public partial class InitialCreate7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "MenuItemSize",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemSize_SizeId",
                table: "MenuItemSize",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemSize_Size_SizeId",
                table: "MenuItemSize",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "SizeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemSize_Size_SizeId",
                table: "MenuItemSize");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemSize_SizeId",
                table: "MenuItemSize");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "MenuItemSize");
        }
    }
}
