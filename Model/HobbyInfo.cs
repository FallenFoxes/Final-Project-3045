using System.ComponentModel.DataAnnotations;

namespace Final_Project_3045.Model

{
    public class HobbyInfo
    {
        public int Id { get; set; }
        public string? Outside { get; set; }
        public string? Indoor { get; set; }
        public string? Travel { get; set; }
        public string? Night { get; set; }
        public string? Weekend { get; set; }
    }
}
