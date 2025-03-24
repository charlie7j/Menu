using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Menu.Data.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddOnIngredient",
                columns: table => new
                {
                    AddOnIngredientId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    AdditionalPrice = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddOnIngredient", x => x.AddOnIngredientId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TableNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CustomerNote = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "RemoveOnIngredient",
                columns: table => new
                {
                    RemoveOnIngredientId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RemoveID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemoveOnIngredient", x => x.RemoveOnIngredientId);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    SizeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.SizeId);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "MenuItem",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.MenuItemId);
                    table.ForeignKey(
                        name: "FK_MenuItem_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemAddOn",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddOnIngredientId = table.Column<int>(type: "INTEGER", nullable: false),
                    MenuItemId1 = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemAddOn", x => x.MenuItemId);
                    table.ForeignKey(
                        name: "FK_MenuItemAddOn_AddOnIngredient_AddOnIngredientId",
                        column: x => x.AddOnIngredientId,
                        principalTable: "AddOnIngredient",
                        principalColumn: "AddOnIngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemAddOn_MenuItem_MenuItemId1",
                        column: x => x.MenuItemId1,
                        principalTable: "MenuItem",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemIngredient",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MenuItemId1 = table.Column<int>(type: "INTEGER", nullable: false),
                    IngredientId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsRemovable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemIngredient", x => x.MenuItemId);
                    table.ForeignKey(
                        name: "FK_MenuItemIngredient_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredient",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemIngredient_MenuItem_MenuItemId1",
                        column: x => x.MenuItemId1,
                        principalTable: "MenuItem",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemSize",
                columns: table => new
                {
                    MenuItemSizeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PriceAdjustment = table.Column<decimal>(type: "TEXT", nullable: false),
                    MenuItemId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemSize", x => x.MenuItemSizeId);
                    table.ForeignKey(
                        name: "FK_MenuItemSize_MenuItem_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItem",
                        principalColumn: "MenuItemId");
                });

            migrationBuilder.CreateTable(
                name: "MenuItemTag",
                columns: table => new
                {
                    MenuItemTagId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MenuItemId = table.Column<int>(type: "INTEGER", nullable: true),
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemTag", x => x.MenuItemTagId);
                    table.ForeignKey(
                        name: "FK_MenuItemTag_MenuItem_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItem",
                        principalColumn: "MenuItemId");
                    table.ForeignKey(
                        name: "FK_MenuItemTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MenuItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    SelectedSizeMenuItemSizeId = table.Column<int>(type: "INTEGER", nullable: true),
                    ItemNote = table.Column<string>(type: "TEXT", nullable: true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItem_MenuItem_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItem",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_MenuItemSize_SelectedSizeMenuItemSizeId",
                        column: x => x.SelectedSizeMenuItemSizeId,
                        principalTable: "MenuItemSize",
                        principalColumn: "MenuItemSizeId");
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateTable(
                name: "OrderItemAddOn",
                columns: table => new
                {
                    OrderItemAddOnId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddOnIngredientId = table.Column<int>(type: "INTEGER", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: true),
                    OrderItemId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemAddOn", x => x.OrderItemAddOnId);
                    table.ForeignKey(
                        name: "FK_OrderItemAddOn_AddOnIngredient_AddOnIngredientId",
                        column: x => x.AddOnIngredientId,
                        principalTable: "AddOnIngredient",
                        principalColumn: "AddOnIngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItemAddOn_OrderItem_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItem",
                        principalColumn: "OrderItemId");
                });

            migrationBuilder.CreateTable(
                name: "OrderItemRemovedOn",
                columns: table => new
                {
                    OrderItemRemoveOnId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RemoveOnIngredientId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderItemId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemRemovedOn", x => x.OrderItemRemoveOnId);
                    table.ForeignKey(
                        name: "FK_OrderItemRemovedOn_OrderItem_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItem",
                        principalColumn: "OrderItemId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_CategoryId",
                table: "MenuItem",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemAddOn_AddOnIngredientId",
                table: "MenuItemAddOn",
                column: "AddOnIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemAddOn_MenuItemId1",
                table: "MenuItemAddOn",
                column: "MenuItemId1");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemIngredient_IngredientId",
                table: "MenuItemIngredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemIngredient_MenuItemId1",
                table: "MenuItemIngredient",
                column: "MenuItemId1");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemSize_MenuItemId",
                table: "MenuItemSize",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemTag_MenuItemId",
                table: "MenuItemTag",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemTag_TagId",
                table: "MenuItemTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_MenuItemId",
                table: "OrderItem",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_SelectedSizeMenuItemSizeId",
                table: "OrderItem",
                column: "SelectedSizeMenuItemSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemAddOn_AddOnIngredientId",
                table: "OrderItemAddOn",
                column: "AddOnIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemAddOn_OrderItemId",
                table: "OrderItemAddOn",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemRemovedOn_OrderItemId",
                table: "OrderItemRemovedOn",
                column: "OrderItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItemAddOn");

            migrationBuilder.DropTable(
                name: "MenuItemIngredient");

            migrationBuilder.DropTable(
                name: "MenuItemTag");

            migrationBuilder.DropTable(
                name: "OrderItemAddOn");

            migrationBuilder.DropTable(
                name: "OrderItemRemovedOn");

            migrationBuilder.DropTable(
                name: "RemoveOnIngredient");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "AddOnIngredient");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "MenuItemSize");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "MenuItem");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
