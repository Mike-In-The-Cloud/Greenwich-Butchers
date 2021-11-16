using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreButchersEFCore_V2.Models
{
    public partial class BulkOrder
    {
        public BulkOrder()
        {
            BulkOrderItem = new HashSet<BulkOrderItem>();
            ModifiedBy = new HashSet<ModifiedBy>();
            SupplierContacted = new HashSet<SupplierContacted>();
        }

        [Column("BulkOrder_Id")]
        [Display(Name ="Order ID")]
        public int BulkOrderId { get; set; }

        [Column("BulkOrder_Status")]
        [Display(Name ="Order Status")]
        public int BulkOrderStatus { get; set; }

        [Column("BulkOrder_CreationDate")]
        [Display(Name = "Creation Date")]
        [StringLength(50)]
        public string BulkOrderCreationDate { get; set; }

        [Column("BulkOrder_CompletionDate")]
        [Display(Name = "Completion Date")]
        [StringLength(50)]
        public string BulkOrderCompletionDate { get; set; }

        [Column("BulkOrder_Margin")]
        [Display(Name = "Margin")]
        public double BulkOrderMargin { get; set; }

        [Column("FK_Customer_Id")]
        public int? FkCustomerId { get; set; }

        [Column("BulkOrder_Profit", TypeName = "decimal(18, 2)")]
        [Display(Name = "Profit")]
        public decimal? BulkOrderProfit { get; set; }


        [ForeignKey("FkCustomerId")]
        [InverseProperty("BulkOrder")]
        public virtual Customer FkCustomer { get; set; }
        [InverseProperty("FkBulkOrder")]
        public virtual ICollection<BulkOrderItem> BulkOrderItem { get; set; }
        [InverseProperty("FkBulkOrder")]
        public virtual ICollection<ModifiedBy> ModifiedBy { get; set; }
        [InverseProperty("FkBulkOrder")]
        public virtual ICollection<SupplierContacted> SupplierContacted { get; set; }
    }
}
