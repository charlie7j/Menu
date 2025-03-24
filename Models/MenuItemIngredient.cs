using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Models
{
	public class MenuItemIngredient
	{
		[Key]
		public int MenuItemId { get; set; }
		public MenuItem? MenuItem { get; set; }

		public int IngredientId { get; set; }
		public Ingredient? Ingredient { get; set; }
		
		public decimal ExtraPrice {get;set;} = 0;

		public bool PrimaryStatus {get;set;}
		public bool SubStatus {get;set;}
		public bool AdditionalStatus {get;set;}

	}
}