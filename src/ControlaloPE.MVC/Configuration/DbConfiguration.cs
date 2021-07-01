using ControlaloPE.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControlaloPE.MVC.Configuration{
    public static class DBConfiguration{
        public static IServiceCollection AddDbConfiguration(this IServiceCollection services, IConfiguration configuration){
            services.AddDbContext<ControlaloPEContext>(option => 
            option.UseSqlServer(configuration.GetConnectionString("conBD")));
            return services;
        }
    }
}