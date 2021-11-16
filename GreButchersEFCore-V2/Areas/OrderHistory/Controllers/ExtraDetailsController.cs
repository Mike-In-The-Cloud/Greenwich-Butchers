using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GreButchersEFCore_V2.Models;
using GreButchersEFCore_V2.Models.ViewModels;
using GreButchersEFCore_V2.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GreButchersEFCore_V2.Areas.OrderHistory.Controllers
{
    [Area("OrderHistory")]
    [Authorize(Roles = StaticDetails.AdminUser + "," + StaticDetails.SuperAdminUser + "," + StaticDetails.CustomerUser)]
    public class ExtraDetailsController : Controller
    {

        // appliaction database context
        private readonly GreButchersContext _db;

        private readonly UserManager<ApplicationUser> _userManager;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [BindProperty]
        public ExtraDetailsViewModel ExtraDetailsVM { get; set; }


        public ExtraDetailsController(GreButchersContext db,
            UserManager<ApplicationUser> userManager)
        {
            _db = db;

            _userManager = userManager;

            ExtraDetailsVM = new ExtraDetailsViewModel()
            {
                BulkOrder = new BulkOrder(),
                ModifiedBy = new ModifiedBy(),
                ModifiedByList = new List<ModifiedBy>(),
                Employee = new Employee(),
                ApplicationUser = new ApplicationUser()
            };
        }


        // GET: /<controller>/
        public async Task<IActionResult> Index(int id)
        {
            try
            { 
            ExtraDetailsVM.BulkOrder = await _db.BulkOrder.FindAsync(id);

            ExtraDetailsVM.ModifiedByList = await _db.ModifiedBy
                .Include(m => m.FkEmployee)
                .Include(m => m.FkEmployee.ApplicationUser)
                .Where(m => m.FkBulkOrderId == id).ToListAsync();

            ExtraDetailsVM.ModifiedBy = await _db.ModifiedBy.Where(m => m.FkBulkOrderId == id).FirstOrDefaultAsync();

            ExtraDetailsVM.Employee = await _db.Employee.FindAsync(ExtraDetailsVM.ModifiedByList.FirstOrDefault().ModifiedByFirst);

            ExtraDetailsVM.ApplicationUser = await _db.ApplicationUser.FindAsync(ExtraDetailsVM.Employee.ApplicationUserId);

            return View(ExtraDetailsVM);

            }
            catch(Exception ex)
            {
                Debug.Write(ex);
            }

            // if we get here something went wrong
            return NotFound();
        }
    }
}
