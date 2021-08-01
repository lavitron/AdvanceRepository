namespace Arts.Entity.Dto.ArtistArtwork
{
    public class ArtistArtworkListDto
    {
        public string ArtistName { get; set; }
        public string ArtistSurname { get; set; }
        public string ArtistNationality { get; set; }
        public string ArtistBorn { get; set; }
        public string ArtistDied { get; set; }
        public string ArtistBiography { get; set; }

        public string ArtworkName { get; set; }
        public string ArtworkLocation { get; set; }
        public string ArtworkCompletionDate { get; set; }
        public string ArtworkDescription { get; set; }
    }
}