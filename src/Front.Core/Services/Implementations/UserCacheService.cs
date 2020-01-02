using System.Collections.Generic;
using Front.Core.Models;
using Front.Core.Services.Interfaces;

namespace Front.Core.Services.Implementations
{
    public class UserCacheService : IUserCacheService

    {
        public UserCacheService()
        {
            CachedUser = new PersonModel()
            {
                IsGuest = true,
                Nick = "Guest",
                AvailableGames = new List<GameModel>()
            };
        }
        public GameModel CachedGame { get; private set; }
        public PersonModel CachedUser { get; private set; }

        public void SaveGame(ref GameModel storage, GameModel value)
        {
            storage = value;
            CachedGame = value;
        }

        public void SaveUser(PersonModel value)
        {
            CachedUser = value;
        }
        public void SaveUser(ref PersonModel storage, PersonModel value)
        {
            storage = value;
            CachedUser = value;
        }
    }
}
