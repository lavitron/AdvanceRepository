using System.Threading.Tasks;
using Arts.Entity.Dto.ArtistArtwork;
using Arts.Entity.Entity.Art;
using Arts.Entity.Pagination;
using Core.EfRepository;

namespace Arts.DataAccess.EntityFramework.Abstract.Repository
{
    public interface IArtistArtworkRepository : ICoreRepository<ArtistArtwork>
    {
        Task<PageList<ArtistArtworkListDto>> ListArtistArtworkPgAsyncRm(PaginationInput paginationInput);
    }
}