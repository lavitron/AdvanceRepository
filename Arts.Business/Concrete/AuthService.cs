using System.Threading.Tasks;
using Arts.Business.Abstract;
using Arts.DataAccess.EntityFramework.Abstract.Uow;
using Arts.DataAccess.LoginSecurity.Jwt;
using Arts.Entity.Dto.User;
using Arts.Entity.Entity.Login;

namespace Arts.Business.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IUnitOfWork _unitOfWork;


        public AuthService(IUnitOfWork unitOfWork, ITokenHelper tokenHelper)
        {
            _unitOfWork = unitOfWork;
            _tokenHelper = tokenHelper;
        }


        public async Task<int> RegisterAsync(UserRegisterDto user)
        {
            await _unitOfWork.Users.RegisterAsyncRm(user);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<User> GetLoginUserAsync(UserLoginDto user)
        {
            return await _unitOfWork.Users.GetLoginUserAsyncRm(user);
        }

        public async Task<AccessToken> CreateAccessTokenAsync(User user)
        {
            var currentUserClaims = await _unitOfWork.UserClaims.GetUserClaimsByUserIdAsyncRm(user.Id);
            if (currentUserClaims == null) return null;
            var accessToken = _tokenHelper.CreateToken(user, currentUserClaims);
            return accessToken;
        }
    }
}