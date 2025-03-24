using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Menu.Data.Migrations
{
    public partial class InitialCreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemAddOn_MenuItem_MenuItemId1",
                table: "MenuItemAddOn");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItemAddOn",
                table: "MenuItemAddOn");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemAddOn_MenuItemId1",
                table: "MenuItemAddOn");

            migrationBuilder.RenameColumn(
                name: "MenuItemId1",
                table: "MenuItemAddOn",
                newName: "AddOnId");

            migrationBuilder.AlterColumn<int>(
                name: "MenuItemId",
                table: "MenuItemAddOn",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "AddOnId",
                table: "MenuItemAddOn",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItemAddOn",
                table: "MenuItemAddOn",
                column: "AddOnId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemAddOn_MenuItemId",
                table: "MenuItemAddOn",
                column: "MenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemAddOn_MenuItem_MenuItemId",
                table: "MenuItemAddOn",
                column: "MenuItemId",
                principalTable: "MenuItem",
                principalColumn: "MenuItemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemAddOn_MenuItem_MenuItemId",
                table: "MenuItemAddOn");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItemAddOn",
                table: "MenuItemAddOn");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemAddOn_MenuItemId",
                table: "MenuItemAddOn");

            migrationBuilder.RenameColumn(
                name: "AddOnId",
                table: "MenuItemAddOn",
                newName: "MenuItemId1");

            migrationBuilder.AlterColumn<int>(
                name: "MenuItemId",
                table: "MenuItemAddOn",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuItemId1",
                table: "MenuItemAddOn",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItemAddOn",
                table: "MenuItemAddOn",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemAddOn_MenuItemId1",
                table: "MenuItemAddOn",
                column: "MenuItemId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemAddOn_MenuItem_MenuItemId1",
                table: "MenuItemAddOn",
                column: "MenuItemId1",
                principalTable: "MenuItem",
                principalColumn: "MenuItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
