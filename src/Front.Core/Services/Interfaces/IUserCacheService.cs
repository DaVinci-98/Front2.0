using Front.Core.Models;

namespace Front.Core.Services.Interfaces
{
    public interface IUserCacheService
    {
        GameModel CachedGame { get; }
        PersonModel CachedUser { get; }

        void SaveGame(ref GameModel storage, GameModel value);
        void SaveUser(ref PersonModel storage, PersonModel value);
        void SaveUser(PersonModel value);
    }
}
