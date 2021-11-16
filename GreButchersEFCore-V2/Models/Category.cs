using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreButchersEFCore_V2.Models
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        [Column("Category_Id")]
        public int CategoryId { get; set; }

        [Column("Category_Name")]
        [DisplayName("Category")]
        [StringLength(50)]
        public string CategoryName { get; set; }

        [InverseProperty("FkCategory")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
