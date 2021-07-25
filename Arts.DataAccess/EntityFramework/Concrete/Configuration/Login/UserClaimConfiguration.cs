using Arts.Entity.Entity.Login;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arts.DataAccess.EntityFramework.Concrete.Configuration.Login
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.LoginClaimId).IsRequired();

            builder.HasOne(p => p.UserFk)
                .WithMany(p => p.UserClaims)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.LoginClaimFk)
                .WithMany(p => p.UserClaims)
                .HasForeignKey(p => p.LoginClaimId).OnDelete(DeleteBehavior.Cascade);

            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}