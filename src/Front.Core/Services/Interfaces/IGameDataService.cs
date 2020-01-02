using Front.Core.Models;

namespace Front.Core.Services.Interfaces
{
    public interface IGameDataService
    {
        GameModel GetGame(GameModel gameModel);
    }
}
