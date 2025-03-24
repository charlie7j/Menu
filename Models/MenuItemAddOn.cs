using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Models
{
	public class MenuItemAddOn
	{
		[Key]
		public int AddOnId { get; set; }
		public int MenuItemId { get; set; }
		public MenuItem? MenuItem { get; set; }
		public int AddOnIngredientId { get; set; }
		public AddOnIngredient? AddOnIngredient { get; set; }
	}
}