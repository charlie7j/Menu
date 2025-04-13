using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Models
{
	public class Size
	{
		public int SizeId { get; set; }
		public string? Name { get; set; } // صغير، وسط، كبير
	
		[NotMapped]
		public decimal ExtraPrice {get;set;} 
	
	}
}