namespace POC_WhySPA.Areas.Music.Models
{
    public class AlbumSummary
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ArtistSummary  Artist  { get; set; }

        public decimal Price { get; set; }

        public string Genre { get; set; }
    }
}