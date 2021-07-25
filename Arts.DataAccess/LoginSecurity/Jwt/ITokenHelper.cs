using System.Collections.Generic;
using Arts.Entity.Entity.Login;

namespace Arts.DataAccess.LoginSecurity.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, IEnumerable<LoginClaim> loginClaims);
    }
}