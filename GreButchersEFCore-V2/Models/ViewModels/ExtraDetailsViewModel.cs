using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreButchersEFCore_V2.Models.ViewModels
{
    public class ExtraDetailsViewModel
    {

        public BulkOrder BulkOrder { get; set; }
        public ModifiedBy ModifiedBy { get; set; }
        public List<ModifiedBy> ModifiedByList { get; set; }
        public Employee Employee { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
