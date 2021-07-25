using System.Threading.Tasks;
using Arts.DataAccess.LoginSecurity.Jwt;
using Arts.Entity.Dto.User;
using Arts.Entity.Entity.Login;

namespace Arts.Business.Abstract
{
    public interface IAuthService
    {
        /// <summary>
        ///     User Register.
        /// </summary>
        /// <param name="user">UserRegisterDto</param>
        /// <returns>SaveChanges result</returns>
        Task<int> RegisterAsync(UserRegisterDto user);

        /// <summary>
        ///     Get user who wants to login.
        /// </summary>
        /// <param name="user">UserLoginDto</param>
        /// <returns>User</returns>
        Task<User> GetLoginUserAsync(UserLoginDto user);

        /// <summary>
        ///     If user infos are correct, creates access token.
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>Access token</returns>
        Task<AccessToken> CreateAccessTokenAsync(User user);
    }
}