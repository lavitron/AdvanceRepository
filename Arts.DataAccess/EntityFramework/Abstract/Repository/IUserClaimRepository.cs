using System.Collections.Generic;
using System.Threading.Tasks;
using Arts.Entity.Entity.Login;
using Core.EfRepository;

namespace Arts.DataAccess.EntityFramework.Abstract.Repository
{
    public interface IUserClaimRepository : ICoreRepository<UserClaim>
    {
        Task<List<LoginClaim>> GetUserClaimsByUserIdAsyncRm(int id);
    }
}