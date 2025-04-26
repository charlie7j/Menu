using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Menu.Models;

namespace Menu.Data;

public class ApplicationDbContext : IdentityDbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
	{
	}
 
	public DbSet<AddOnIngredient>? AddOnIngredient { get; set; }
	public DbSet<Category>? Category { get; set; }
	public DbSet<Ingredient>? Ingredient { get; set; }
	public DbSet<MenuItem>? MenuItem { get; set; }
	public DbSet<MenuItemAddOn>? MenuItemAddOn { get; set; }

	public DbSet<MenuItemIngredient>? MenuItemIngredient { get; set; }
	public DbSet<MenuItemSize>? MenuItemSize { get; set; }
	public DbSet<MenuItemTag>? MenuItemTag { get; set; }
	public DbSet<Order>? Order { get; set; }
	public DbSet<OrderItem>? OrderItem { get; set; }

	public DbSet<OrderItemAddOn>? OrderItemAddOn { get; set; }
	public DbSet<OrderItemRemovedOn>? OrderItemRemovedOn { get; set; }
	public DbSet<RemoveOnIngredient>? RemoveOnIngredient { get; set; }
	public DbSet<Size>? Size { get; set; }
	public DbSet<Tag>? Tag { get; set; }

}
