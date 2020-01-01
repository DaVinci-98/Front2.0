using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using Front.Core.Models;

namespace Front.Core.Services
{
    public interface IGameCacheService
    {
        GameModel CachedGame { get; }
        void SaveGame(ref GameModel storage, GameModel value);
    }
}
