using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using via_web_application.Services;

namespace via_web_application
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
            services.AddDbContext<CatContext>(options => {
                options.UseSqlite("Data Source = database.db");
            });
            
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<CatContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                // If the LoginPath isn't set, ASP.NET Core defaults 
                // the path to /Account/Login.
                options.LoginPath = "/Account/Login";
                // If the AccessDeniedPath isn't set, ASP.NET Core defaults 
                // the path to /Account/AccessDenied.
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeFolder("/Account/Manage");
                    options.Conventions.AuthorizePage("/Account/Logout");
                    options.Conventions.AuthorizePage("/Store");
                    options.Conventions.AuthorizePage("/Orders");

                });

            services.AddSingleton<IEmailSender, EmailSender>();

            //services.AddSingleton<CatRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc();
            
            CreateRoles(serviceProvider);

    }

    // https://stackoverflow.com/questions/42471866/how-to-create-roles-in-asp-net-core-and-assign-them-to-users
    private void CreateRoles(IServiceProvider serviceProvider)
    {

        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        Task<IdentityResult> roleResult;
        string email = "someone@somewhere.com";

        //Check that there is an Administrator role and create if not
        Task<bool> hasAdminRole = roleManager.RoleExistsAsync("Administrator");
        hasAdminRole.Wait();

        if (!hasAdminRole.Result)
        {
            roleResult = roleManager.CreateAsync(new IdentityRole("Administrator"));
            roleResult.Wait();
        }

        //Check if the admin user exists and create it if not
        //Add to the Administrator role

        Task<ApplicationUser> testUser = userManager.FindByEmailAsync(email);
        testUser.Wait();

        if (testUser.Result == null)
        {
            ApplicationUser administrator = new ApplicationUser();
            administrator.Email = email;
            administrator.UserName = email;

            Task<IdentityResult> newUser = userManager.CreateAsync(administrator, "123456789");
            newUser.Wait();

            if (newUser.Result.Succeeded)
            {
                Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(administrator, "Administrator");
                newUserRole.Wait();
            }
        }

    }
    }
}
