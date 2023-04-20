using System.ComponentModel.DataAnnotations;

namespace Final_Project_3045.models
{
    public class MusicRequest
    {
        [Key]

        public string FirstName { get; set; }
        public string FavoriteArtist { get; set; }

        public string FavoriteSong { get; set; }
        public string FavoriteGenre { get; set; }
        public string FavoriteInstrument { get; set; }
    }
}
