using Arts.Entity.Entity.Login;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arts.DataAccess.EntityFramework.Concrete.Configuration.Login
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Surname).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Address).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Phone).HasMaxLength(11).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(50).IsRequired();
            builder.Property(p => p.PasswordSalt).IsRequired();
            builder.Property(p => p.PasswordHash).IsRequired();
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}