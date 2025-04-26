using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Menu.Migrations
{
    public partial class InitialCreate134 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalPrice",
                table: "AddOnIngredient");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AdditionalPrice",
                table: "AddOnIngredient",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
