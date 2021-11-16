using GreButchersEFCore_V2.Extensions;
using GreButchersEFCore_V2.Models;
using GreButchersEFCore_V2.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GreButchersEFCore_V2.Controllers
{
    // defines the controler to the customer area
    [Area("Customer")]

    public class ShoppingCartController : Controller
    {
        // uses the application database context file
        private readonly GreButchersContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        [BindProperty]
        public ShoppingCartViewModel ShoppingCartVM { get; set; }
        // constructor method with dependancy injection of the 
        // application database context file.
        public ShoppingCartController(GreButchersContext db,
            UserManager<ApplicationUser> userManager)
        {

            // initilise the dependancy injection
            _db = db;
            // initilise the list of product model
            ShoppingCartVM = new ShoppingCartViewModel()
            {
                Products = new List<Product>()
            };

            _userManager = userManager;
        }



        // Get Index Shopping cart
        public async Task<IActionResult> Index()
        {
            // list of intergers for the shopping cart from the sesson
            List<int> lstShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");

            if (lstShoppingCart != null)
            {
                // if statement  with nested foreach to loop though the session, using the count greater then 0
                if (lstShoppingCart.Count > 0)
                {
                    // of each of the ids in the shopping cart, populate the ShoppingCartViewModel
                    foreach (int item in lstShoppingCart)
                    {
                        // gets the products from the database
                        Product prod = await _db.Product
                            // includes the category table using eager loading
                            .Include(m => m.FkCategory)
                            // where the id of the product matches the int in the session
                            .Where(m => m.ProductId == item)
                            // finds the item asyn
                            .FirstOrDefaultAsync();
                        // adds the data to the view model
                        ShoppingCartVM.Products.Add(prod);
                    }
                }
            }
            else
            {

            }

            // passes the final shopping cart view model to the view 
            return View(ShoppingCartVM);
        }

        // controller to remove item from the shopping cart when viewing shopping cart contents
        // removes via a id parameter passed into it
        public IActionResult Remove(int id)
        {
            // list of intergers for the shopping cart from the sesson
            List<int> lstShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");

            // check the shopping cart session has items
            if (lstShoppingCart.Count > 0)
            {
                // checks for the id that is passed
                if (lstShoppingCart.Contains(id))
                {
                    // removes item from the shopping cart via the id passed as a parameter
                    lstShoppingCart.Remove(id);
                }
            }
            // sets the shopping cart session to the variable lstShoppingCart after removal of item
            HttpContext.Session.Set("ssShoppingCart", lstShoppingCart);

            // if the shopping cart is empty redirect to home page
            if (lstShoppingCart.Count == 0)
            {
                // redirect to homepage
                return RedirectToAction("Products", "Home", new { area = "Customer" });
            }
            // redicrect to shoppingcart index view
            return RedirectToAction(nameof(Index));
        }


        // Returns the view of the bulk order to be confirmed by the customer.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(ShoppingCartViewModel model)
        {
            
            // list of intergers for the shopping cart from the sesson
            List<int> lstShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            // using asp.net identity and the UserManager class, this variable is set to hte 
            // currently logged in user
            var user = await GetCurrentUserAsync();
            // gets/sets the application user ID
            var userId = user?.Id;
            // new customer object
            Customer customer = new Customer();
            // variable to hold the customer details, find the customer details on the 
            // application user id
            var customers = await _db.Customer.Where(c => c.ApplicationUserId == userId)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
            // sets the variable with customer data to the customer model object.
            customer = customers;

            // new bulk order object with data to be saved.
            BulkOrder NewOrder = new BulkOrder
            {
                BulkOrderCreationDate = DateTime.Now.ToShortDateString(),
                BulkOrderStatus = 0,
                FkCustomerId = customers.CustomerId,
                BulkOrderMargin = 10
            };

            // save bulk order to the database
            _db.BulkOrder.Add(NewOrder);
            //save changes 
            await _db.SaveChangesAsync().ConfigureAwait(false);
            // as i have saved the bulkorder to the database i have 
            // access to the newly created primary key for the bulk order.
            // i can then use this in a loop that will have the items and the order it 
            // is linked to 
            int BulkOrderIdFromDB = NewOrder.BulkOrderId;
            // int intitated with value of 0 to be used in a foreach loop
            int i = 0;
            // loops through the shopping cart session 
            foreach (var item in lstShoppingCart)
            {
                // new bulkorderitem object created 
                BulkOrderItem OrderItem = new BulkOrderItem
                {
                    // foreign key of the item is stored in the session, set to object
                    FkProductId = item,
                    // bulkorder id is set
                    FkBulkOrderId = BulkOrderIdFromDB,
                    // using the variable instancated, this selects the correct input
                    // textbox and adds the quantity to the database
                    BulkOrderItemQuantity = model.OrderItems[i].BulkOrderItemQuantity
                };
                // increments the variable by 1
                i++;
                _db.BulkOrderItem.Add(OrderItem);
            }
            // saves changes to the database
            await _db.SaveChangesAsync().ConfigureAwait(false);

            return RedirectToAction("Confirm", new { id = BulkOrderIdFromDB });

        }


        //get method for confirm view
        public async Task<IActionResult> Confirm(int id)
        {
            // clears the shopping cart session.
            HttpContext.Session.Remove("ssShoppingCart");


            var OrderItems = await _db.BulkOrderItem
                .Include(m => m.FkProduct)
                .Include(m => m.FkBulkOrder)
                .Include(m => m.FkBulkOrder.FkCustomer)
                .Where(m => m.FkBulkOrderId == id)
                .ToListAsync();

            return View(OrderItems.ToList());
        }

    }
}
