using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACSWeb.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
//using Npgsql.EntityFrameworkCore.PostgreSQL не требуется здесь
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ACSWeb
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
            //v1:
            //-------------------
            //services.AddDbContext<GTSContext>(options =>       //Регистрация GTSContext как службы
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //------------

            //v2:
            // When used with ASP.net core, add these lines to Startup.cs
            var connectionString = Configuration.GetConnectionString("GTSContext");
            services.AddEntityFrameworkNpgsql().AddDbContext<GTSContext>(options => options.UseNpgsql(connectionString));




            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
