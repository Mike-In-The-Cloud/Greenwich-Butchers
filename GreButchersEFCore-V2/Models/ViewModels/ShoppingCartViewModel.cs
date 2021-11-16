using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreButchersEFCore_V2.Models.ViewModels
{
    /// <summary>
    /// This is a view models for multiple models
    /// in particular the shopping cart 
    /// </summary>
    public class ShoppingCartViewModel 
    {
       
        // list of the products model
        public List<Product> Products  { get; set; }
        // new stock model
        public Stock Stock { get; set; }
        
        // new bulkorder model
        public BulkOrder BulkOrder { get; set; }

        // new bulk order item model/
         //this adds the items to a table linked to the bulk order
        public BulkOrderItem BulkOrderItems { get; set; }

        public IList<BulkOrderItem> OrderItems { get; set; }

        // customer model added to this view model
        public Customer Customer { get; set; }

    }
}
