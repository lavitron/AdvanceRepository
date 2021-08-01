using Arts.Entity.Entity.Art;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arts.DataAccess.EntityFramework.Concrete.Configuration.Art
{
    public class ArtistArtworkConfiguration : IEntityTypeConfiguration<ArtistArtwork>
    {
        public void Configure(EntityTypeBuilder<ArtistArtwork> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.ArtistId).IsRequired();
            builder.Property(p => p.ArtworkId).IsRequired();
            builder.HasOne(p => p.ArtistFk)
                .WithMany(p => p.ArtistArtworks)
                .HasForeignKey(p => p.ArtistId);
            builder.HasOne(p => p.ArtworkFk)
                .WithMany(p => p.ArtistArtworks)
                .HasForeignKey(p => p.ArtworkId);
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}