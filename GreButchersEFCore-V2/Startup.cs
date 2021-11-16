
using GreButchersEFCore_V2.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GreButchersEFCore_V2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // entity framework core specific code to connect to the data base and populate the 
            // data models in the application
            services.AddDbContext<GreButchersContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddHttpContextAccessor();
            // configuration for sessions
            services.AddSession(options =>
            {
                // session times out after an idle of 30 minutes
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                // use cookies
                options.Cookie.HttpOnly = true;
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
              .AddEntityFrameworkStores<GreButchersContext>()
              .AddDefaultUI()
              .AddDefaultTokenProviders();

            services.AddDistributedMemoryCache();
        }





        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // uses the https middleware
            app.UseHttpsRedirection();
            // use of static files
            app.UseStaticFiles();
            // the cookie policy
            app.UseCookiePolicy();
            // add sessions to the application
            app.UseSession();
            app.UseAuthentication();
            // this is the pattern that MVC will use to get data
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  // route for the MVC to take with paramenters they can take, the ? means that the paramater is optional
                  template: "{area=Customer}/{controller=Home}/{action=Index}/{id?}/{OrderStatus?}/{QuoteUpdate?}/{QuoteUpdateDate?}/{BulkOrderId?}/{Margin?}/{ToCustomer?}"
                );
            });
        }
    }
}
