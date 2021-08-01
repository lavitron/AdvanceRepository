using System.Reflection;
using Arts.Entity.Entity.Art;
using Arts.Entity.Entity.Login;
using Microsoft.EntityFrameworkCore;

namespace Arts.DataAccess.EntityFramework.Concrete.Context
{
    public class ArtDbContext : DbContext
    {
        public ArtDbContext(DbContextOptions<ArtDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<ArtistArtwork> ArtistArtworks { get; set; }
        public DbSet<LoginClaim> LoginClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}