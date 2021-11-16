using GreButchersEFCore_V2.Models;
using GreButchersEFCore_V2.Models.ViewModels;
using GreButchersEFCore_V2.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GreButchersEFCore_V2.Areas.OrderHistory.Controllers
{
    [Area("OrderHistory")]
    [Authorize(Roles = StaticDetails.AdminUser + "," + StaticDetails.SuperAdminUser + "," + StaticDetails.CustomerUser)]
    public class InvoiceController : Controller
    {

        private readonly GreButchersContext _db;

        private readonly UserManager<ApplicationUser> _userManager;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        public InvoiceViewModel InvoiceVM { get; set; }

        public InvoiceController(GreButchersContext db,
            UserManager<ApplicationUser> userManager)
        {
            _db = db;

            _userManager = userManager;

            InvoiceVM = new InvoiceViewModel()
            {
                BulkOrder = new BulkOrder(),
                SupplierContacted = new SupplierContacted(),
                BulkOrderItem = new List<BulkOrderItem>(),
                Customer = new Models.Customer()

            };


        }
        // GET: /<controller>/
        public async Task<IActionResult> Index(int id)
        {
            try
            {
                // saving the upto date selections from the customer to the database
                SupplierContacted supplierContacted = new SupplierContacted();
                // finds supplier contacted id from the parameter passed to index
                supplierContacted = await _db.SupplierContacted.FindAsync(id);
                // sets user selected to true
                supplierContacted.SupplierContactedUserSelected = true;
                // updates context
                _db.SupplierContacted.Update(supplierContacted);
                // gets the bulkorder related table data
                BulkOrder bulkOrder = new BulkOrder();
                // finds the row by the FK of bulkorder in the supplier contacted table
                bulkOrder = await _db.BulkOrder.FindAsync(supplierContacted.FkBulkOrderId);
                // quick calculation to find the profit that will be made on this order
                bulkOrder.BulkOrderProfit =  (supplierContacted.SupplierContactedQuote * Convert.ToDecimal(bulkOrder.BulkOrderMargin)) - supplierContacted.SupplierContactedQuote;
                // sets the status to 2(Complete)
                bulkOrder.BulkOrderStatus = 2;
                // set bulk order completion date
                bulkOrder.BulkOrderCompletionDate = DateTime.Now.ToString("dd/MM/yyyy");
                // updates the bulkorder context
                _db.BulkOrder.Update(bulkOrder);
                // saves changes to the database
                await _db.SaveChangesAsync();
                int BulkOrderIdFromDb = InvoiceVM.BulkOrder.BulkOrderId;

                InvoiceVM.BulkOrder = await _db.BulkOrder
                                                 .FindAsync(supplierContacted.FkBulkOrderId);
                InvoiceVM.SupplierContacted = await _db.SupplierContacted
                                                .FindAsync(id);

                InvoiceVM.BulkOrderItem = await _db.BulkOrderItem
                                            .Include(m => m.FkProduct)
                                                .ThenInclude(c => c.FkCategory)
                                            .Where(m => m.FkBulkOrderId == bulkOrder.BulkOrderId)
                                            .ToListAsync();
                InvoiceVM.Customer = await _db.Customer
                                            .Include(m => m.ApplicationUser)
                                            .FirstOrDefaultAsync(m => m.CustomerId == bulkOrder.FkCustomerId);
                                            
                return View(InvoiceVM);


            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }

            // if we get here something went wrong
            return NotFound();
        }
    }
}
