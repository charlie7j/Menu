using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Models
{
	public class MenuItemSize
	{
		[Key]
		public int MenuItemSizeId { get; set; }
		//public MenuItem MenuItem { get; set; }
		
		public int MenuItemId { get; set;}

		public int? SizeId { get; set; } // مفتاح أجنبي nullable
		
		public Size? Size { get; set; }
		public decimal PriceAdjustment { get; set; } // الفرق في السعر عند اختيار الحجم
	}
}