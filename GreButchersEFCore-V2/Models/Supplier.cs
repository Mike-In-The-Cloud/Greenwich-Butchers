using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreButchersEFCore_V2.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            SupplierContacted = new HashSet<SupplierContacted>();
        }

        [Column("Supplier_Id")]
        public int SupplierId { get; set; }

        [Column("Supplier_Name")]
        [Display(Name = "Main Contact Name")]
        [StringLength(50)]
        public string SupplierName { get; set; }

        [Column("Supplier_ContactNumber")]
        [Display(Name = "Telephone Number")]
        [StringLength(20)]
        public string SupplierNumber { get; set; }

        [Column("Supplier_Email")]
        [Display(Name = "E-Mail Address")]
        [StringLength(100)]
        public string SupplierEmail { get; set; }

        [Column("Supplier_Company")]
        [Display(Name = "Company Name")]
        [StringLength(40)]
        public string SupplierCompany { get; set; }


        [InverseProperty("FkSuppler")]
        public virtual ICollection<SupplierContacted> SupplierContacted { get; set; }
    }
}
