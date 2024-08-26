using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using todolist.Data;

namespace todolist
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
            // Register repositories with dependency injection
            services.AddScoped<TaskRepository>(provider =>
                new TaskRepository(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<CategoryRepository>(provider =>
                new CategoryRepository(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<UserRepository>(provider =>
                new UserRepository(Configuration.GetConnectionString("DefaultConnection")));
            // Register MVC services

            //
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            //


            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}");
            });
        }
    }
}
//public class Startup
//{
//    public Startup(IConfiguration configuration)
//    {
//        Configuration = configuration;
//    }

//    public IConfiguration Configuration { get; }

//    public void ConfigureServices(IServiceCollection services)
//    {
//        // Register repositories with dependency injection
//        services.AddScoped<TaskRepository>(provider =>
//            new TaskRepository(Configuration.GetConnectionString("DefaultConnection")));
//        services.AddScoped<CategoryRepository>(provider =>
//            new CategoryRepository(Configuration.GetConnectionString("DefaultConnection")));
//        services.AddScoped<UserRepository>(provider =>
//            new UserRepository(Configuration.GetConnectionString("DefaultConnection")));

//        // Register MVC services
//        services.AddControllersWithViews();

//        // Add authentication services
//        // Commenting out authentication and authorization services
//        /*
//        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//            .AddCookie(options =>
//            {
//                options.Cookie.HttpOnly = true;
//                options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Ensures the cookie is only sent over HTTPS
//                options.Cookie.SameSite = SameSiteMode.Strict; // Set SameSite policy as needed
//                options.LoginPath = "/Account/Login";
//                options.LogoutPath = "/Account/Logout";
//            });

//        services.AddAuthorization(options =>
//        {
//            options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
//            options.AddPolicy("ClientPolicy", policy => policy.RequireRole("Client"));
//        });
//        */

//        // Register session services
//        //services.AddSession(options =>
//        //{
//        //    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
//        //    options.Cookie.HttpOnly = true;
//        //    options.Cookie.IsEssential = true;
//        //    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Ensures the cookie is only sent over HTTPS
//        //    options.Cookie.SameSite = SameSiteMode.Strict; // Set SameSite policy as needed
//        //});
//    }

//    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//    {
//        if (env.IsDevelopment())
//        {
//            app.UseDeveloperExceptionPage();
//        }
//        else
//        {
//            app.UseExceptionHandler("/Home/Error");
//            app.UseHsts();
//        }

//        app.UseHttpsRedirection();
//        app.UseStaticFiles();
//        app.UseRouting();
//        app.UseSession(); // Ensure this is before UseAuthorization
//        // Commenting out authentication and authorization middleware
//        // app.UseAuthentication();
//        // app.UseAuthorization();

//        app.UseEndpoints(endpoints =>
//        {
//            endpoints.MapControllerRoute(
//                name: "default",
//                pattern: "{controller=Task}/{action=Index}/{id?}");
//        });
//    }
//}
