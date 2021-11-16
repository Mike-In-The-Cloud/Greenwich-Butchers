using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GreButchersEFCore_V2.Models
{/// <summary>

/// this class extends that IdentityUser class from EF Core identity,
/// this allows me to add more fields to the ASPNETUser table.
/// 
/// </summary>
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Surname")]
        public string Surname { get; set; }

        [DisplayName("Date Of Birth")]
        public DateTime DOB { get; set; }

        [DisplayName("Building Name")]
        public string BuildingName { get; set; }

        [DisplayName("Address: First Line")]
        public string StreetAddress1 { get; set; }

        [DisplayName("Address: Second Line")]
        public string StreetAddress2 { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("Postcode")]
        public string PostCode { get; set; }

        [NotMapped]
        public bool IsSuperAdmin { get; set; }

        [NotMapped]
        [InverseProperty("ApplicationUser")]
        public virtual Employee Employee { get; set; }
        [NotMapped]
        [InverseProperty("ApplicationUser")]
        public virtual Customer Customer { get; set; }

    }
}
