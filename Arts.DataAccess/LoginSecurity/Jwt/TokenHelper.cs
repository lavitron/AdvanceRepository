using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Arts.DataAccess.LoginSecurity.Encryption;
using Arts.DataAccess.LoginSecurity.Extension;
using Arts.Entity.Entity.Login;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Arts.DataAccess.LoginSecurity.Jwt
{
    public class TokenHelper : ITokenHelper
    {
        private readonly TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        public TokenHelper(IOptions<TokenOptions> tokenOptions)
        {
            _tokenOptions = tokenOptions.Value;
        }

        public AccessToken CreateToken(User user, IEnumerable<LoginClaim> loginClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwtSecurityToken = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, loginClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        private JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, IEnumerable<LoginClaim> loginClaims)
        {
            var jwtSecurityToken = new JwtSecurityToken(
                tokenOptions.Issuer,
                tokenOptions.Audience,
                SetJwtClaims(user, loginClaims),
                DateTime.Now,
                _accessTokenExpiration,
                signingCredentials
            );
            return jwtSecurityToken;
        }

        private static IEnumerable<Claim> SetJwtClaims(User user, IEnumerable<LoginClaim> loginClaims)
        {
            var claims = new List<Claim>();
            claims.AddUserIdentifier(user.Id);
            claims.AddName($"{user.Name} {user.Surname}");
            claims.AddEmail(user.Email);
            claims.AddRole(loginClaims.Select(p => p.Name).AsEnumerable());
            return claims;
        }
    }
}