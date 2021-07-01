using ControlaloPE.Infra.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControlaloPE.MVC.Configuration{
    public static class IdentityConfiguration{
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration){
            services.AddDbContext<ControlaloPEIdentityContext>(option => 
            option.UseSqlServer(configuration.GetConnectionString("conBD")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ControlaloPEIdentityContext>()
                .AddDefaultTokenProviders();

           ConfigurarFormatoPassword(services);

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(config =>
                {
                    config.LoginPath = "/Auth/Login";
                });
            return services;
        }
         public static IApplicationBuilder UseIdentityConfiguration(this IApplicationBuilder app){
            app.UseAuthentication();
            app.UseAuthorization();
            return app;
        }
        private static void ConfigurarFormatoPassword(IServiceCollection services){
            services.Configure<IdentityOptions>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });
        }
    }
}