using System;
using System.Collections.Generic;
using System.Text;
using Front.Core.Models;

namespace Front.Core.Services
{
    class GameCacheService : IGameCacheService
    {
        private GameModel _cachedGame;

        public GameCacheService()
        {
            CachedGame = new GameModel()
            {
                Name = "placeholder"
            };
        }

        public GameModel CachedGame
        {
            get => _cachedGame;
            private set => _cachedGame = value;
        }
        public void SaveGame(ref GameModel storage, GameModel value)
        {
            storage = value;
            CachedGame = value;
        }
    }
}
