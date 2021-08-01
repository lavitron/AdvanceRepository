using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Arts.Business.Abstract;
using Arts.Entity.Dto.ArtistArtwork;
using Arts.Entity.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace Arts.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistArtworkController : ControllerBase
    {
        private readonly IArtistArtworkService _artistArtworkService;

        public ArtistArtworkController(IArtistArtworkService artistArtworkService)
        {
            _artistArtworkService = artistArtworkService;
        }

        [HttpPost]
        [Route("GetArtistArtworkList")]
        public async Task<ActionResult<IEnumerable<ArtistArtworkListDto>>> GetArtistArtworkListAsync(PaginationInput paginationInput)
        {
            try
            {
                if (_artistArtworkService == null) return Ok();
                var artistArtworkList = await _artistArtworkService.ListArtistArtworkPgAsync(paginationInput);
                var pageInformation = new
                {
                    artistArtworkList.TotalCount,
                    artistArtworkList.PageSize,
                    artistArtworkList.CurrentPage,
                    artistArtworkList.HasNextPage,
                    artistArtworkList.HasPreviousPage,
                    artistArtworkList.TotalPage
                };

                return Ok(new { artistArtworkList, pageInformations = pageInformation });

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}