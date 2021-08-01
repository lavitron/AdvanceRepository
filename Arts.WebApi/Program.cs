using System;
using System.Linq;
using Arts.DataAccess.EntityFramework.Concrete.Context;
using Arts.Entity.Entity.Login;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Arts.WebApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var service = scope.ServiceProvider;
            //Add migration to database if database not created.
            try
            {
                var dbContext = service.GetRequiredService<ArtDbContext>();
                dbContext.Database.Migrate();
                var anyLoginClaims = dbContext.LoginClaims.Any();
                if (!anyLoginClaims)
                {
                    var loginClaims = Enum.GetValues(typeof(ClaimEnum)).Cast<ClaimEnum>();
                    foreach (var claim in loginClaims)
                        dbContext.Add(new LoginClaim
                        {
                            Name = claim.ToString(),
                            CDate = DateTime.Now
                        });

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}