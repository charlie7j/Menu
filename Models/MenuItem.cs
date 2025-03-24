using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Models
{
	public class MenuItem
	{
		public int MenuItemId { get; set; } // معرف العنصر
		public string? Name { get; set; } // الاسم
		public decimal Price { get; set; } // السعر
		public string? Description { get; set; } // الوصف
		public string? ImageUrl { get; set; } // رابط الصورة

		public int CategoryId { get; set; }
		public Category? Category { get; set; }

		//المكونات لهذة الوجبة او العنصر
		public List<MenuItemIngredient> MenuItemIngredients { get; set; } = new List<MenuItemIngredient>();
		
		[NotMapped]
		public List<Ingredient> SelectedIngredients {get;set;} = new List<Ingredient>();
		
		
		public ICollection<MenuItemTag> MenuItemTags { get; set; } // علاقة مع Tags
		
		
		// قائمة الأحجام المتاحة لهذا الصنف (اختياريًا)
		public List<MenuItemSize> MenuItemSize { get; set; } = new List<MenuItemSize>();
		// قائمة معرفات الأحجام المختارة
		[NotMapped]
		public List<Size> SelectedSize { get; set; } = new List<Size>();

 		// قائمة المكونات الإضافية التي يمكن إضافتها لهذا الصنف
		public ICollection<MenuItemAddOn>? MenuItemAddOns { get; set; }
		public MenuItem()
		{
			MenuItemIngredients = new List<MenuItemIngredient>();
			MenuItemTags = new List<MenuItemTag>();
		}
	}
}