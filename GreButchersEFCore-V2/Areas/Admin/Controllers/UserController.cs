using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GreButchersEFCore_V2.Models;
using GreButchersEFCore_V2.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GreButchersEFCore_V2.Areas.Admin.Controllers
{
    // using the authorize attribute will stop any customers using this controller
    // if an unauthorized user tries to access this controller they will be redirected to the 
    // login page. Here the AdminUser and the SuperAdminUser both have access to the 
    // controller by using the appended string to sepereate the 2 constant strings
    [Authorize(Roles = StaticDetails.AdminUser + "," + StaticDetails.SuperAdminUser)]
    [Area("Admin")]
    public class UserController : Controller
    {
        // read only variable
        private readonly GreButchersContext _db;

        // dependancy injection of the db context
        public UserController(GreButchersContext db)
        {
            // assigns the value of the db context to the varaible
            _db = db;
        }

        /// <summary>
        /// This controller will return a list of all users in the database,
        /// using ClaimsIdentity i have excluded the currently logged in user in 
        /// this list
        /// </summary>
        /// <returns> List of all users excluding the currently logged in user </returns>
        public async Task<IActionResult> Index()
        {
            // finds the id of the currently logged in user
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            // holds the values of the ID of the currenetly logged in user
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            // returns a list of all users to the view EXCLUDING the currently logged in user
            return View(await _db.ApplicationUser.Where(u => u.Id != claim.Value).ToListAsync());
        }

        // controller to LOCK the account, will only be used by super admins
        // the id is a string due to asp.net core id
        public async Task<IActionResult> Lock(string id)
        {
            // check to see if there is an ID
            if (id == null)
            {
                // if id is not found return not found
                return NotFound();
            }
            // paramater to check if id is found find the matching in the database 
            var applicationuser = await _db.ApplicationUser.FirstOrDefaultAsync(m => m.Id == id);
            // if the parameter is null
            if (applicationuser == null)
            {
                // return not found
                return NotFound();
            }
            // if the paramater is not empty, add 1000 years to the lock out 
            applicationuser.LockoutEnd = DateTime.Now.AddYears(1000);
            // save changes to the database
            await _db.SaveChangesAsync();
            // redirect to index of usercontroller
            return RedirectToAction(nameof(Index));
        }
        // controller to UNLOCK the account, will only be used by super admins
        // the id is a string due to asp.net core id
        public async Task<IActionResult> Unlock(string id)
        {
            // check to see if there is an ID
            if (id == null)
            {
                // if id is not found return not found
                return NotFound();
            }
            // paramater to check if id is found find the matching in the database 
            var applicationuser = await _db.ApplicationUser.FirstOrDefaultAsync(m => m.Id == id);
            // if the parameter is null
            if (applicationuser == null)
            {
                // return not found
                return NotFound();
            }
            // if the paramater is not empty, change lock out to now,
            // this will unlock the account
            applicationuser.LockoutEnd = DateTime.Now;
            // save changes to the database
            await _db.SaveChangesAsync();
            // redirect to index of usercontroller
            return RedirectToAction(nameof(Index));
        }
    }
}