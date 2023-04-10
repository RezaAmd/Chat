using Chat.Application.Interfaces.Identity;
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

            services.AddControllers();

            return services;
        }

    }
}