using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Models
{
    public class AddOnIngredient
    {   public int AddId {get;set;}
        public int AddOnIngredientId { get; set; }
        public string? Name { get; set; }
        public decimal AdditionalPrice { get; set; } // السعر الإضافي للمكون
        
    }
}