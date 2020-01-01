using System;
using System.Collections.Generic;
using System.Text;
using Front.Core.Models;
using Front.Core.Services;
using MvvmCross.Navigation;

namespace Front.Core.ViewModels
{
    public class GameViewModel : BaseViewModel<GameModel>
    {
        #region init

        private GameModel _game;
        private readonly IMvxNavigationService _navigation;
        private readonly IGameCacheService _gameCache;

        public GameViewModel(IMvxNavigationService navigation, IGameCacheService gameCache)
        {
            _navigation = navigation;
            _gameCache = gameCache;

            Game = _gameCache.CachedGame;
        }

        public override void Prepare(GameModel game)
        {
            _gameCache.SaveGame(ref _game, game);
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
