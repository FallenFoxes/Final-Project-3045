using Final_Project_3045.Interfaces;
using Final_Project_3045.Model;

namespace Final_Project_3045.Data
{
    public class GameInfoContextDAO : IGameInfoContextDAO
    {
        private GameInfoContext _context;
        public GameInfoContextDAO(GameInfoContext context)
        {
            _context = context;
        }

        public int? Add(GameInfo game)
        {
            var games = _context.Games.Where(x => x.Game.Equals(game.Game)).FirstOrDefault();

            if (games == null)
                return null;

            try
            {
                _context.Games.Add(games);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<GameInfo> GetAllGames()
        {
            return _context.Games.ToList();
        }

        public GameInfo GetGameById(int id)
        {
            return _context.Games.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public int? RemoveGameById(int id)
        {
            var game = this.GetGameById(id);
            if (game == null) return null;
            try
            {
                _context.Games.Remove(game);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int? UpdateGame(GameInfo game)
        {
            var gameToUpdate = this.GetGameById(game.Id);

            if (gameToUpdate == null)
                return null;

            gameToUpdate.Game = game.Game;
            gameToUpdate.Id = game.Id;
            gameToUpdate.Company = game.Company;
            gameToUpdate.Streamer = game.Streamer;
            gameToUpdate.Character = game.Character;
            gameToUpdate.Platform = game.Platform; 

            try
            {
                _context.Games.Update(gameToUpdate);
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
