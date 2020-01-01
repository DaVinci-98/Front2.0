using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Front.Core.Models;
using Front.Core.Services;
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

        public GameListViewModel(IMvxNavigationService navigation, IGameDataService gameData)
        {
            _navigation = navigation;
            _gameData = gameData;

            ShowGamePageAsyncCommand = new MvxAsyncCommand(ShowGamePageAsync);

            GamesList = new ObservableCollection<GameModel>();
            GamesList.Add(_gameData.GetGame(new GameModel()
            {
                GameId = "12345"
            }));
        }

        #endregion

        #region Commands

        public IMvxAsyncCommand ShowGamePageAsyncCommand { get; private set; }

        private async Task ShowGamePageAsync()
        {
            await _navigation.Navigate<GameViewModel, GameModel>(SelectedGame);

            //SelectedGame = null;

            if (Application.Current.MainPage is MasterDetailPage masterDetailPage)
            {
                masterDetailPage.IsPresented = false;
            }
            else if (Application.Current.MainPage is NavigationPage navigationPage
                     && navigationPage.CurrentPage is MasterDetailPage nestedMasterDetail)
            {
                nestedMasterDetail.IsPresented = false;
            }
        }

        #endregion

        #region Properties

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
    }
}
