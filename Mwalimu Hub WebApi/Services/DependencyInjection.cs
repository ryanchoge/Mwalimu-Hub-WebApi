using Mwalimu_Hub_WebApi.Services.AdminService;
using Mwalimu_Hub_WebApi.Services.Aurhenticaton;
using Mwalimu_Hub_WebApi.Services.TeacherService;

namespace Mwalimu_Hub_WebApi.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
          
            return services;
        }
    }
}
