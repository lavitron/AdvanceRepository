using Core.Entity;

namespace Arts.Entity.Entity.Art
{
    public class ArtistArtwork : BaseEntity
    {
        public virtual Artwork ArtworkFk { get; set; }
        public int ArtworkId { get; set; }
        public virtual Artist ArtistFk { get; set; }
        public int ArtistId { get; set; }

    }
}