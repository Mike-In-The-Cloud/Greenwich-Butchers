
using GreButchersEFCore_V2.Models;
using GreButchersEFCore_V2.Models.ViewModels;
using GreButchersEFCore_V2.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GreButchersEFCore_V2.Controllers
{
    // using the authorize attribute will stop any customers using this controller
    // if an unauthorized user tries to access this controller they will be redirected to the 
    // login page. Here the AdminUser and the SuperAdminUser both have access to the 
    // controller by using the appended string to sepereate the 2 constant strings
    [Authorize(Roles = StaticDetails.AdminUser + "," + StaticDetails.SuperAdminUser)]
    [Area("Admin")]
    public class ProductsController : Controller
    {
        // appliaction database context
        private readonly GreButchersContext _db;
        // appliacation hosting environment
        private readonly HostingEnvironment _hostingEnvironment;

        // using the bindproperty attribute for propper 
        // validation using the annotation notes from the model
        [BindProperty]
        public ProductsViewModel ProductsVM { get; set; }

        public ProductsController(GreButchersContext db, HostingEnvironment hostingEnvironment)
        {
            // try catch block to catch any exceptions
            try
            {
                _db = db;
                _hostingEnvironment = hostingEnvironment;
                ProductsVM = new ProductsViewModel()
                {
                    Categories = _db.Category.ToList(),
                    Products = new Product(),
                    Stocks = new Stock()
                };
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }
        }

        public async Task<IActionResult> Index(string id)
        {
            // this lambada expression is to include related
            // data from 3 seperate models using the navigation 
            // properties within the models
            // ordering the resulting list by the category primary key
            try
            {
                var products = await _db.Stock
                    .Include(m => m.FkProduct)
                    .Include(m => m.FkProduct.FkCategory)
                    .OrderBy(m => m.FkProduct.FkCategory.CategoryId)
                    .ToListAsync();

                // this is the search fucntion for the products 
                // if the search stirng 
                if (!String.IsNullOrEmpty(id))
                {
                    // products list filtered on the search string
                    products = products
                        // where the product name contains the passed parameter
                        .Where(s => s.FkProduct.ProductName
                                    .Contains(id, StringComparison.OrdinalIgnoreCase)
                            // or the parameter is contained in the product description
                            || s.FkProduct.ProductDescription
                                      // also ignores the case-sensitivity
                                      .Contains(id, StringComparison.OrdinalIgnoreCase)
                            // a 3rd or clause that searches the category
                            || s.FkProduct.FkCategory.CategoryName
                                // ignoring the case-sensitivity
                                .Contains(id, StringComparison.OrdinalIgnoreCase))
                           .ToList();
                }
                // return the view of the list to the page

                // returns the variable to the view
                return View(products);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return View();
            }
        }

        // GET products Create
        public IActionResult Create()
        {
            // returns a list to the view
            return View(ProductsVM);
        }



        // POST products Create
        /// <summary>
        /// This HTTP post controller is for the create page.
        /// It contains the methods and functions to add a new 
        /// product to the database
        /// </summary>
        /// <returns></returns>
        [HttpPost, ActionName("Create")]
        // attribute to prevent cross-site request forgery attacks
        // using a http only cookie with a value, it is checked 
        // for vadility, this stops hidden content being 
        // submitted from 3rd party sites.
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost()
        {
            // if the model state is not valid 
            if (!ModelState.IsValid)
            {
                // return the view of the product view model
                return View(ProductsVM);
            }

            // adds the product models to the database
            _db.Product.Add(ProductsVM.Products);
            // saves the product model to the database
            await _db.SaveChangesAsync().ConfigureAwait(false);

            // variables for image being saved
            // looks for the wwwRoot folder
            string webRootPath = _hostingEnvironment.WebRootPath;
            // the file the user is trying to upload
            var files = HttpContext.Request.Form.Files;

            // using the .Find() i can return the Id of the newly inserted product model
            // without having to write code to fetch it.
            // this is achived by the DbContext tracking the model changes.
            var productsFromDb = _db.Product.Find(ProductsVM.Products.ProductId);

            if (files.Count != 0)
            {
                // image has been uploaded
                var uploads = Path.Combine(webRootPath, StaticDetails.ImageFolder);
                var extension = Path.GetExtension(files[0].FileName);

                using (var filestream = new FileStream(Path.Combine(uploads, ProductsVM.Products.ProductId + extension)
                    , FileMode.Create))
                {
                    files[0].CopyTo(filestream);
                }

                productsFromDb.ProductImage = @"\" + StaticDetails.ImageFolder + @"\" + ProductsVM.Products.ProductId + extension;
            }
            else
            {
                // where user does not upload image
                var uploads = Path.Combine(webRootPath, StaticDetails.ImageFolder + @"\" + StaticDetails.DefaultProductImage);
                System.IO.File.Copy(uploads, webRootPath + @"\" + StaticDetails.ImageFolder + @"\" + ProductsVM.Products.ProductId + ".png");
                productsFromDb.ProductImage = @"\" + StaticDetails.ImageFolder + @"\" + ProductsVM.Products.ProductId + ".png";
            }
            // save changes to the database, configure await prevents deadlock
            await _db.SaveChangesAsync().ConfigureAwait(false);

            // save changes to the stocks table
            Stock stock = new Stock
            {
                StockShop = ProductsVM.Stocks.StockShop,
                StockWarehouse = ProductsVM.Stocks.StockWarehouse,
                FkProductId = ProductsVM.Products.ProductId
            };

            _db.Stock.Add(stock);
            await _db.SaveChangesAsync().ConfigureAwait(false);


            return RedirectToAction(nameof(Index));

        }

        /// <summary>
        /// Edit controllers
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET Edit action method
        public async Task<IActionResult> Edit(int? id)
        {
            // if id is null reutrn not found
            if (id == null)
            {
                return NotFound();
            }
            // try catch block to catch errors
            try
            {

                // products view model,  finds the result based on the id parameter entered into the method
                // using the stocks model to generate the object to pass to the view with the navigation
                // properties
                ProductsVM.Stocks = await _db.Stock
                    .Include(m => m.FkProduct)
                    .Include(m => m.FkProduct.FkCategory)
                    .Where(m => m.FkProduct.ProductId == id)
                    .SingleOrDefaultAsync(m => m.FkProduct.ProductId == id)
                    .ConfigureAwait(false);
                //if the products view model is null then return not found
                if (ProductsVM.Stocks == null)

                { return NotFound(); }
            }
            // catch any errors
            catch (Exception e) { Debug.Write(e); }
            // return the edit view
            return View(ProductsVM);
        }

        // POST edit action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            // if model state is vaild
            if (ModelState.IsValid)
            {
                try
                {
                    // update image
                    string webRootPath = _hostingEnvironment.WebRootPath;
                    var files = HttpContext.Request.Form.Files;



                    // find image in database
                    var productFromDb = _db.Stock.Where(m => m.FkProduct.ProductId == id)
                        .Include(m => m.FkProduct)
                            .ThenInclude(m => m.FkCategory)

                        .FirstOrDefault();

                    if (files.Count > 0 && files[0] != null)
                    {
                        // if user uploads a new image
                        var uploads = Path.Combine(webRootPath, StaticDetails.ImageFolder);
                        // find extention of images
                        // new image extension
                        var extension_new = Path.GetExtension(files[0].FileName);
                        // old iamge extension
                        var extension_old = Path.GetExtension(productFromDb.FkProduct.ProductImage);
                        // delete old image file if it exists
                        if (System.IO.File.Exists(Path.Combine(uploads, id + extension_old)))
                        {
                            System.IO.File.Delete(Path.Combine(uploads, id + extension_old));
                        }
                        // upload new image file
                        using (var filestream = new FileStream(Path.Combine(uploads, id + extension_new)
                        , FileMode.Create))
                        {
                            files[0].CopyTo(filestream);
                        }

                        ProductsVM.Stocks.FkProduct.ProductImage = @"\" + StaticDetails.ImageFolder + @"\" + id + extension_new;
                    }
                    // display new image
                    if (ProductsVM.Stocks.FkProduct.ProductImage != null)
                    {
                        productFromDb.FkProduct.ProductImage = ProductsVM.Stocks.FkProduct.ProductImage;
                    }
                    // update fields
                    productFromDb.FkProduct.ProductName = ProductsVM.Stocks.FkProduct.ProductName;
                    productFromDb.FkProduct.ProductPrice = ProductsVM.Stocks.FkProduct.ProductPrice;
                    productFromDb.FkProduct.ProductWeight = ProductsVM.Stocks.FkProduct.ProductWeight;
                    productFromDb.FkProduct.ProductDescription = ProductsVM.Stocks.FkProduct.ProductDescription;
                    productFromDb.FkProduct.FkCategory.CategoryId = ProductsVM.Stocks.FkProduct.FkCategory.CategoryId;
                    productFromDb.StockShop = ProductsVM.Stocks.StockShop;
                    productFromDb.StockWarehouse = ProductsVM.Stocks.StockWarehouse;

                    // save changes to database
                    await _db.SaveChangesAsync().ConfigureAwait(false);
                    // returns to the index view
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Debug.Write(ex);
                }
            }
            // if the model is not vaild then return back to products view model
            return View(ProductsVM);
        }


        // GET Details action method
        public async Task<IActionResult> Details(int? id)
        {
            // if id is null reutrn not found
            if (id == null)
            {
                return NotFound();
            }
            // try catch block to catch errors
            try
            {
                // products vie model,  finds the result based on the id parameter entered into the method
                //ProductsVM.Products = await _db
                //    .Product.Include(m => m.FkCategory)
                //    .SingleOrDefaultAsync(m => m.ProductId == id)
                //    .ConfigureAwait(false);
                Stock products = new Stock();
                var product = await _db.Stock
                    .Include(m => m.FkProduct)
                    .Include(m => m.FkProduct.FkCategory)
                    .Where(m => m.FkProduct.ProductId == id)
                    .FirstOrDefaultAsync();
                products = product;
                if (products == null)

                { return NotFound(); }
                return View(products);
                //if the products view model is null then return not found

            }
            // catch any errors
            catch (Exception e) { Debug.Write(e); }
            // return the edit view
            return NotFound();
        }

        // GET Delete action method
        public async Task<IActionResult> Delete(int? id)
        {
            // if id is null reutrn not found
            if (id == null)
            {
                return NotFound();
            }
            // try catch block to catch errors
            try
            {
                // products vie model,  finds the result based on the id parameter entered into the method
                ProductsVM.Products = await _db.Product
                    .Include(m => m.FkCategory)
                    .SingleOrDefaultAsync(m => m.ProductId == id)
                    .ConfigureAwait(false);
                //if the products view model is null then return not found
                if (ProductsVM.Products == null)

                { return NotFound(); }
            }
            // catch any errors
            catch (Exception e) { Debug.Write(e); }
            // return the edit view
            return View(ProductsVM);
        }

        //POST Delete action method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                // string variable to hold the path of the image
                string webRootPath = _hostingEnvironment.WebRootPath;
                // finds the products with the parameters passed Id
                Product products = await _db.Product.FindAsync(id);
                // if the product cannot be found return not found
                if (products == null)
                {
                    return NotFound();
                }
                // if it is found, find the image associated with it 
                else
                {
                    // variable to hold the path to the image
                    var uploads = Path.Combine(webRootPath, StaticDetails.ImageFolder);
                    // gets the extension of the image
                    var extension = Path.GetExtension(products.ProductImage);
                    // if the file exisists, using the id of the product and combining it with the extension
                    // of the image
                    if (System.IO.File.Exists(Path.Combine(uploads, products.ProductId + extension)))
                    {
                        // remove the image
                        System.IO.File.Delete(Path.Combine(uploads, products.ProductId + extension));
                    }
                    // remove the product from the database
                    _db.Product.Remove(products);
                    // save changes to the database
                    await _db.SaveChangesAsync()
                        .ConfigureAwait(false);


                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }

            return RedirectToAction(nameof(Index));
        }


    }
}