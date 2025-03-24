using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Menu.Data.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemIngredient_Ingredient_IngredientId",
                table: "MenuItemIngredient");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemIngredient_IngredientId",
                table: "MenuItemIngredient");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "MenuItemIngredient");

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "MenuItemIngredient",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "MenuItemIngredient");

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "MenuItemIngredient",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemIngredient_IngredientId",
                table: "MenuItemIngredient",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemIngredient_Ingredient_IngredientId",
                table: "MenuItemIngredient",
                column: "IngredientId",
                principalTable: "Ingredient",
                principalColumn: "IngredientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
