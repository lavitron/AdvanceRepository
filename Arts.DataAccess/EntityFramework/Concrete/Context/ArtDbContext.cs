using System.Reflection;
using Arts.Entity.Entity.Login;
using Microsoft.EntityFrameworkCore;

namespace Arts.DataAccess.EntityFramework.Concrete.Context
{
    public class ArtDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<LoginClaim> LoginClaims { get; set; }

        public ArtDbContext(DbContextOptions<ArtDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}