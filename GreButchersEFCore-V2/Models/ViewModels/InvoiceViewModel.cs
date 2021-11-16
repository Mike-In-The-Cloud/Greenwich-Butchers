using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreButchersEFCore_V2.Models.ViewModels
{
    public class InvoiceViewModel
    {
        public BulkOrder BulkOrder { get; set; }
        public SupplierContacted SupplierContacted { get; set; }
        public List<BulkOrderItem> BulkOrderItem {get; set;}
        public Customer Customer { get; set; }
    }
}
