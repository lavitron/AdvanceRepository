using System.Linq;
using System.Threading.Tasks;
using Arts.DataAccess.EntityFramework.Abstract.Repository;
using Arts.Entity.Dto.ArtistArtwork;
using Arts.Entity.Entity.Art;
using Arts.Entity.Pagination;
using Core.EfRepository;
using Microsoft.EntityFrameworkCore;

namespace Arts.DataAccess.EntityFramework.Concrete.Repository
{
    public class ArtistArtworkRepository : CoreRepository<ArtistArtwork>, IArtistArtworkRepository
    {
        public ArtistArtworkRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<PageList<ArtistArtworkListDto>> ListArtistArtworkPgAsyncRm(PaginationInput paginationInput)
        {
            return await PageList<ArtistArtworkListDto>
                .ToPageList(JustRawQuery(p => !p.IsDeleted)
                    .OrderByDescending(p => p.CDate)
                    .Select(p => new ArtistArtworkListDto
                    {
                        ArtistName = p.ArtistFk.Name,
                        ArtistSurname = p.ArtistFk.Surname,
                        ArtistBiography = p.ArtistFk.Biography,
                        ArtistBorn = $"{p.ArtistFk.Born:ddd, MMM d, yyyy}",
                        ArtistDied = $"{p.ArtistFk.Died:ddd, MMM d, yyyy}",
                        ArtistNationality = p.ArtistFk.Nationality,
                        ArtworkName = p.ArtworkFk.Name,
                        ArtworkDescription = p.ArtworkFk.Description,
                        ArtworkLocation = p.ArtworkFk.Location,
                        ArtworkCompletionDate = $"{p.ArtworkFk.CompletionDate:ddd, MMM d, yyyy}"
                    }), paginationInput.PageNumber, paginationInput.PageSize);
        }
    }
}