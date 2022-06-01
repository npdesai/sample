using Microsoft.Extensions.DependencyInjection;
using Sample.Repository.Interfaces;
using Sample.Repository.Repositories;

namespace Sample.Repository
{
    public static class RegisterRepositories
    {
        public static void RegisterSampleRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
