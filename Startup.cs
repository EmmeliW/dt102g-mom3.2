using EFprojekt.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFprojekt
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Use MVC
            services.AddControllersWithViews(); 
            // Connection to DB
            services.AddDbContext<RecordContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultDbString")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles(); // Använd statiska filer

            app.UseEndpoints(endpoints =>
            {
                // Routing
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Record}/{action=Index}/{id?}"
                );
            });
        }
    }
}
