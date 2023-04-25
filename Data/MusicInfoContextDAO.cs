using Final_Project_3045.Interfaces;
using Final_Project_3045.Model;

namespace Final_Project_3045.Data
{
    public class MusicInfoContextDAO : IMusicInfoContextDAO
    {
        private MusicInfoContext _context;
        public MusicInfoContextDAO(MusicInfoContext context)
        {
            _context = context;
        }

        public int? Add(MusicInfo music)
        {
            var musics = _context.Musics.Where(x => x.Artist.Equals(music.Name)).FirstOrDefault();

            if (music == null)
                return null;

            try
            {
                _context.Musics.Add(music);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<MusicInfo> GetAllMusic()
        {
            return _context.Musics.ToList();
        }

        public MusicInfo GetMusicById(int id)
        {
            return _context.Musics.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public int? RemoveMusicById(int id)
        {
            var music = this.GetMusicById(id);
            if (music == null) return null;
            try
            {
                _context.Musics.Remove(music);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int? UpdateMusic(MusicInfo music)
        {
            var musicToUpdate = this.GetMusicById(music.Id);

            if (musicToUpdate == null)
                return null;

            musicToUpdate.Id = music.Id;
            musicToUpdate.Name = music.Name;
            musicToUpdate.Artist = music.Artist;
            musicToUpdate.Genre  = music.Genre;
            musicToUpdate.Instrument = music.Instrument;
            musicToUpdate.Song = music.Song;

            try
            {
                _context.Musics.Update(musicToUpdate);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
