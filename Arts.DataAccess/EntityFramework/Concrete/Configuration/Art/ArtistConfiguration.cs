using Arts.Entity.Entity.Art;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arts.DataAccess.EntityFramework.Concrete.Configuration.Art
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Surname).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Nationality).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Biography).HasMaxLength(1000).IsRequired();
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}