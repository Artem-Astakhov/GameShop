using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GameShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<GameContext>(options => options.UseSqlServer(connection));
            services.AddMvc();
            

        }

    
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseStatusCodePages();            
            app.UseRouting();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Game}/{action=List}/{id?}");
            });
        }
    }
}
