using System;
using System.Threading.Tasks;
using Arts.DataAccess.EntityFramework.Abstract.Repository;
using Arts.DataAccess.LoginSecurity.Hashing;
using Arts.Entity.Dto.User;
using Arts.Entity.Entity.Login;
using Core.EfRepository;
using Microsoft.EntityFrameworkCore;

namespace Arts.DataAccess.EntityFramework.Concrete.Repository
{
    public class UserRepository : CoreRepository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task RegisterAsyncRm(UserRegisterDto user)
        {
            HashingHelper.CreatePasswordHash(user.Password, out var passwordHash, out var passwordSalt);
            var newUser = new User
            {
                Name = user.Name,
                Surname = user.Surname,
                Phone = user.Phone,
                Address = user.Address,
                CDate = DateTime.Now,
                Email = user.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash
            };
            newUser.UserClaims.Add(new UserClaim
            {
                LoginClaimId = user.UserRole
            });

            await AddAsync(newUser);
        }

        public async Task<User> GetLoginUserAsyncRm(UserLoginDto user)
        {
            var currentUser = await GetAsync(p => p.Email == user.Email);
            if (currentUser == null) return null;
            var passwordMatch = HashingHelper.VerifyPasswordHash(user.Password, currentUser.PasswordHash,
                currentUser.PasswordSalt);
            return passwordMatch ? currentUser : null;
        }
    }
}