using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreButchersEFCore_V2.Models
{
    public partial class Employee
    {
        public Employee()
        {
            InShopSales = new HashSet<InShopSales>();
            ModifiedBy = new HashSet<ModifiedBy>();
        }

        [Column("Employee_Id")]
        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }

        [Required]
        [Column("Employee_StartDate")]
        [Display(Name = "Start Date")]
        [StringLength(50)]
        public DateTime EmployeeStartDate { get; set; }

        [Column("Employee_EndDate")]
        [Display(Name = "End Date")]
        [StringLength(50)]
        public string EmployeeEndDate { get; set; }

        [Column("Employee_Type")]
        [Display(Name = "Employement Type")]
        [StringLength(50)]
        public string EmployeeType { get; set; }
        

        [InverseProperty("FkEmployee")]
        public virtual ICollection<InShopSales> InShopSales { get; set; }
        [InverseProperty("FkEmployee")]
        public virtual ICollection<ModifiedBy> ModifiedBy { get; set; }

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
