using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Budgets;
using Budgets.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Westwind.AspnetCore.LiveReload;
using Microsoft.Extensions.Hosting;
using Westwind.AspNetCore.LiveReload;

namespace BaryonyxBudgeting
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
            services.ConfigureDataConnections(Configuration);
            services.ConfigureIdentity();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IBudgetRepository, EfBudgetRepository>();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddMvc().AddRazorRuntimeCompilation();
            services.AddDistributedMemoryCache();
            services.AddControllersWithViews();
            services.AddLiveReload();
            services.AddAuthentication();
            services.AddAuthorization();
            services.AddSession();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseLiveReload();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Login",
                    pattern: "Login",
                    defaults: new { controller = "Account", Action = "Login" });
                endpoints.MapControllerRoute(
                    name: "Budgets",
                    pattern: "Budgets",
                    defaults: new { controller = "Budget", Action = "Index" });
                endpoints.MapControllerRoute(
                    name: "CreateBudget",
                    pattern: "CreateBudget",
                    defaults: new { controller = "Budget", Action = "CreateBudget" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}