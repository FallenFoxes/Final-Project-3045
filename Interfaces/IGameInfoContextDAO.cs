using Final_Project_3045.Model;

namespace Final_Project_3045.Interfaces
{
    public interface IGameInfoContextDAO
    {
        List<GameInfo> GetAllGames();
        GameInfo GetGameById(int gameId);
        int? RemoveGameById(int id);
        int? UpdateGame(GameInfo game);
        int? Add(GameInfo game);

    }
}
