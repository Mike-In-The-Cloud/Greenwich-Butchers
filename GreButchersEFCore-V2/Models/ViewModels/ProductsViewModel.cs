using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreButchersEFCore_V2.Models.ViewModels
{
    public class ProductsViewModel
    {
        public Product Products { get; set; }
        public List<Category> Categories {get; set;}
        public Stock Stocks { get; set; }
    }
}
