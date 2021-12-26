using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
//Satýr 34 için:
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebOdevim.Data;
using System.Globalization;
using Microsoft.AspNetCore.Identity.UI;


namespace WebOdevim
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //Servislerimizi proje içine dahil etmek için bulunur:
        public void ConfigureServices(IServiceCollection services)
        {
          
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddIdentity<IdentityUser, IdentityRole>()
               .AddDefaultTokenProviders()
               .AddDefaultUI()
               .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddRazorPages();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
          

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            ////Ben viewler la controllerlarý kullanacaðým demek için. Razor page iþin içine girmesin. 
            services.AddControllersWithViews();

          


        }

        //Configure içerisinde süreç vardýr.  Request, response süreçleri.(Client ve server arasýndaki iletiþim için)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // wwwroot altýndaki klasörler açýlsýn diye
            app.UseStaticFiles();
            // node modules açýlsýn diye
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
                RequestPath = "/modules"
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // localhost:5000/product/list/2 dediðinde mesela product controller'ý kullanýcýya gönderir (list: action olur
            //2'de id olur.) 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    //id olmak zorunda deðil ? ekliyoruz. localhost:5000/product/list de sayýlsýn diye
                    //Varsayýlan controller, varsayýlan action gerekli olduðu için
                    //default routing için:
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );

            });
        }
    }
}
