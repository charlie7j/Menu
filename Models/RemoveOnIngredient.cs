using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Models
{
	public class RemoveOnIngredient
	{
		public int RemoveID {get;set;}
		public int RemoveOnIngredientId { get; set; }
		public string? Name { get; set; }
	}
}