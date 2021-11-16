using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreButchersEFCore_V2.Models
{
    public partial class Customer
    {
        public Customer()
        {
            BulkOrder = new HashSet<BulkOrder>();
        }

        [Column("Customer_Id")]
        public int CustomerId { get; set; }
        
        
        [Column("Customer_CompanyName")]
        [Display(Name ="Company Name")]
        [StringLength(30)]
        public string CustomerCompanyName { get; set; }

        [InverseProperty("FkCustomer")]
        public virtual ICollection<BulkOrder> BulkOrder { get; set; }


        //  ID from the AspNetUsers table 
        public string ApplicationUserId { get; set; }

        
        // the foreignkey attribute is used to configure a foreign key in the 
        // relationship between 2 entities
        [ForeignKey("ApplicationUserId")]
        // the public virtual attribute makes it so the initialsation of 
        // ApplicationUser does not happen until it is required.
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
