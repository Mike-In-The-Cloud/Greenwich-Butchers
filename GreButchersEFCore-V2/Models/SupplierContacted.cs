using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// This model is a link between the bulkorder and the supplier, as there can be many suppliers
/// generating quotes for a single bulk order.
/// The data that this class holds lets the application track the date that the suppler has 
/// been contacted and the reply date, the quote that the supplier has given and 
/// which quote to display back to the user
/// </summary>
namespace GreButchersEFCore_V2.Models
{
    public partial class SupplierContacted
    {
        [Column("SupplierContacted_Id")]
        public int SupplierContactedId { get; set; }

        [Column("SupplierContacted_Date")]
        [Display(Name ="Contacted Date")]
        [StringLength(20)]
        public string SupplierContactedDate { get; set; }

        [Column("SupplierContacted_Reply")]
        [Display(Name = "Supplier Reply")]
        public bool SupplierContactedReply { get; set; }

        [Column("SupplerContacted_ReplyDate")]
        [Display(Name ="Reply Date")]
        [StringLength(20)]
        public string SupplerContactedReplyDate { get; set; }

        [Column("SupplierContacted_Quote", TypeName = "decimal(18, 2)")]
        [Display(Name ="Quote")]
        public decimal? SupplierContactedQuote { get; set; }

        [Column("SupplierContacted_DisplayToUser")]
        [Display(Name ="Display to User")]
        public bool SupplierContactedDisplayToUser { get; set; }

        [Column("SupplierContacted_UserSelected")]
        [Display(Name ="Select Quote")]
        public bool SupplierContactedUserSelected { get; set; }

        [Column("FK_BulkOrder_Id")]
        public int? FkBulkOrderId { get; set; }

        [Column("FK_Suppler_Id")]
        public int FkSupplerId { get; set; }

        [ForeignKey("FkBulkOrderId")]
        [InverseProperty("SupplierContacted")]
        public virtual BulkOrder FkBulkOrder { get; set; }
        [ForeignKey("FkSupplerId")]
        [InverseProperty("SupplierContacted")]
        public virtual Supplier FkSuppler { get; set; }
    }
}
