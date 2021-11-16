using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreButchersEFCore_V2.Models.ViewModels
{   
    
    public class BulkOrderViewModel
    {
        public BulkOrder BulkOrder {get;set;}
        public List<BulkOrder> BulkOrderList { get; set; }
        public List<BulkOrderItem> BulkOrderItem { get; set; }
        public List<Product> ProductsList { get; set; }
        public List<SupplierContacted> SupplierContactedList { get; set; }
        public SupplierContacted SupplierContacted { get; set; }
        public List<Supplier> SupplierList { get; set; }
        //public Supplier Supplier { get; set; }
        public ModifiedBy ModifiedBy { get; set; }
        public Customer Customer { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
