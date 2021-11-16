using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreButchersEFCore_V2.Models
{
    public partial class BulkOrderItem
    {
        

        [Column("BulkOrderItem_Id")]
        public int BulkOrderItemId { get; set; }

        [Column("FK_Product_Id")]
        public int FkProductId { get; set; }


        [Column("BulkOrderItem_Quantity")]
        [DisplayName("Quantity")]
        public int? BulkOrderItemQuantity { get; set; }

        [Column("FK_BulkOrder_Id")]
        public int? FkBulkOrderId { get; set; }

        [ForeignKey("FkBulkOrderId")]
        [InverseProperty("BulkOrderItem")]
        public virtual BulkOrder FkBulkOrder { get; set; }

        [ForeignKey("FkProductId")]
        [InverseProperty("BulkOrderItem")]
        public virtual Product FkProduct { get; set; }

        
    }
}
