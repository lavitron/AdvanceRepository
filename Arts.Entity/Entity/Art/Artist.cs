using System;
using System.Collections.Generic;
using Core.Entity;

namespace Arts.Entity.Entity.Art
{
    public class Artist : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nationality { get; set; }
        public DateTime? Born { get; set; }
        public DateTime? Died { get; set; }
        public string Biography { get; set; }

        public virtual ICollection<ArtistArtwork> ArtistArtworks { get; set; }
    }
}