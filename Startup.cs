using LinqToDB;
using LinqToDB.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PasteryShop.Data;
using PasteryShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasteryShop
{

    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<PasteryShopContext>(cfg =>
            {
                cfg.UseSqlServer(_config.GetConnectionString("PasteryShopConnectionStrings"));
            });
            services.AddTransient<PasteryShopSeeder>();

         
            services.AddTransient<IMailService, NullMailService>();

            services.AddScoped<IPasteryShopRepository, PasteryShopRepository>();



            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddControllersWithViews()
              .AddRazorRuntimeCompilation();
            services.AddRazorPages();
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
                // Add Error Page
                app.UseExceptionHandler("/error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute("Fallback",
                  "{controller}/{action}/{id?}",
                  new { controller = "App", action = "Index" });

                cfg.MapRazorPages();
            });
        }
    }
}
