using Arts.DataAccess.EntityFramework.Abstract.Uow;
using Arts.DataAccess.EntityFramework.Concrete.Context;
using Arts.DataAccess.EntityFramework.Concrete.Uow;
using Core.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Arts.Infrastructure
{
    public static class DbInstaller
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, Mapper>();
            services.AddDbContextPool<ArtDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer("Server=.\\SQLExpress;Database=Arts;Trusted_Connection=True;"));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}