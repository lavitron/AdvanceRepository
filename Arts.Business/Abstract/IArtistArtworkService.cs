using System.Threading.Tasks;
using Arts.Entity.Dto.ArtistArtwork;
using Arts.Entity.Pagination;

namespace Arts.Business.Abstract
{
    public interface IArtistArtworkService
    {
        Task<PageList<ArtistArtworkListDto>> ListArtistArtworkPgAsync(PaginationInput paginationInput);
    }
}