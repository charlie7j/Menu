using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Menu.Models
{
	public class MenuItemAddOn
	{
	 
		[Key]
		public int AddOnId { get; set; }

		// مفتاح أجنبي إلى MenuItem
		public int MenuItemId { get; set; }

		// مفتاح أجنبي إلى AddOnIngredient
		public int AddOnIngredientId { get; set; }

		// العلاقات التنقلية
		[ForeignKey("MenuItemId")]
		public virtual MenuItem? MenuItem { get; set; }

		[ForeignKey("AddOnIngredientId")]
		public virtual AddOnIngredient? AddOnIngredient { get; set; }

	}
}