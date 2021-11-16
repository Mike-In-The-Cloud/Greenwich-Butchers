using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreButchersEFCore_V2.Models
{
    public partial class ModifiedBy
    {
        [Column("ModifiedBy_Id")]
        public int ModifiedById { get; set; }

        [Column("ModifiedBy_Date")]
        [Display(Name = "Modified Date")]
        [StringLength(20)]
        public string ModifiedByDate { get; set; }

        [Column("FK_Employee_Id")]
        [Display(Name = "Employee Id")]
        public int? FkEmployeeId { get; set; }

        [Column("FK_BulkOrder_Id")]
        [Display(Name = "Bulk Order id")]
        public int? FkBulkOrderId { get; set; }

        [Column("ModifiedBy_First")]
        [Display(Name = "First Modification")]
        public int? ModifiedByFirst { get; set; }

        [ForeignKey("FkBulkOrderId")]
        [InverseProperty("ModifiedBy")]
        public virtual BulkOrder FkBulkOrder { get; set; }
        [ForeignKey("FkEmployeeId")]
        [InverseProperty("ModifiedBy")]
        public virtual Employee FkEmployee { get; set; }
    }
}
