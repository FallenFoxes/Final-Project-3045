using System.ComponentModel.DataAnnotations;

namespace Final_Project_3045.models

{
    public class HobbyRequest
    {
        [Key]

        public string FavoriteOutsideHobby { get; set; }

        public string FavoriteIndoorHobby { get; set; }

        public string FavoriteTravelHobby { get; set; }

        public string FavoriteNightHobby { get; set; }

        public string FavoriteWeekendHobby { get; set; }
    }
}
