using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Menu.Models
{
    public class AddOnIngredient
    {
        [Key]
        public int? AddOnIngredientId { get; set; }

        [ForeignKey("MenuItemIngredient")]  // Add this attribute
        [Column("MenuItemIngredientId")]
        public int? MenuItemIngredientId { get; set; }

        // Navigation property
        public MenuItemIngredient MenuItemIngredient { get; set; }

        public string? Name { get; set; }

        // public decimal AdditionalPrice { get; set; } // السعر الإضافي للمكون

        // العلاقات التنقلية
        public virtual ICollection<MenuItemAddOn>? MenuItemAddOns { get; set; }
        public virtual ICollection<OrderItemAddOn>? OrderItemAddOns { get; set; }

    }


}