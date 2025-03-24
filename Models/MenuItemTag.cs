using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Models
{
	public class MenuItemTag
	{   
		[Key]
		public int MenuItemTagId { get; set; }
		public MenuItem? MenuItem { get; set; }

		public int TagId { get; set; }
		public Tag? Tag { get; set; }
	}
}