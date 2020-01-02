using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Front.Core.Models;
using Front.Core.Services;
using Front.Core.Services.Interfaces;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace Front.Core.ViewModels
{
    public class GameViewModel : BaseViewModel<GameModel>
    {
        #region init

        private GameModel _game;
        private readonly IMvxNavigationService _navigation;
        private readonly IUserCacheService _cache;

        public GameViewModel(IMvxNavigationService navigation, IUserCacheService cache)
        {
            _navigation = navigation;
            _cache = cache;

            Game = _cache.CachedGame;

            EndCurrentGameAsyncCommand = new MvxAsyncCommand(EndCurrentGameAsync);
        }

        public override void Prepare(GameModel game)
        {
            _cache.SaveGame(ref _game, game);
        }

        #endregion

        #region Commands

        public IMvxAsyncCommand EndCurrentGameAsyncCommand { get; private set; }

        private async Task EndCurrentGameAsync()
        {
            _cache.SaveGame(ref _game, null);
            await _navigation.Close(this);
            await _navigation.Navigate<AccountViewModel>();
        }

        #endregion

        #region Properties

        public GameModel Game
        {
            get => _game;
            set => SetProperty(ref _game, value);
        }

        #endregion
    }
}
