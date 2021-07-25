using System;

namespace Arts.DataAccess.LoginSecurity.Jwt
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}