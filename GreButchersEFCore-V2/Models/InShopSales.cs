using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreButchersEFCore_V2.Models
{
    public partial class InShopSales
    {
        [Column("InShopSales_Id")]
        [Display(Name = "Sale Id")]
        public int InShopSalesId { get; set; }

        [Required]
        [Column("InShopSales_Date")]
        [Display(Name = "Sale Date")]
        [StringLength(20)]
        public string InShopSalesDate { get; set; }

        [Column("InShopSales_Total", TypeName = "decimal(18, 2)")]
        [Display(Name = "Total")]
        public decimal? InShopSalesTotal { get; set; }

        [Column("FK_Product_Id")]
        [Display(Name = "Product Id")]
        public int? FkProductId { get; set; }

        [Column("FK_Employee_Id")]
        [Display(Name = "Employee Id")]
        public int? FkEmployeeId { get; set; }

        [Column("InShopSales_Quantity")]
        [Display(Name = "Item Quantity")]
        public int? InShopSalesQuantity { get; set; }

        [ForeignKey("FkEmployeeId")]
        [InverseProperty("InShopSales")]
        public virtual Employee FkEmployee { get; set; }
        [ForeignKey("FkProductId")]
        [InverseProperty("InShopSales")]
        public virtual Product FkProduct { get; set; }
    }
}
