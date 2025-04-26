using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Menu.Migrations
{
    public partial class InitialCreate133 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemAddOn_MenuItem_MenuItemId",
                table: "MenuItemAddOn");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemSize_MenuItem_MenuItemId",
                table: "MenuItemSize");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemAddOn_AddOnIngredient_AddOnIngredientId",
                table: "OrderItemAddOn");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemAddOn_OrderItem_OrderItemId",
                table: "OrderItemAddOn");

            migrationBuilder.RenameColumn(
                name: "AddId",
                table: "AddOnIngredient",
                newName: "MenuItemIngredientId");

            migrationBuilder.AlterColumn<int>(
                name: "OrderItemId",
                table: "OrderItemAddOn",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddOnIngredientId",
                table: "OrderItemAddOn",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuItemId",
                table: "MenuItemSize",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuItemId",
                table: "MenuItemAddOn",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemAddOn_MenuItem_MenuItemId",
                table: "MenuItemAddOn",
                column: "MenuItemId",
                principalTable: "MenuItem",
                principalColumn: "MenuItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemSize_MenuItem_MenuItemId",
                table: "MenuItemSize",
                column: "MenuItemId",
                principalTable: "MenuItem",
                principalColumn: "MenuItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemAddOn_AddOnIngredient_AddOnIngredientId",
                table: "OrderItemAddOn",
                column: "AddOnIngredientId",
                principalTable: "AddOnIngredient",
                principalColumn: "AddOnIngredientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemAddOn_OrderItem_OrderItemId",
                table: "OrderItemAddOn",
                column: "OrderItemId",
                principalTable: "OrderItem",
                principalColumn: "OrderItemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemAddOn_MenuItem_MenuItemId",
                table: "MenuItemAddOn");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemSize_MenuItem_MenuItemId",
                table: "MenuItemSize");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemAddOn_AddOnIngredient_AddOnIngredientId",
                table: "OrderItemAddOn");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemAddOn_OrderItem_OrderItemId",
                table: "OrderItemAddOn");

            migrationBuilder.RenameColumn(
                name: "MenuItemIngredientId",
                table: "AddOnIngredient",
                newName: "AddId");

            migrationBuilder.AlterColumn<int>(
                name: "OrderItemId",
                table: "OrderItemAddOn",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "AddOnIngredientId",
                table: "OrderItemAddOn",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "MenuItemId",
                table: "MenuItemSize",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "MenuItemId",
                table: "MenuItemAddOn",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemAddOn_MenuItem_MenuItemId",
                table: "MenuItemAddOn",
                column: "MenuItemId",
                principalTable: "MenuItem",
                principalColumn: "MenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemSize_MenuItem_MenuItemId",
                table: "MenuItemSize",
                column: "MenuItemId",
                principalTable: "MenuItem",
                principalColumn: "MenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemAddOn_AddOnIngredient_AddOnIngredientId",
                table: "OrderItemAddOn",
                column: "AddOnIngredientId",
                principalTable: "AddOnIngredient",
                principalColumn: "AddOnIngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemAddOn_OrderItem_OrderItemId",
                table: "OrderItemAddOn",
                column: "OrderItemId",
                principalTable: "OrderItem",
                principalColumn: "OrderItemId");
        }
    }
}
