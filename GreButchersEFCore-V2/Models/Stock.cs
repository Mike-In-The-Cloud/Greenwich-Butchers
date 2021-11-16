using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreButchersEFCore_V2.Models
{
    public partial class Stock
    {
        [Column("Stock_Id")]
        public int StockId { get; set; }

        [Column("Stock_Shop")]
        [Display(Name = "Shop Stock")]
        public int? StockShop { get; set; }

        [Column("Stock_Warehouse")]
        [Display(Name = "Warehouse Stock")]
        public int? StockWarehouse { get; set; }

        [Column("FK_Product_Id")]
        public int FkProductId { get; set; }

        [ForeignKey("FkProductId")]
        [InverseProperty("Stock")]
        public virtual Product FkProduct { get; set; }
    }
}
