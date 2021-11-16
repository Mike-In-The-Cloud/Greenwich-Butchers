using GreButchersEFCore_V2.Models;
using GreButchersEFCore_V2.Models.ViewModels;
using GreButchersEFCore_V2.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
/// <summary>
/// This razor page is used to register new users to thewebsite,
/// using the identity class written by microsoft and adding an extension
/// to the class to add more fields to the database, this register page 
/// captures information from the user 
/// </summary>
namespace GreButchersEFCore_V2.Areas.Identity.Pages.Account
{

    // allow anonymous allows an unregistered user access to the page and the 
    // corrisponding controllers 
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public class RegisterModel : PageModel
    {
        // private variable to hold the Context of the database
        private readonly GreButchersContext _db;
        // private variable to instanciate the CreateUserViewModel
        private CreateUserViewModel UserRegistration { get; set; }



        // Identity SignInManager with paramater of exteneded identity user model
        private readonly SignInManager<ApplicationUser> _signInManager;
        // Identity UserManager with paramater of exteneded identity user model
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        // Identity RoleManager with paramater of identity user model
        private readonly RoleManager<IdentityRole> _roleManager;

        // constructor with 5 paramaters, dependancy injection into the model
        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager,
            GreButchersContext db)
        {
            // instanciate the varaibles 
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _db = db;


            // instanciate a new CreateViewModel class,
            // this is used to add the UserId to the Employee and customer
            // tables
            UserRegistration = new CreateUserViewModel
            {
                EmployeeAdd = new Employee(),
                CustomerAdd = new Models.Customer()
            };
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }
        /// <summary>
        /// This input model is the model that the razor page will display
        /// </summary>
        public class InputModel
        {
            // Email address 
            [Required(ErrorMessage = "Please enter E-Mail Address")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            // password
            [Required(ErrorMessage = "Enter password.")]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }


            // password confirmation 
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }


