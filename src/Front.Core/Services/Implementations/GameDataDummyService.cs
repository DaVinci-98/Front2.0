using System.Collections.Generic;
using Front.Core.Models;
using Front.Core.Services.Interfaces;

namespace Front.Core.Services.Implementations
{
    public class GameDataDummyService : IGameDataService
    {
        private GameModel _test;
        public GameDataDummyService()
        {
            _test = new GameModel
            {
                Beacons = new List<BeaconModel>(), 
                GameId = "12345", 
                Name = "Test",
                Map = "somemap.jpg"
            };
        }

        public GameModel GetGame(GameModel gameModel)
        {
            if (gameModel.GameId == _test.GameId) return _test;
            else return null;
        }
    }
}
