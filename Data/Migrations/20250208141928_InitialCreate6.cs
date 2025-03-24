using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Menu.Data.Migrations
{
    public partial class InitialCreate6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRemovable",
                table: "MenuItemIngredient",
                newName: "SubStatus");

            migrationBuilder.AddColumn<bool>(
                name: "AdditionalStatus",
                table: "MenuItemIngredient",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "ExtraPrice",
                table: "MenuItemIngredient",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "PrimaryStatus",
                table: "MenuItemIngredient",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalStatus",
                table: "MenuItemIngredient");

            migrationBuilder.DropColumn(
                name: "ExtraPrice",
                table: "MenuItemIngredient");

            migrationBuilder.DropColumn(
                name: "PrimaryStatus",
                table: "MenuItemIngredient");

            migrationBuilder.RenameColumn(
                name: "SubStatus",
                table: "MenuItemIngredient",
                newName: "IsRemovable");
        }
    }
}
