using Final_Project_3045.Model;

namespace Final_Project_3045.Interfaces
{
    public interface IMusicInfoContextDAO
    {
        List<MusicInfo> GetAllMusic();
        MusicInfo GetMusicById(int musicId);
        int? RemoveMusicById(int id);
        int? UpdateMusic(MusicInfo music);
        int? Add(MusicInfo music);

    }
}
