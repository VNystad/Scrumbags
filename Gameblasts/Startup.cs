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

            if(!await roleManager.RoleExistsAsync("Admin"))
            {
                // First create the admin role if it doesn't already exists.
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if(!await roleManager.RoleExistsAsync("Moderator"))
            {
                // Then create moderator role if it doesn't already exists.
                await roleManager.CreateAsync(new IdentityRole("Moderator"));
            }

            if(!await roleManager.RoleExistsAsync("Member"))
            {
                // Then create member role if it doesn't already exists.
                await roleManager.CreateAsync(new IdentityRole("Member"));
            }

            if(!await roleManager.RoleExistsAsync("Banned"))
            {
                // Then create banned role if it doesn't already exists.
                await roleManager.CreateAsync(new IdentityRole("Banned"));
            }

            if(!await roleManager.RoleExistsAsync("Writer"))
            {
                // Then create writer role if it doesn't already exists.
                await roleManager.CreateAsync(new IdentityRole("Writer"));
            }

            var user = await userManager.FindByNameAsync("admin@uia.no");
            if(user == null)
            {
                // Then add one admin user if it doesn't already exists.
                var adminUser = new ApplicationUser( "admin@uia.no", "admin@uia.no" );
                await userManager.CreateAsync(adminUser, "Password2.Admin");
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            user = await userManager.FindByNameAsync("moderator@uia.no");
            if(user == null)
            {
                // Add one moderator user if it doesn't already exists.
                var moderatorUser = new ApplicationUser ("moderator@uia.no", "moderator@uia.no");
                await userManager.CreateAsync(moderatorUser, "Password1.");
                await userManager.AddToRoleAsync(moderatorUser, "Moderator");
            }

            user = await userManager.FindByNameAsync("user@uia.no");
            if(user == null)
            {
                // Add one regular user if it doesn't already exists.
                var userUser = new ApplicationUser ("user@uia.no", "user@uia.no" );
                await userManager.CreateAsync(userUser, "Password1.");
                await userManager.AddToRoleAsync(userUser, "Member");
            }

            user = await userManager.FindByNameAsync("vebis");
            if(user == null)
            {
                // Add one regular user if it doesn't already exists.
                var userUser = new ApplicationUser ("vebis", "vebis@uia.no" );
                await userManager.CreateAsync(userUser, "Password1.");
                await userManager.AddToRoleAsync(userUser, "Member");
            }

            user = await userManager.FindByNameAsync("marty");
            if(user == null)
            {
                // Add one regular user if it doesn't already exists.
                var userUser = new ApplicationUser ("marty", "marty@uia.no" );
                await userManager.CreateAsync(userUser, "Password1.");
                await userManager.AddToRoleAsync(userUser, "Member");
            }            


        }

        public void CreateCategories(ApplicationDbContext db, string topCatName, string logoURL = null, string imageURL = null)
        {
            var TopCat1 = new CategoryModel(topCatName, null, logoURL, imageURL);

            var SubCat1 = new CategoryModel("General Discussion", TopCat1);
            TopCat1.children.Add(SubCat1);
            var SubCat2 = new CategoryModel("News", TopCat1);
            TopCat1.children.Add(SubCat2);
            var SubCat3 = new CategoryModel("Media", TopCat1);
            TopCat1.children.Add(SubCat3);
            var SubCat4 = new CategoryModel("Looking to play", TopCat1);
            TopCat1.children.Add(SubCat4);
            var SubCat5 = new CategoryModel("Support", TopCat1);
            TopCat1.children.Add(SubCat5);
            
            db.Categories.Add(TopCat1);
            db.Categories.Include("CategoryModel");

            db.Categories.Add(SubCat1);
            db.Categories.Add(SubCat2);
            db.Categories.Add(SubCat3);
            db.Categories.Add(SubCat4);
            db.Categories.Add(SubCat5);
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
                   
                   CreateCategories(db, "CsGO", "https://i.vimeocdn.com/filter/overlay?src0=https%3A%2F%2Fi.vimeocdn.com%2Fvideo%2F571714210_1280x720.jpg&src1=https%3A%2F%2Ff.vimeocdn.com%2Fimages_v6%2Fshare%2Fplay_icon_overlay.png", "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d9/Counter-Strike_Global_Offensive.svg/2000px-Counter-Strike_Global_Offensive.svg.png");
                   CreateCategories(db, "Dota2", "https://www.notebookcheck.net/fileadmin/Notebooks/News/_nc3/dota_2_official_9.jpg", "http://i.imgur.com/soaxrw9.png");
                   CreateCategories(db, "SuperSmash", "https://c1.staticflickr.com/8/7585/16384472053_7af64c250a_b.jpg", "https://s-media-cache-ak0.pinimg.com/originals/ae/81/0e/ae810e01a95d5962a314c4f49f9c1145.jpg");
                   CreateCategories(db, "Hearthstone", "https://i.ytimg.com/vi/CjLvnY_uPbI/maxresdefault.jpg", "http://www.kassquatch.com/wp-content/uploads/2014/05/Hearthstone_Logo.png?w=240");
                   CreateCategories(db, "LoL", "https://c1.staticflickr.com/8/7569/16316063786_0bf585b54b_b.jpg", "https://upload.wikimedia.org/wikipedia/commons/d/d3/LoL_New_Logo.png");
                   CreateCategories(db, "Overwatch", "https://bnetcmsus-a.akamaihd.net/cms/blog_header/v3/V3GMDVG8LC5U1472588787764.jpg", "https://upload.wikimedia.org/wikipedia/commons/1/10/Overwatch_text_logo.svg");
                   CreateCategories(db, "QuakeChampions", "https://static.gamespot.com/uploads/original/536/5360430/3104922-quake_champions_quakecon_2016_4_1470331175.png", "https://quake.bethesda.net/assets/images/quake-logo--colored-a277cd4f9b.png");
                   CreateCategories(db, "StarCraft2", "http://media.blizzard.com/battle.net/logos/og-sc2-legacy-of-the-void.jpg", "http://cdn3.dualshockers.com/wp-content/uploads/2010/08/starcraft_II_logo.png");
                   CreateCategories(db, "UnrealTournament", "https://de45xmedrsdbp.cloudfront.net/UnrealTournament/malcolmFlak04-1024x576-1024x576-581966620.png", "https://s-media-cache-ak0.pinimg.com/originals/2d/2d/1c/2d2d1c56c8a856cb23dfb70fd111e34a.png");

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
                    "Inbox",
                    "User/Inbox",
                    new { controller = "User", action = "Inbox"}
                );

                routes.MapRoute(
                    "EditProfile",
                    "User/EditProfile",
                    new { controller = "User", action = "EditProfile"}
                );

                routes.MapRoute(
                    "PrivMsg",
                    "NewMsg/{id?}",
                    new { controller = "User", action = "NewMessage"}
                );

                routes.MapRoute(
                    "UserProfile",
                    "User/{id}",
                    new { controller = "User", action = "Profile"}
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                /**/
            });
        }
    }
}
