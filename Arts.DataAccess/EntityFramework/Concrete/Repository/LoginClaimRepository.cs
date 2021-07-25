using Arts.DataAccess.EntityFramework.Abstract.Repository;
using Arts.Entity.Entity.Login;
using Core.EfRepository;
using Microsoft.EntityFrameworkCore;

namespace Arts.DataAccess.EntityFramework.Concrete.Repository
{
    public class LoginClaimRepository : CoreRepository<LoginClaim>, ILoginClaimRepository
    {
        public LoginClaimRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}