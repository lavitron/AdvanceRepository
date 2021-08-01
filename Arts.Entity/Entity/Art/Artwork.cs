using System;
using System.Collections.Generic;
using Core.Entity;

namespace Arts.Entity.Entity.Art
{
    public class Artwork : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ArtistArtwork> ArtistArtworks { get; set; }

    }
}