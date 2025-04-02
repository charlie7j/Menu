using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Menu.Data.Migrations
{
    public partial class InitialCreate10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OrderItemRemovedOn",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "OrderItemRemovedOn");
        }
    }
}
