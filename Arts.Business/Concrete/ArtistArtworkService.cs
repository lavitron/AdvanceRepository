using System.Threading.Tasks;
using Arts.Business.Abstract;
using Arts.DataAccess.EntityFramework.Abstract.Uow;
using Arts.Entity.Dto.ArtistArtwork;
using Arts.Entity.Pagination;
using Core.Utility;
using Mapster;

namespace Arts.Business.Concrete
{
    public class ArtistArtworkService : IArtistArtworkService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ArtistArtworkService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<PageList<ArtistArtworkListDto>> ListArtistArtworkPgAsync(PaginationInput paginationInput)
        {
            return await _unitOfWork.ArtistArtworks.ListArtistArtworkPgAsyncRm(paginationInput);
        }
    }
}