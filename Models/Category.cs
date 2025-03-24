using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Models
{
    public class Category
    {
        public int CategoryId { get; set; } // معرف الفئة
        public string? Name { get; set; } // اسم الفئة (مثل: ساندويشات، مشروبات، حلويات...)
        public ICollection<MenuItem> MenuItems { get; set; }

        public Category()
        {
            MenuItems = new List<MenuItem>();
        }   
    }
}