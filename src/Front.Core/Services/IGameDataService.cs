using Front.Core.Models;

namespace Front.Core.Services
{
    public interface IGameDataService
    {
        GameModel GetGame(GameModel gameModel);
    }
}
