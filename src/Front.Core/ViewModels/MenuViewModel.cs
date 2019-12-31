using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
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

        public MenuViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            MenuItemList = new MvxObservableCollection<string>()
            {
                "Game",
                "Account",
                "Settings"
            };

            ShowDetailPageAsyncCommand = new MvxAsyncCommand(ShowDetailPageAsync);
        }

        #endregion

        #region Commands

        public IMvxAsyncCommand ShowDetailPageAsyncCommand { get; private set; }

        private async Task ShowDetailPageAsync()
        {
            // Implement your logic here.
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
    }
}
