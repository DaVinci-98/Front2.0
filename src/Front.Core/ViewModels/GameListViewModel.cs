using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Front.Core.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using Xamarin.Forms;

namespace Front.Core.ViewModels
{
    class GameListViewModel : BaseViewModel
    {
        #region Init

        private readonly IMvxNavigationService _navigation;

        public GameListViewModel(IMvxNavigationService navigation)
        {
            _navigation = navigation;
        }

        #endregion

        #region Commands

        public IMvxAsyncCommand ShowGamePageAsyncCommand { get; private set; }

        private async Task ShowGamePageAsync()
        {
            await _navigation.Navigate<GameViewModel, GameModel>(SelectedGame);


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

        private ObservableCollection<GameModel> _gameList;
        public ObservableCollection<GameModel> GameList
        {
            get => _gameList;
            set => SetProperty(ref _gameList, value);
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
