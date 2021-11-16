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
    // defines the area as the admin area
    [Area("Admin")]
    public class CategoryController : Controller
    {
        // dependancy injection for the database
        private readonly GreButchersContext _db;

        public CategoryController(GreButchersContext db)
        {
            _db = db;
        }

        // view action method
        public IActionResult Index()
        {
            // returns the categories as a list to the view model
            return View(_db.Category.ToList());
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
        public async Task<IActionResult> Create(Category category)
        {
            // checks the model is vaild
            if (ModelState.IsValid)
            {
                // adds data to the database
                _db.Add(category);
                // saves changes to the database
                await _db.SaveChangesAsync()
                    .ConfigureAwait(false);
                // redirects to the index page of the product type folder
                return RedirectToAction(nameof(Index));
            }
            // if not valid return to page
            return View(category);
        }

        //GET Edit Action Method
        public async Task<IActionResult> Edit(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var category = await _db.Category
                .FindAsync(ID)
                .ConfigureAwait(false);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        //POST Edit action Method
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ID, [Bind("CategoryId, CategoryName")] Category category)
        {
            if (ID != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(category);
                    await _db.SaveChangesAsync()
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {

                    Debug.Write(ex);

                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        //GET Details Action Method
        public async Task<IActionResult> Details(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var category = await _db.Category
                .FindAsync(ID)
                .ConfigureAwait(false);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        //GET Delete Action Method
        public async Task<IActionResult> Delete(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            var category = await _db.Category
                .FindAsync(ID)
                .ConfigureAwait(false);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        //POST Delete action Method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int ID)
        {
            try
            {
                var productTypes = await _db.Category.FindAsync(ID)
                        .ConfigureAwait(false);
                _db.Category.Remove(productTypes);
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