using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Models
{
    public class OrderItemAddOn
    {
        // معرف سجل المكون الإضافي في الطلب
        public int OrderItemAddOnId { get; set; }
    
        // معرف المكون الإضافي من جدول AddOnIngredient
        public int? AddOnIngredientId { get; set; }
    
        // الكائن المرتبط بالمكون الإضافي (مثلاً: جبن، صلصة إضافية، الخ)
        public AddOnIngredient? AddOnIngredient { get; set; }
    
        // ملاحظة توضيحية خاصة بالمكون الإضافي (مثلاً: "إضافة الجبن" أو أي ملاحظة أخرى)
        public string? Note { get; set; }
    }
}