using System.Reflection;
using AutoInject;
using ControlaloPE.BuildingBlocks.Core;
using ControlaloPE.Domain.Commands;
using ControlaloPE.Infra.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ControlaloPE.MVC.Configuration
{
    public static class DIConfiguration{
        public static IServiceCollection AddDIConfiguration(this IServiceCollection services, Assembly assembly){
            services.AddMediatR(
            typeof(Command).Assembly, 
            typeof(CommandHandler).Assembly)
            .AddAutoDI(assembly);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserManager, UserManager>();
            return services;
        }
    }
}