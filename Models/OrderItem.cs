using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
 
namespace Menu.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int MenuItemId { get; set; }
        public MenuItem? MenuItem { get; set; }
        public int Quantity { get; set; }
    
        // الحجم المحدد (إن وُجد)
        public int? SelectedSizeId { get; set; }
        public MenuItemSize? SelectedSize { get; set; }

        [NotMapped]
        public List<MenuItemSize?> ListSelectedSize { get; set; } = new List<MenuItemSize?>();

    
        // ملاحظة خاصة بهذا الصنف (مثلاً: "بدون مخلل، مع إضافة جبن")
        public string? ItemNote { get; set; }
    
        // قائمة المكونات الإضافية التي طلب إضافتها لهذا الصنف
        public List<OrderItemAddOn>? AddedAddOns { get; set; } //= new List<OrderItemAddOn>();
    
        // قائمة المكونات التي طلب الزبون إزالتها من هذا الصنف
        public List<OrderItemRemovedOn>? RemovedAddOns { get; set; } //= new List<OrderItemRemovedOn>();

    }
}