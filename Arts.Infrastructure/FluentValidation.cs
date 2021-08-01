using Arts.Business.FluentValidation.User;
using Arts.Entity.Dto.User;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Arts.Infrastructure
{
    public static class FluentValidation
    {
        public static void AddFluentValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidator<UserLoginDto>, UserLoginValidation>();
            services.AddScoped<IValidator<UserRegisterDto>, UserRegisterValidation>();
        }
    }
}