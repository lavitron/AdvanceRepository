using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arts.DataAccess.EntityFramework.Abstract.Repository;
using Arts.Entity.Entity.Login;
using Core.EfRepository;
using Microsoft.EntityFrameworkCore;

namespace Arts.DataAccess.EntityFramework.Concrete.Repository
{
    public class UserClaimRepository : CoreRepository<UserClaim>, IUserClaimRepository
    {
        public UserClaimRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<LoginClaim>> GetUserClaimsByUserIdAsyncRm(int id)
        {
            return await JustRawQuery(p => p.UserId == id)
                .Select(p => p.LoginClaimFk).ToListAsync();
        }
    }
}