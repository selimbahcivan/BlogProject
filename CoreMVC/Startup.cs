using Business.AutoMapper.Profiles;
using Business.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;
using CoreMVC.AutoMapper.Profiles;
using CoreMVC.Helpers.Abstract;
using CoreMVC.Helpers.Concrete;
using Microsoft.AspNetCore.Http;

namespace CoreMVC
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
        {                                       // tekrar tekrar derlemeye gerek kalmýyor.
            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; // include edilen(iç içe / nested objeler category'ye dahil olan article nesnesi mesela) convert etmesini saðlar.
            });
            services.AddSession();
            services.AddAutoMapper(typeof(CategoryProfile), typeof(ArticleProfile), typeof(UserProfile)); // Derlenme esnasýnda AutoMapper'ýn buradaki sýnýflarý taramasýný saðlýyor.
            services.LoadMyServices(connectionString: Configuration.GetConnectionString("LocalDB"));
            services.AddScoped<IImageHelper, ImageHelper>();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Admin/User/Login");
                options.LogoutPath = new PathString("/Admin/User/Logout");
                options.Cookie = new CookieBuilder()
                {
                    Name = "BlogProject",
                    HttpOnly = true, // XSS (Cross Site Scripting) saldýrýlarýný önler. Cookie'lerin client side'dan eriþimi kýsýtlar.
                    SameSite = SameSiteMode.Strict, // CSRF(Cross Site Request Forgery)/XSRF/Session Riding -> güvenlik açýðý.
                                                    // Strict Cookie bilgilerinin sadece kendi sitemizden geldiðinde iþlenmesini saðlar. Cookie'nin nereden geldiðine bakar.
                    SecurePolicy = CookieSecurePolicy.SameAsRequest, // Normalde .Always kullanýlýr.
                };
                options.SlidingExpiration = true; // 
                options.ExpireTimeSpan = System.TimeSpan.FromDays(7); // Cookie bilgileri 7 gün boyunca tutulacak.
                options.AccessDeniedPath = new PathString("/Admin/User/AccessDenied"); // Giriþ yapmýþ ama yetkisi olmayan bir yere girmeye çalýþan kullanýcý için
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages(); // View bulunamadýðýnda gösterilecek sayfa.
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSession();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute( // Admin Areasý için eklendi.
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}