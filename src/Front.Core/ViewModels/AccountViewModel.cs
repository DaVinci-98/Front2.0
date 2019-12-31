using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace Front.Core.ViewModels
{
    class AccountViewModel : BaseViewModel
    {
        #region Init

        private readonly IMvxNavigationService _navigation;

        public AccountViewModel(IMvxNavigationService navigation)
        {
            _navigation = navigation;

            ShowStatsPageAsyncCommand = new MvxAsyncCommand(async () => await _navigation.Navigate<StatsViewModel>());
            ShowGameListPageAsyncCommand = new MvxAsyncCommand(async () => await _navigation.Navigate<GameListViewModel>());
            ShowNotificationsPageAsyncCommand = new MvxAsyncCommand(async () => await _navigation.Navigate<NotificationsViewModel>());
            ShowLoginPageAsyncCommand = new MvxAsyncCommand(async () => await _navigation.Navigate<LoginViewModel>());
        }

        #endregion

        #region Commands

        public IMvxAsyncCommand ShowStatsPageAsyncCommand { get; private set; }

        public IMvxAsyncCommand ShowGameListPageAsyncCommand { get; private set; }

        public IMvxAsyncCommand ShowNotificationsPageAsyncCommand { get; private set; }

        public IMvxAsyncCommand ShowLoginPageAsyncCommand { get; private set; }

        #endregion
    }
}
