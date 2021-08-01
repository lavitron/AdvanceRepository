using Arts.Business.Abstract;
using Arts.Business.Concrete;
using Arts.DataAccess.LoginSecurity.Jwt;
using Microsoft.Extensions.DependencyInjection;

namespace Arts.Infrastructure
{
    public static class ServiceInstaller
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenHelper, TokenHelper>();
        }
    }
}