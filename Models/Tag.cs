using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Models
{
    public class Tag
    {
        public int TagId { get; set; } // معرف التاغ
        public string? Name { get; set; } // اسم التاغ (مثلاً: حار، نباتي، قليل السعرات...)
        public ICollection<MenuItemTag> MenuItemTags { get; set; } // علاقة مع الأصناف

        public Tag()
        {
            MenuItemTags = new List<MenuItemTag>();
        }
    }
}