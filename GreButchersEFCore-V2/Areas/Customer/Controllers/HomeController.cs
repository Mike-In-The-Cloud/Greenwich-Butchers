using GreButchersEFCore_V2.Extensions;
using GreButchersEFCore_V2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GreButchersEFCore_V2.Areas.Customer.Controllers
{
    // area defined as customer
    [Area("Customer")]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // create the dependancy injection
        private readonly GreButchersContext _db;

        // constructor with dependancy injection using DbContext
        public HomeController(GreButchersContext db)
        {
            _db = db;
        }
        // gets the list of all the products in the database
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        // controller with parameter id, id is the search string 
        // that filters the results 
        public async Task<IActionResult> Products(string id)
        {
            // this includes the product and category so the search function can 
            // filter the category for extra functionality
            var productlist = await _db.Product
                .Include(m => m.FkCategory)
                .ToListAsync()
                .ConfigureAwait(false);
            // this is the search fucntion for the products 
            // if the search stirng 
            if (!String.IsNullOrEmpty(id))
            {
                // products list filtered on the search string
                productlist = productlist
                    // where the product name contains the passed parameter
                    .Where(s => s.ProductName
                                .Contains(id, StringComparison.OrdinalIgnoreCase)
                        // or the parameter is contained in the product description
                        || s.ProductDescription
                                  // also ignores the case-sensitivity
                                  .Contains(id, StringComparison.OrdinalIgnoreCase)
                        // a 3rd or clause that searches the category
                        || s.FkCategory.CategoryName
                            // ignoring the case-sensitivity
                            .Contains(id, StringComparison.OrdinalIgnoreCase))
                    // returns the filtered query to a list
                    .ToList();
            }
            // return the view of the list to the page
            return View(productlist);
        }


        // GET Action for details
        public async Task<IActionResult> Details(int id)
        {
            // new Stock Model
            Stock products = new Stock();
            // gets the model data 
            var product = await _db.Stock
                // gets the releated data from the product model
                .Include(m => m.FkProduct)
                // gets the releated data from the category model
                .Include(m => m.FkProduct.FkCategory)
                // selects the product where the id matches the paramater passed
                .Where(m => m.FkProduct.ProductId == id)
                // creates a list 
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
            // stock model object with related data is passed to the model
            products = product;
            // passes the model to the razor page
            return View(products);
        }

        // POST Action for details
        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public IActionResult DetailsPost(int id)
        {
            List<int> LstShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if (LstShoppingCart == null)
            {
                LstShoppingCart = new List<int>();
            }
            // add id to the shopping cart
            LstShoppingCart.Add(id);
            HttpContext.Session.Set("ssShoppingCart", LstShoppingCart);

            return RedirectToAction("Products", "Home", new { area = "Customer" });
        }

        // removes item from shopping cart
        public IActionResult Remove(int id)
        {
            // session list
            List<int> LstShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            // if the shopping cart count is greater then zero
            if (LstShoppingCart.Count > 0)
            {
                //if the session contains the id of the product page
                if (LstShoppingCart.Contains(id))
                {
                    // remove the id from the shopping cart
                    LstShoppingCart.Remove(id);
                }

            }
            // set the session again
            HttpContext.Session.Set("ssShoppingCart", LstShoppingCart);
            // return to index page
            return RedirectToAction(nameof(Index));
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}