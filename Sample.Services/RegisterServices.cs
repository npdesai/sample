using Microsoft.Extensions.DependencyInjection;
using Sample.Services.Interfaces;
using Sample.Services.Services;

namespace Sample.Services
{
    public static class RegisterServices
    {
        public static void RegisterSampleServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
