using System;
using System.Threading.Tasks;
using Arts.DataAccess.EntityFramework.Abstract.Repository;

namespace Arts.DataAccess.EntityFramework.Abstract.Uow
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IUserRepository Users { get; }
        IUserClaimRepository UserClaims { get; }
        ILoginClaimRepository LoginClaims { get; }
        IArtistArtworkRepository ArtistArtworks { get; }

        int Save();
        Task<int> SaveAsync();
        Task<int> SaveTransactionAsync();
    }
}