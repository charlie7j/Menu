using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Models
{
	public class Ingredient
	{
		public int IngredientId { get; set; }
		public string? Name { get; set; }
		
		[NotMapped]
		public decimal ExtraPrice {get;set;} = 0;

		[NotMapped]
		public bool PrimaryStatus {get;set;}
		[NotMapped]
		public bool SubStatus {get;set;}
		[NotMapped]
		public bool AdditionalStatus {get;set;}
	}
}