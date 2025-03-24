using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int TableNumber { get; set; }      // رقم الطاولة
        public DateTime OrderDateTime { get; set; } // تاريخ ووقت الطلب
        public string? CustomerNote { get; set; }    // ملاحظات عامة للطلب (إن وُجدت)
    
        // قائمة الأصناف المطلوبة ضمن الطلب
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}