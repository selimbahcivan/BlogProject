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
        {                                       // tekrar tekrar derlemeye gerek kalm�yor.
            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; // include edilen(i� i�e / nested objeler category'ye dahil olan article nesnesi mesela) convert etmesini sa�lar.
            });
            services.AddSession();
            services.AddAutoMapper(typeof(CategoryProfile), typeof(ArticleProfile), typeof(UserProfile)); // Derlenme esnas�nda AutoMapper'�n buradaki s�n�flar� taramas�n� sa�l�yor.
            services.LoadMyServices(connectionString: Configuration.GetConnectionString("LocalDB"));
            services.AddScoped<IImageHelper, ImageHelper>();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Admin/User/Login");
                options.LogoutPath = new PathString("/Admin/User/Logout");
                options.Cookie = new CookieBuilder()
                {
                    Name = "BlogProject",
                    HttpOnly = true, // XSS (Cross Site Scripting) sald�r�lar�n� �nler. Cookie'lerin client side'dan eri�imi k�s�tlar.
                    SameSite = SameSiteMode.Strict, // CSRF(Cross Site Request Forgery)/XSRF/Session Riding -> g�venlik a����.
                                                    // Strict Cookie bilgilerinin sadece kendi sitemizden geldi�inde i�lenmesini sa�lar. Cookie'nin nereden geldi�ine bakar.
                    SecurePolicy = CookieSecurePolicy.SameAsRequest, // Normalde .Always kullan�l�r.
                };
                options.SlidingExpiration = true; // 
                options.ExpireTimeSpan = System.TimeSpan.FromDays(7); // Cookie bilgileri 7 g�n boyunca tutulacak.
                options.AccessDeniedPath = new PathString("/Admin/User/AccessDenied"); // Giri� yapm�� ama yetkisi olmayan bir yere girmeye �al��an kullan�c� i�in
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages(); // View bulunamad���nda g�sterilecek sayfa.
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
                endpoints.MapAreaControllerRoute( // Admin Areas� i�in eklendi.
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