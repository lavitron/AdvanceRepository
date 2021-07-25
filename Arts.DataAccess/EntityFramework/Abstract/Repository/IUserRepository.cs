using System.Threading.Tasks;
using Arts.Entity.Dto.User;
using Arts.Entity.Entity.Login;
using Core.EfRepository;

namespace Arts.DataAccess.EntityFramework.Abstract.Repository
{
    public interface IUserRepository : ICoreRepository<User>
    {
        Task RegisterAsyncRm(UserRegisterDto user);

        Task<User> GetLoginUserAsyncRm(UserLoginDto user);
    }
}