            // first name, required from the user
            [Required(ErrorMessage = "Enter first name.")]
            [StringLength(25, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }


            // surname, required from the user 
            [Required(ErrorMessage = "Enter surname.")]
            [StringLength(25, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
            [Display(Name = "Surname Name")]
            public string Surname { get; set; }


            // date of birth, required from the user
            [Required(ErrorMessage = "Enter date of birth.")]
            [DataType(DataType.Date)]
            public DateTime DOB { get; set; }

            //**********************
            // user address details
            [StringLength(25, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
            [Display(Name = "Building Name")]
            public string BuildingName { get; set; }

            // street address
            [Required(ErrorMessage = "Enter Address Line One.")]
            [StringLength(25, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
            [Display(Name = "Address Line One")]
            public string AddressLine1 { get; set; }

            // address line 2, not required from the user
            [Display(Name = "Address Line Two")]
            public string AddressLine2 { get; set; }

            // city, required by the user
            [Required(ErrorMessage = "Enter city.")]
            [StringLength(25, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
            [Display(Name = "City")]
            public string City { get; set; }

            // postcode, required, using regex regular expression to validate the user input
            [Required(ErrorMessage = "Enter postcode.")]
            [RegularExpression(@"^(?i)([A-PR-UWYZ](([0-9](([0-9]|[A-HJKSTUW])?)?)|([A-HK-Y][0-9]([0-9]|[ABEHMNPRVWXY])?)) [0-9][ABD-HJLNP-UW-Z]{2})|GIR 0AA$", ErrorMessage = "Please Enter valid Post code")]
            [Display(Name = "Postcode")]
            public string Postcode { get; set; }

            // contact number, required from the user
            [Required(ErrorMessage = "You must provide a phone number")]
            [Display(Name = "Contact number")]
            [DataType(DataType.PhoneNumber)]
            [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Company Name")]
            public string CompnayName { get; set; }

            [Display(Name = "Employee Type")]
            public string EmployeeType { get; set; }

            [Display(Name = "Super Admin")]
            public bool IsSuperAdmin { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        /// <summary>
        /// 
        /// on post controller, creates a new user in the database 
        /// with asigned roles 
        /// 
        /// </summary>
        
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            // gets the value of the radio button selected for selected by requesting the form data
            string role = Request.Form["rdUserRole"].ToString();
            // gets the radio button value selected for emp type
            string EmployeeType = Request.Form["rdEmpType"].ToString();


            returnUrl = returnUrl ?? Url.Content("~/");
            // if the model state is valid
            if (ModelState.IsValid)
            {
                // new object of identity user to be created using the model defined in the get controller
                var user = new ApplicationUser
                {
                    // this method passes the information the user has entered 
                    // and assigns it to the variable in the ApplicationUser model
                    // this also includes IdentityUser as the ApplicationUser model
                    // extends the IdentityUser model.
                    UserName = Input.Email,
                    Email = Input.Email,
                    FirstName = Input.FirstName,
                    Surname = Input.Surname,
                    DOB = Input.DOB,
                    PhoneNumber = Input.PhoneNumber,
                    BuildingName = Input.BuildingName,
                    StreetAddress1 = Input.AddressLine1,
                    StreetAddress2 = Input.AddressLine2,
                    City = Input.City,
                    PostCode = Input.Postcode,


                };
                // creates the user name and password in the database
                var result = await _userManager.CreateAsync(user, Input.Password);
                // if the previous is sucessful 
                if (result.Succeeded)
                {

                    // create the roles for the first time
                    // this will only run if the role does not exist

                    // if the admin user role does not exist
                    if (!await _roleManager.RoleExistsAsync(StaticDetails.AdminUser))
                    {
                        // create the admin user role
                        await _roleManager.CreateAsync(new IdentityRole(StaticDetails.AdminUser));
                    }
                    // if the customer user role does not exist
                    if (!await _roleManager.RoleExistsAsync(StaticDetails.CustomerUser))
                    {
                        // create the customer user role
                        await _roleManager.CreateAsync(new IdentityRole(StaticDetails.CustomerUser));
                    }
                    // if the super admin user role does not exist 
                    if (!await _roleManager.RoleExistsAsync(StaticDetails.SuperAdminUser))
                    {
                        // create the super admin user role
                        await _roleManager.CreateAsync(new IdentityRole(StaticDetails.SuperAdminUser));
                    }

                    // date time of creation
                    DateTime CreationDate = DateTime.Now;
                    // assigns the roles to newly created users
                    if (role == StaticDetails.AdminUser)
                    {
                        // admin role
                        await _userManager.AddToRoleAsync(user, StaticDetails.AdminUser);

                        // gets the id of the created user
                        string UserIdFromDb = user.Id;
                        // new employee object
                        Employee employee = new Employee
                        {
                            // applicationuserid field equal to user id
                            ApplicationUserId = UserIdFromDb,
                            // adds the employee start date
                            EmployeeStartDate = CreationDate,
                            EmployeeType = EmployeeType
                        };
                        // adds the object to the database
                        _db.Employee.Add(employee);
                        // saves changes to the database
                        await _db.SaveChangesAsync().ConfigureAwait(false);

                    }
                    // give the user super admin role
                    else
                    {
                        if (role == StaticDetails.SuperAdminUser)
                        {
                            // super admin role
                            await _userManager.AddToRoleAsync(user, StaticDetails.SuperAdminUser);
                            // gets the id of the created user
                            string UserIdFromDb = user.Id;
                            // new employee object
                            Employee employee = new Employee
                            {
                                // applicationuserid field equal to user id
                                ApplicationUserId = UserIdFromDb,
                                // adds the employee start date
                                EmployeeStartDate = CreationDate,
                                // adds emp type
                                EmployeeType = EmployeeType
                            };
                            // adds the object to the database
                            _db.Employee.Add(employee);
                            // saves changes to the database
                            await _db.SaveChangesAsync().ConfigureAwait(false);
                        }
                        // give the user customer role
                        else
                        {
                            // customer role
                            await _userManager.AddToRoleAsync(user, StaticDetails.CustomerUser);
                            // gets the id of the created user
                            string UserIdFromDb = user.Id;
                            // new employee object
                            Models.Customer customer = new Models.Customer
                            {
                                // applicationuserid field equal to user id
                                ApplicationUserId = UserIdFromDb,
                                // adds company name to the database
                                CustomerCompanyName = Input.CompnayName

                            };
                            // adds the object to the database
                            _db.Customer.Add(customer);
                            // saves changes to the database
                            await _db.SaveChangesAsync().ConfigureAwait(false);
                            // logs in customer after the customer has created their account
                            if (User.Identity.IsAuthenticated != true)
                            {
                                await _signInManager.SignInAsync(user, isPersistent: false);
                            }
                            // redirects to landing page
                            return LocalRedirect(returnUrl);
                        }
                    }



                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                    return RedirectToAction("Index", "User", new { area = "Admin" });

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
