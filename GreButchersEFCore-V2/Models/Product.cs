using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreButchersEFCore_V2.Models
{
    public partial class Product
    {
        public Product()
        {
            BulkOrderItem = new HashSet<BulkOrderItem>();
            InShopSales = new HashSet<InShopSales>();
            Stock = new HashSet<Stock>();
        }

        [Column("Product_Id")]
        public int ProductId { get; set; }

        [Required]
        [DisplayName("Product Name")]
        [Column("Product_Name")]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Column("Product_Price", TypeName = "decimal(18, 2)")]
        [DisplayName("Price")]
        public decimal ProductPrice { get; set; }

        [Column("Product_Description")]
        [StringLength(150)]
        [DisplayName("Description")]
        public string ProductDescription { get; set; }

        [Column("Product_Weight", TypeName = "decimal(18, 2)")]
        [DisplayName("Weight(Kg)")]
        public decimal ProductWeight { get; set; }

        [Column("Product_Image")]
        public string ProductImage { get; set; }
        [Column("FK_Category_Id")]
        public int FkCategoryId { get; set; }

        [ForeignKey("FkCategoryId")]
        [InverseProperty("Product")]
        public virtual Category FkCategory { get; set; }
        [InverseProperty("FkProduct")]
        public virtual ICollection<BulkOrderItem> BulkOrderItem { get; set; }
        [InverseProperty("FkProduct")]
        public virtual ICollection<InShopSales> InShopSales { get; set; }
        [InverseProperty("FkProduct")]
        public virtual ICollection<Stock> Stock { get; set; }
        [NotMapped]
        public virtual BulkOrderItem BulkOrderItems { get; set; }
    }
}
