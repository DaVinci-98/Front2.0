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
using MvvmCross.ViewModels;
using Xamarin.Forms;

namespace Front.Core.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        #region Init

        private readonly IMvxNavigationService _navigationService;
        private readonly IUserCacheService _cache;

        public MenuViewModel(IMvxNavigationService navigationService, IUserCacheService cache)
        {
            _navigationService = navigationService;
            _cache = cache;

            MenuItemList = new MvxObservableCollection<string>()
            {
                "Account",
                "Settings"
            };

            if (Application.Current.MainPage is MasterDetailPage masterDetail)
            {
                masterDetail.IsPresentedChanged += RefreshCurrentGame;
            }

            ShowDetailPageAsyncCommand = new MvxAsyncCommand(ShowDetailPageAsync);
        }

        #endregion

        #region Commands

        public IMvxAsyncCommand ShowDetailPageAsyncCommand { get; private set; }

        private async Task ShowDetailPageAsync()
        {
            switch (SelectedMenuItem)
            {
                case "Game":
                    await _navigationService.Navigate<GameViewModel>();
                    break;
                case "Account":
                    await _navigationService.Navigate<AccountViewModel>();
                    break;
                case "Settings":
                    await _navigationService.Navigate<SettingsViewModel>();
                    break;
                default:
                    break;
            }

            SelectedMenuItem = null;

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

        private ObservableCollection<string> _menuItemList;
        public ObservableCollection<string> MenuItemList
        {
            get => _menuItemList;
            set => SetProperty(ref _menuItemList, value);
        }


        private string _selectedMenuItem;
        public string SelectedMenuItem
        {
            get => _selectedMenuItem;
            set => SetProperty(ref _selectedMenuItem, value);
        }

        #endregion

        #region PrivateMethods

        private void RefreshCurrentGame(object sender, EventArgs e)
        {
            if (_cache.CachedGame != null)
            {
                if (!MenuItemList.Contains("Game"))
                {
                    MenuItemList.Insert(0, "Game");
                }
            }
            else
            {
                if (MenuItemList.Contains("Game"))
                {
                    MenuItemList.Remove("Game");
                }
            }
        }

        #endregion
    }
}
