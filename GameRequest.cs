using System.ComponentModel.DataAnnotations;

namespace Final_Project_3045.models

{
    public class GameRequest
    {
        [Key]

        public string FavoriteGame { get; set; }
        public string FavoriteCompany { get; set; }
        public string FavoritePlatform { get; set; }
        public string FavoriteStreamer { get; set; }

        public string FavoriteCharacter { get; set; }

    }
}
