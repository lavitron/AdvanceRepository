using Arts.DataAccess.EntityFramework.Abstract.Uow;
using Arts.DataAccess.EntityFramework.Concrete.Context;
using Arts.DataAccess.EntityFramework.Concrete.Uow;
using Core.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Arts.Infrastructure
{
    public static class DbInstaller
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable("MSSQL_URI");
            services.AddSingleton<IMapper, Mapper>();
            services.AddDbContextPool<ArtDbContext>(options => options.UseLazyLoadingProxies()
            .UseSqlServer(connectionString ?? throw new InvalidOperationException()));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}