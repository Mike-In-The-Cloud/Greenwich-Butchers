using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GreButchersEFCore_V2.Models;
using GreButchersEFCore_V2.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GreButchersEFCore_V2.Areas.Admin.Controllers
{
    // using the authorize attribute will stop any customers using this controller
    // if an unauthorized user tries to access this controller they will be redirected to the 
    // login page. Here the AdminUser and the SuperAdminUser both have access to the 
    // controller by using the appended string to sepereate the 2 constant strings
    [Authorize(Roles = StaticDetails.AdminUser + "," + StaticDetails.SuperAdminUser)]
    [Area("Admin")]
    public class SupplierController : Controller
    {
        // appliaction database context
        private readonly GreButchersContext _db;

        public SupplierController(GreButchersContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Supplier.ToList());
        }

        // GET Create action method
        public IActionResult Create()
        {
            return View();
        }

        // POST Create action method
        [HttpPost, ActionName("Create")]
        // security provided by asp.net
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Supplier Supplier)
        {
            // checks the model is vaild
            if (ModelState.IsValid)
            {
                // adds data to the database
                _db.Add(Supplier);
                // saves changes to the database
                await _db.SaveChangesAsync()
                    .ConfigureAwait(false);
                // redirects to the index page of the product type folder
                return RedirectToAction(nameof(Index));
            }
            // if not valid return to page
            return View(Supplier);
        }

        //GET Edit Action Method
        public async Task<IActionResult> Edit(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var supplier = await _db.Supplier
                .FindAsync(ID)
                .ConfigureAwait(false);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }
        //POST Edit action Method
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ID, Supplier supplier)
        {
            if (ID != supplier.SupplierId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(supplier);
                    await _db.SaveChangesAsync()
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {

                    Debug.Write(ex);

                }
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }
        //GET Details Action Method
        public async Task<IActionResult> Details(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var supplier = await _db.Supplier
                .FindAsync(ID)
                .ConfigureAwait(false);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        //GET Delete Action Method
        public async Task<IActionResult> Delete(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var supplier = await _db.Supplier
                .FindAsync(ID)
                .ConfigureAwait(false);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }
        //POST Delete action Method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int ID)
        {
            try
            {
                var supplier = await _db.Supplier.FindAsync(ID)
                        .ConfigureAwait(false);
                _db.Supplier.Remove(supplier);
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