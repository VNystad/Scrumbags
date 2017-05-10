using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Gameblasts.Data;
using Gameblasts.Models;
using Gameblasts.Models.CategoryModels;
using Gameblasts.Services;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Gameblasts
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime when in default mode. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime when in Development Mode. Use this method to add services to the container.
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DevelopmentConnection")));


            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // Called by Configure(). This needs an async function because
        // all the userManager and roleManager functions are async.
        public async Task CreateUsersAndRoles(IServiceScope serviceScope)
        {
            var userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
            var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

            // First create the admin role
            await roleManager.CreateAsync(new IdentityRole("Admin"));

            // Then create moderator role
            await roleManager.CreateAsync(new IdentityRole("Moderator"));

            // Then add one admin user
            var adminUser = new ApplicationUser { UserName = "admin@uia.no", Email = "admin@uia.no" };
            await userManager.CreateAsync(adminUser, "Password1.");
            await userManager.AddToRoleAsync(adminUser, "Admin");

            // Add one moderator user
            var moderatorUser = new ApplicationUser {UserName = "moderator@uia.no", Email = "moderator@uia.no"};
            await userManager.CreateAsync(moderatorUser, "Password1.");
            await userManager.AddToRoleAsync(moderatorUser, "Moderator");

            // Add one regular user
            var userUser = new ApplicationUser { UserName = "user@uia.no", Email = "user@uia.no" };
            await userManager.CreateAsync(userUser, "Password1.");
        }

                
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();

                // Browser Link is not compatible with Kestrel 1.1.0
                // For details on enabling Browser Link, see https://go.microsoft.com/fwlink/?linkid=840936
                // app.UseBrowserLink()

                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                    
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();

                    // Add regular data here
                   
                   
                    var TopCat1 = new CategoryModel("topCat1", null, new List<CategoryModel>(), null);

                    var SubCat1 = new CategoryModel("SubCat1", TopCat1, null, null);
                    TopCat1.children.Add(SubCat1);
                    var SubCat2 = new CategoryModel("SubCat2", TopCat1, null, null);
                    TopCat1.children.Add(SubCat2);
                    var SubCat3 = new CategoryModel("SubCat3", TopCat1, null, null);
                    TopCat1.children.Add(SubCat3);
                    
                    db.topCategories.Add(TopCat1);
                    db.topCategories.Include("CategoryModel");

                    db.subCategories.Add(SubCat1);
                    db.subCategories.Add(SubCat2);
                    db.subCategories.Add(SubCat3);



                    // Then create the standard users and roles
                    CreateUsersAndRoles(serviceScope).Wait();
                    db.SaveChanges();
                }
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
