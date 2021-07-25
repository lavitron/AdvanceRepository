using System;
using System.Threading.Tasks;
using Arts.DataAccess.EntityFramework.Abstract.Repository;
using Arts.DataAccess.EntityFramework.Abstract.Uow;
using Arts.DataAccess.EntityFramework.Concrete.Context;
using Arts.DataAccess.EntityFramework.Concrete.Repository;

namespace Arts.DataAccess.EntityFramework.Concrete.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ArtDbContext _dbContext;
        private LoginClaimRepository _loginClaimRepository;
        private UserClaimRepository _userClaimRepository;
        private UserRepository _userRepository;

        public UnitOfWork(ArtDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUserRepository Users => _userRepository ??= new UserRepository(_dbContext);
        public IUserClaimRepository UserClaims => _userClaimRepository ??= new UserClaimRepository(_dbContext);
        public ILoginClaimRepository LoginClaims => _loginClaimRepository ??= new LoginClaimRepository(_dbContext);

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public Task<int> SaveTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask DisposeAsync()
        {
            return _dbContext.DisposeAsync();
        }
    }
}