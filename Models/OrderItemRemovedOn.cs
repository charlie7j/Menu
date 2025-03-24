using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Models
{
	public class OrderItemRemovedOn
	{
		// معرف سجل المكون الإضافي في الطلب
		[Key]
		public int OrderItemRemoveOnId { get; set; }
	
		// معرف المكون الإضافي من جدول RemoveOnIngredient
		public int RemoveOnIngredientId { get; set; }
	}
}