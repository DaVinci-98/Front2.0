using Front.Core.Models;

namespace Front.Core.Services
{
    public interface IGameData
    {
        GameModel GetGame(GameModel gameModel);
    }
}
