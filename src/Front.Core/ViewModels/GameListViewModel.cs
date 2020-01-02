using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Front.Core.Models;
using Front.Core.Services;
using Front.Core.Services.Interfaces;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using Xamarin.Forms;

namespace Front.Core.ViewModels
{
    public class GameListViewModel : BaseViewModel
    {
        #region Init

        private readonly IMvxNavigationService _navigation;
        private readonly IGameDataService _gameData;
        private readonly IUserCacheService _cache;

        public GameListViewModel(IMvxNavigationService navigation, IGameDataService gameData, IUserCacheService cahche)
        {
            _navigation = navigation;
            _gameData = gameData;
            _cache = cahche;

            GamesList = new ObservableCollection<GameModel>(_cache.CachedUser.AvailableGames);

            ShowGamePageAsyncCommand = new MvxAsyncCommand(async () => await _navigation.Navigate<GameViewModel, GameModel>(SelectedGame));
            AddGameCommand = new MvxCommand(AddGame,() => CanAddGame);
        }

        #endregion

        #region Commands

        public IMvxAsyncCommand ShowGamePageAsyncCommand { get; private set; }

        public IMvxCommand AddGameCommand { get; private set; }
        private void AddGame()
        {
            var game = new GameModel()
            {
                GameId = this.GameId
            };
            game = _gameData.GetGame(game);

            if (game != null)
            {
                foreach (var item in GamesList)
                {
                    if(item.GameId == game.GameId) return;
                }
                GamesList.Add(game);
                _cache.CachedUser.AvailableGames.Add(game);
            }
        }

        #endregion

        #region Properties

        private bool _canAddGame;
        public bool CanAddGame
        {
            get => _canAddGame;
            set => SetCanExecuteProperty(AddGameCommand,ref _canAddGame, value);
        }

        private string _gameId;
        public string GameId
        {
            get => _gameId;
            set
            {
                CanAddGame = !string.IsNullOrWhiteSpace(value);
                SetProperty(ref _gameId, value);
            }
        }

        private ObservableCollection<GameModel> _gamesList;
        public ObservableCollection<GameModel> GamesList
        {
            get => _gamesList;
            set => SetProperty(ref _gamesList, value);
        }


        private GameModel _selectedGame;
        public GameModel SelectedGame
        {
            get => _selectedGame;
            set => SetProperty(ref _selectedGame, value);
        }

        #endregion

        #region PrivateMethods

        private void SetCanExecuteProperty(IMvxCommand command, ref bool storage, bool value)
        {
            storage = value;
            command.RaiseCanExecuteChanged();
        }

        #endregion
    }
}
