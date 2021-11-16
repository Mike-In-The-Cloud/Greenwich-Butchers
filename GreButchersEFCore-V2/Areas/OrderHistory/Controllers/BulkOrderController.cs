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

namespace GreButchersEFCore_V2.Areas.OrderHistory.Controllers
{
    [Area("OrderHistory")]
    [Authorize(Roles = StaticDetails.AdminUser + "," + StaticDetails.SuperAdminUser + "," + StaticDetails.CustomerUser)]
    public class BulkOrderController : Controller
    {

        // appliaction database context
        private readonly GreButchersContext _db;

        private readonly UserManager<ApplicationUser> _userManager;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [BindProperty]
        public BulkOrderViewModel BulkOrderVM { get; set; }


        public BulkOrderController(GreButchersContext db,
            UserManager<ApplicationUser> userManager)
        {
            _db = db;

            _userManager = userManager;

            BulkOrderVM = new BulkOrderViewModel()
            {
                BulkOrder = new BulkOrder(),
                BulkOrderItem = new List<BulkOrderItem>(),
                ProductsList = new List<Product>(),
                SupplierContactedList = new List<SupplierContacted>(),
                Customer = new Models.Customer(),
                ApplicationUser = new ApplicationUser()

            };

        }

        /// <summary>
        /// 
        /// get method for the order history index page showing a list of 
        /// bulk orders, the date ordered, the order ID number and the number
        /// of items in that order.
        /// 
        /// </summary>
        /// <returns> 
        /// 
        /// this returns a list of bulk orders tested 
        /// againts a bool value for user role. 
        /// 
        /// </returns>
        public async Task<IActionResult> Index(int id)
        {
            try
            {
                // bool variable that tests to see what role the logged in user has
                bool IsAdmin = User.IsInRole(StaticDetails.AdminUser) || User.IsInRole(StaticDetails.SuperAdminUser);
                // gets the details of the curretly logged in user
                var user = await GetCurrentUserAsync();
                // gets/sets the application user ID
                var userId = user?.Id;
                // if the bool variable is false 
                if (IsAdmin != true)
                {
                    // variable for bulk order model including items and customer tables 
                    // where the customer id is equal to the logged in user id
                    // set out as a list
                    
                    BulkOrderVM.ApplicationUser = await _db.ApplicationUser.FindAsync(user.Id);


                    BulkOrderVM.Customer = _db.Customer.FirstOrDefault(m => m.ApplicationUserId == user.Id);


                    int CustId = BulkOrderVM.Customer.CustomerId;
                    BulkOrderVM.BulkOrderList = await _db.BulkOrder
                                                .Include(m => m.BulkOrderItem)
                                                .Include(m => m.SupplierContacted)
                                                .Where(m => m.FkCustomerId == CustId)
                                                .ToListAsync();

                    BulkOrderVM.BulkOrderItem = await _db.BulkOrderItem
                                                .Include(m => m.FkProduct)
                                                    .ThenInclude(m => m.FkCategory)
                                                .Where(m => m.FkBulkOrderId == BulkOrderVM.BulkOrder.BulkOrderId)
                                                .ToListAsync();

                    BulkOrderVM.SupplierContactedList = await _db.SupplierContacted
                                                .Where(m => m.FkBulkOrderId == BulkOrderVM.BulkOrder.BulkOrderId).ToListAsync();

                    BulkOrderVM.SupplierContactedList = BulkOrderVM.SupplierContactedList.Where(m => m.SupplierContactedUserSelected == true).ToList();


                    // this is the search fucntion for the products 
                    // if the search stirng 

                    if (id > 0)
                    {
                        // products list filtered on the search string
                        BulkOrderVM.BulkOrderList = BulkOrderVM.BulkOrderList
                            // where the product name contains the passed parameter
                            .Where(m => m.BulkOrderId
                                    // ignoring the case-sensitivity
                                    .Equals(id))
                               .ToList();
                    }
                    // return the view of the list to the page

                    // returns the list to the view 
                    return View(BulkOrderVM);
                }
                // if the bool value is true and currently logged in user is an admin/superadmin
                else
                {
                    

                    BulkOrderVM.ApplicationUser = await _db.ApplicationUser.FindAsync(user.Id);


                    BulkOrderVM.BulkOrderList = await _db.BulkOrder
                                                .Include(m => m.BulkOrderItem)
                                               .Include(m => m.SupplierContacted)
                                               .ToListAsync();

                    BulkOrderVM.BulkOrderItem = await _db.BulkOrderItem
                                                .Include(m => m.FkProduct)
                                                    .ThenInclude(m => m.FkCategory)
                                                .Where(m => m.FkBulkOrderId == BulkOrderVM.BulkOrder.BulkOrderId)
                                                .ToListAsync();

                    BulkOrderVM.SupplierContactedList = await _db.SupplierContacted
                                                .Where(m => m.FkBulkOrderId == BulkOrderVM.BulkOrder.BulkOrderId).ToListAsync();

                    BulkOrderVM.SupplierContactedList = BulkOrderVM.SupplierContactedList.Where(m => m.SupplierContactedUserSelected == true).ToList();

                    if (id > 0)
                    {
                       
                        // products list filtered on the search string
                        BulkOrderVM.BulkOrderList = BulkOrderVM.BulkOrderList
                            // where the product name contains the passed parameter
                            .Where(m => m.BulkOrderId
                                    // ignoring the case-sensitivity
                                    .Equals(id))
                               .ToList();
                    }
                    // returns list to the view
                    return View(BulkOrderVM);
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }


            // if we get here something went wrong
            return NotFound();

        }


        // controller that returns the details of a order by the parameter that 
        // is passed to it which is the ID of the bulk order
        public async Task<IActionResult> Details(int id)
        {
            // bool variable that tests to see what role the logged in user has
            bool IsAdmin = User.IsInRole(StaticDetails.AdminUser) || User.IsInRole(StaticDetails.SuperAdminUser);
            try
            {
                // variables to hold the details of the bulk order items view model
                // with the bulk order, product and the customer tables
                // where the bulk order id is equal to the paramter passed to the contoller
                BulkOrderVM.BulkOrder = await _db.BulkOrder
                                                .FindAsync(id);

                BulkOrderVM.BulkOrderItem = await _db.BulkOrderItem
                                            .Include(m => m.FkProduct)
                                                .ThenInclude(m => m.FkCategory)
                                            .Where(m => m.FkBulkOrderId == id)
                                            .ToListAsync();

                BulkOrderVM.SupplierContactedList = await _db.SupplierContacted
                                            .Where(m => m.FkBulkOrderId == id)
                                            .ToListAsync();

                BulkOrderVM.Customer = await _db.Customer.FindAsync(BulkOrderVM.BulkOrder.FkCustomerId);

                BulkOrderVM.ApplicationUser = await _db.ApplicationUser.FindAsync(BulkOrderVM.Customer.ApplicationUserId);

                //var OrderListDetails = await _db.BulkOrderItem
                //            .Include(m => m.FkBulkOrder)
                //                .ThenInclude(b => b.SupplierContacted)
                //            .Include(m => m.FkProduct)
                //            .Include(m => m.FkProduct.FkCategory)
                //            .Include(m => m.FkBulkOrder.FkCustomer)
                //            .Include(m => m.FkBulkOrder.FkCustomer.ApplicationUser)
                //            .Where(m => m.FkBulkOrder.BulkOrderId == id)
                //            .ToListAsync();
                // view bag is a method used to store temp data and send it to the page view outside of the 
                // model, this view bag is for the item count for the bulk order
                ViewBag.ItemCount = BulkOrderVM.BulkOrderItem.Count();
                // view bag for the creation date
                ViewBag.CreationDate = BulkOrderVM.BulkOrder.BulkOrderCreationDate;
                // temp data to store the user full name
                ViewBag.FullName = BulkOrderVM.ApplicationUser.FirstName + " " + BulkOrderVM.ApplicationUser.Surname;
                ViewBag.Status = BulkOrderVM.BulkOrder.BulkOrderStatus;
                //var CompleteIdModel = BulkOrderVM.SupplierContactedList.Where(m => m.SupplierContactedUserSelected == true);
                //int CompleteId = CompleteIdModel.FirstOrDefault().SupplierContactedId;
                //ViewBag.CompleteId = CompleteId;
                // double variable to store total weight of the order
                double TotalWeight = 0;

                // foreach loop to get the wieght of the product and the number of times that item 
                // is in the order
                foreach (var item in BulkOrderVM.BulkOrderItem)
                {
                    // weight variabe
                    decimal Weight = item.FkProduct.ProductWeight;
                    // item count variable
                    int? ItemCount = item.BulkOrderItemQuantity;

                    // total weight addition assignmnet to weight multiplied by count
                    TotalWeight += Convert.ToDouble(Weight) * Convert.ToDouble(ItemCount);
                }

                // temp data to display the total weight of the order in the view 
                ViewBag.TotalWeight = TotalWeight;

                // returns the list to the view 
                return View(BulkOrderVM);
            }
            catch (Exception ex)
            { Debug.Write(ex); }

            // if we get here something went wrong
            return NotFound();
        }

        [HttpGet, ActionName("Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                BulkOrderVM.BulkOrder = new BulkOrder();

                BulkOrderVM.BulkOrder = await _db.BulkOrder
                    .FirstOrDefaultAsync(b => b.BulkOrderId == id);

                BulkOrderVM.BulkOrderItem = await _db.BulkOrderItem
                                            .Include(m => m.FkProduct)
                                            .Include(m => m.FkBulkOrder)
                                            .Include(m => m.FkBulkOrder.FkCustomer)
                                            .Include(m => m.FkBulkOrder.FkCustomer.ApplicationUser)
                                            .Include(m => m.FkBulkOrder.SupplierContacted)
                                        .Where(m => m.FkBulkOrder.BulkOrderId == id)
                                        .ToListAsync();

                BulkOrderVM.SupplierContactedList = await _db.SupplierContacted
                                            .Include(m => m.FkSuppler)
                                            .Where(m => m.FkBulkOrderId == id)
                                            .ToListAsync();

                BulkOrderVM.SupplierList = await _db.Supplier.ToListAsync();

                BulkOrderVM.SupplierContacted = new SupplierContacted();




                ViewBag.OrderStatus = BulkOrderVM.BulkOrder.BulkOrderStatus;



                // ViewBag.StatusId = orderItem.FkBulkOrder.BulkOrderStatus;
                return View(BulkOrderVM);
            }
            catch (Exception ex)
            { Debug.Write(ex); }

            // if we get here something went wrong
            return NotFound();
        }


        // post controller for the edit view, takes in 2 paramaters of id of the bulk order and the 
        // status of the bulk order
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int OrderStatus)
        {
            try
            {
                // checks that the model is valid, if it is not then it will return to the same view
                if (!ModelState.IsValid)
                {
                    return View(BulkOrderVM);
                }
                // new supplier contacted oject model that gets all the data from the posted form
                SupplierContacted supplierContacted = new SupplierContacted
                {
                    SupplierContactedDate = DateTime.Now.ToString("dd-MM-yyyy"),
                    FkSupplerId = BulkOrderVM.SupplierContacted.FkSupplerId,
                    FkBulkOrderId = id,
                    SupplierContactedReply = false,
                    SupplierContactedDisplayToUser = false,
                    SupplierContactedQuote = 0
                };
                // adds object to database
                _db.SupplierContacted.Add(supplierContacted);
                await _db.SaveChangesAsync().ConfigureAwait(false);
                // bool variable that tests to see what role the logged in user has
                bool IsAdmin = User.IsInRole(StaticDetails.AdminUser) || User.IsInRole(StaticDetails.SuperAdminUser);
                // gets the details of the curretly logged in user
                var user = await GetCurrentUserAsync();
                // gets/sets the application user ID
                var userId = user?.Id;

                // a new applicationuser opbject                              
                var AppUserDetails = new ApplicationUser();
                var EmpDetails = new Employee();
                // a new midified by object
                var modifiedBySearch = new ModifiedBy();

                // checks to see if the current logged in user is an admin using the 
                // previously define bool
                if (IsAdmin == true)
                {
                    // using dependancy injection, finds the employee details from the database
                    // for the current logged in user using the userId
                    EmpDetails = await _db.Employee
                        .FirstOrDefaultAsync(m => m.ApplicationUserId == userId);
                    // using dependancy injection finds the applicationuser details from the 
                    // database usign the user Id
                    AppUserDetails = await _db.ApplicationUser
                        .FirstOrDefaultAsync(m => m.Id == userId);

                    // checks for a modified by object, trys to match the bulkorder ID
                    // to the fkBulkOrder id in the modified by table
                    modifiedBySearch = await _db.ModifiedBy
                        .FirstOrDefaultAsync(m => m.FkBulkOrderId == id);

                    // checks to see if a match has been found
                    if (modifiedBySearch == null)
                    {
                        // if no match has been found, new modified by object created,
                        // this is where the first employee that has modified the 
                        // bulk order will be created
                        ModifiedBy modifiedBy = new ModifiedBy
                        {
                            // date added from the current date to object 
                            ModifiedByDate = DateTime.Now.ToString("dd-MM-yyyy"),
                            // modified by first employee id added to object 
                            ModifiedByFirst = EmpDetails.EmployeeId,
                            // bulk order id added to object 
                            FkBulkOrderId = id,
                            // last modified by employee id
                            FkEmployeeId = EmpDetails.EmployeeId

                        };
                        // adds object to database to be saved 
                        _db.ModifiedBy.Add(modifiedBy);
                        await _db.SaveChangesAsync().ConfigureAwait(false);
                    }
                    else
                    {
                        // a matching id has been found so this bulk order has been 
                        // modified before
                        ModifiedBy modifiedBy = new ModifiedBy
                        {
                            // adds current date to the object
                            ModifiedByDate = DateTime.Now.ToString("dd-MM-yyyy"),
                            // adds the current id in the object back to the new object
                            ModifiedByFirst = modifiedBySearch.ModifiedByFirst,
                            // bulk order id added to object
                            FkBulkOrderId = id,
                            // last employee, that is currently logged into the app
                            FkEmployeeId = EmpDetails.EmployeeId

                        };
                        // adds object to database to be saved
                        _db.ModifiedBy.Add(modifiedBy);
                        await _db.SaveChangesAsync().ConfigureAwait(false);
                    }
                }

                // variable to store the bulkorder oject that matches the id that has been passed 
                // into the controller via the parameter id
                var bulkOrderFromDb = await _db.BulkOrder
                    .Where(m => m.BulkOrderId == id)
                    .FirstOrDefaultAsync();


                // check to make sure a bulk order object has been returned
                if (bulkOrderFromDb != null)
                {
                    bulkOrderFromDb.BulkOrderStatus = OrderStatus;
                    bulkOrderFromDb.BulkOrderMargin = 1.1;
                }
                // if we get here something went wrong
                else { return NotFound(); }

                //adds bulk order object to the database
                _db.Update(bulkOrderFromDb);
                // saves changes to that data base
                await _db.SaveChangesAsync().ConfigureAwait(false);
                // returns back the the view
                return RedirectToAction("Edit", id);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }


            // if we get here then something went wrong
            return NotFound();


        }

