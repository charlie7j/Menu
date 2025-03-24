using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Menu.Data.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemIngredient_MenuItem_MenuItemId1",
                table: "MenuItemIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItemIngredient",
                table: "MenuItemIngredient");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemIngredient_MenuItemId1",
                table: "MenuItemIngredient");

            migrationBuilder.RenameColumn(
                name: "MenuItemId1",
                table: "MenuItemIngredient",
                newName: "MenuItemIngredientId");

            migrationBuilder.AlterColumn<int>(
                name: "MenuItemId",
                table: "MenuItemIngredient",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuItemIngredientId",
                table: "MenuItemIngredient",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItemIngredient",
                table: "MenuItemIngredient",
                column: "MenuItemIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemIngredient_MenuItemId",
                table: "MenuItemIngredient",
                column: "MenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemIngredient_MenuItem_MenuItemId",
                table: "MenuItemIngredient",
                column: "MenuItemId",
                principalTable: "MenuItem",
                principalColumn: "MenuItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemIngredient_MenuItem_MenuItemId",
                table: "MenuItemIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItemIngredient",
                table: "MenuItemIngredient");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemIngredient_MenuItemId",
                table: "MenuItemIngredient");

            migrationBuilder.RenameColumn(
                name: "MenuItemIngredientId",
                table: "MenuItemIngredient",
                newName: "MenuItemId1");

            migrationBuilder.AlterColumn<int>(
                name: "MenuItemId",
                table: "MenuItemIngredient",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuItemId1",
                table: "MenuItemIngredient",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItemIngredient",
                table: "MenuItemIngredient",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemIngredient_MenuItemId1",
                table: "MenuItemIngredient",
                column: "MenuItemId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemIngredient_MenuItem_MenuItemId1",
                table: "MenuItemIngredient",
                column: "MenuItemId1",
                principalTable: "MenuItem",
                principalColumn: "MenuItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
