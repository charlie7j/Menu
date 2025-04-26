using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Menu.Models
{
    public class OrderItemAddOn
    {
        // معرف سجل المكون الإضافي في الطلب


        // معرف المكون الإضافي من جدول AddOnIngredient


        // الكائن المرتبط بالمكون الإضافي (مثلاً: جبن، صلصة إضافية، الخ)


        // ملاحظة توضيحية خاصة بالمكون الإضافي (مثلاً: "إضافة الجبن" أو أي ملاحظة أخرى)



        [Key]
        public int OrderItemAddOnId { get; set; }

        // مفتاح أجنبي إلى AddOnIngredient
        public int AddOnIngredientId { get; set; }
        
        // العلاقات التنقلية
        [ForeignKey("AddOnIngredientId")]
        public virtual AddOnIngredient? AddOnIngredient { get; set; }
        

        public string? Note { get; set; }

        // مفتاح أجنبي إلى OrderItem
        public int OrderItemId { get; set; }

       

        [ForeignKey("OrderItemId")]
        public virtual OrderItem? OrderItem { get; set; }


    }
}