        // post action method that updates the supplier quote
        [HttpPost, ActionName("UpdateQuote")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, decimal QuoteUpdate, string QuoteUpdateDate)
        {
            try
            {
                var supplierContactedFromDb = await _db.SupplierContacted
                    .FirstOrDefaultAsync(m => m.SupplierContactedId == id);

                if (supplierContactedFromDb != null)
                {
                    supplierContactedFromDb.SupplierContactedQuote = QuoteUpdate;
                    supplierContactedFromDb.SupplierContactedReply = true;
                    supplierContactedFromDb.SupplerContactedReplyDate = QuoteUpdateDate;
                    _db.SupplierContacted.Update(supplierContactedFromDb);
                    await _db.SaveChangesAsync().ConfigureAwait(false);

                    return RedirectToAction("Edit", new { id = supplierContactedFromDb.FkBulkOrderId });
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }

            // if we get here something went wrong
            return NotFound();
        }


        // post action method that updates the supplier quote
        [HttpPost, ActionName("DeleteQuote")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, int BulkOrderId)
        {
            try
            {
                var supplierContactedFromDb = await _db.SupplierContacted.FindAsync(id)
                        .ConfigureAwait(false);
                _db.SupplierContacted.Remove(supplierContactedFromDb);
                await _db.SaveChangesAsync()
                        .ConfigureAwait(false);

                var BulkOrderFromDb = _db.BulkOrder
                    .Include(m => m.SupplierContacted)
                    .Where(m => m.BulkOrderId == BulkOrderId);

                if (BulkOrderFromDb.FirstOrDefault().SupplierContacted.Count == 0)
                {
                    var BulkOrderFromDbUpdate = await _db.BulkOrder.FindAsync(BulkOrderId);
                    BulkOrderFromDbUpdate.BulkOrderStatus = 0;
                    _db.BulkOrder.Update(BulkOrderFromDbUpdate);
                    await _db.SaveChangesAsync().ConfigureAwait(false);

                }

                // returns back the the view
                return RedirectToAction("Edit", new { id = BulkOrderId });
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }

            // if we get here something went wrong
            return NotFound();
        }

        [HttpPost, ActionName("FinaliseQuote")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Finalise(int id, decimal Margin, bool ToCustomer)
        {
            try
            {
                var supplierContactedFromDb = await _db.SupplierContacted
                    .FirstOrDefaultAsync(m => m.SupplierContactedId == id);
                var bulkOrderFromDb = await _db.BulkOrder.FindAsync(supplierContactedFromDb.FkBulkOrderId);
                if (supplierContactedFromDb != null)
                {
                    supplierContactedFromDb.SupplierContactedDisplayToUser = ToCustomer;

                }
                if (bulkOrderFromDb != null)
                {
                    bulkOrderFromDb.BulkOrderMargin = Convert.ToDouble((Margin + 1) / 10);
                    bulkOrderFromDb.BulkOrderProfit = (Margin / 100) * supplierContactedFromDb.SupplierContactedQuote;
                }
                _db.SupplierContacted.Update(supplierContactedFromDb);
                _db.BulkOrder.Update(bulkOrderFromDb);
                await _db.SaveChangesAsync().ConfigureAwait(false);

                return RedirectToAction("Edit", new { id = supplierContactedFromDb.FkBulkOrderId });
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }

            // if we get here something went wrong
            return NotFound();
        }


        // DElete get controller
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    BulkOrderVM.BulkOrder = await _db.BulkOrder
                                                   .FindAsync(id);

                    return View(BulkOrderVM);
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }


            return NotFound();
        }


        // delete post controller
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                var bulkOrder = await _db.BulkOrder.FindAsync(id)
                        .ConfigureAwait(false);
                _db.BulkOrder.Remove(bulkOrder);
                await _db.SaveChangesAsync()
                        .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }

            return RedirectToAction(nameof(Index));
        }
    }

    
}