using System.ComponentModel.DataAnnotations;

namespace Final_Project_3045.Model
{
    public class MusicInfo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Artist { get; set; }
        public string? Song { get; set; }
        public string? Genre { get; set; }
        public string? Instrument { get; set; }
    }
}
