using Arts.Entity.Entity.Login;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arts.DataAccess.EntityFramework.Concrete.Configuration.Login
{
    public class LoginClaimConfiguration : IEntityTypeConfiguration<LoginClaim>
    {
        public void Configure(EntityTypeBuilder<LoginClaim> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired();

            builder.HasQueryFilter(p => !p.IsDeleted);
            //builder.HasData(new LoginClaim {Id = 1, Name = "Admin"});
            //builder.HasData(new LoginClaim {Id = 2, Name = "User"});
        }
    }
}