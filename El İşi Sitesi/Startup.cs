using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
//Sat�r 34 i�in:
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

        //Servislerimizi proje i�ine dahil etmek i�in bulunur:
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

            ////Ben viewler la controllerlar� kullanaca��m demek i�in. Razor page i�in i�ine girmesin. 
            services.AddControllersWithViews();

          


        }

        //Configure i�erisinde s�re� vard�r.  Request, response s�re�leri.(Client ve server aras�ndaki ileti�im i�in)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // wwwroot alt�ndaki klas�rler a��ls�n diye
            app.UseStaticFiles();
            // node modules a��ls�n diye
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

            // localhost:5000/product/list/2 dedi�inde mesela product controller'� kullan�c�ya g�nderir (list: action olur
            //2'de id olur.) 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    //id olmak zorunda de�il ? ekliyoruz. localhost:5000/product/list de say�ls�n diye
                    //Varsay�lan controller, varsay�lan action gerekli oldu�u i�in
                    //default routing i�in:
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );

            });
        }
    }
}
