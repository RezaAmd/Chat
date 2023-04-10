using Chat.Application.Interfaces.Identity;
using Chat.Application.Models;
using Chat.Application.Services.Identity;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            // Identity Service Life Time
            services.AddScoped<ErrorDescriber>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<RoleService>()
                .AddTransient<IMapper, Mapper>();

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            //.AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.IgnoreNullValues = true;
            //})

            return services;
        }

    }
}