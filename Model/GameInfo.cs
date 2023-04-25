using System.ComponentModel.DataAnnotations;

namespace Final_Project_3045.Model

{
    public class GameInfo
    {
        public int Id { get; set; }
        public string? Game { get; set; }
        public string? Company { get; set; }
        public string? Platform { get; set; }
        public string? Streamer { get; set; }
        public string? Character { get; set; }

    }
}
