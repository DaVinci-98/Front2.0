using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Front.Core.Models;
using Front.Core.Services.Interfaces;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace Front.Core.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        #region Init

        private readonly IMvxNavigationService _navigation;
        private readonly IUserCacheService _cache;

        public AccountViewModel(IMvxNavigationService navigation, IUserCacheService cache)
        {
            _navigation = navigation;
            _cache = cache;

            LogInAsyncCommand = new MvxAsyncCommand(LogInAsync, () => CanLogIn);

            ShowStatsPageAsyncCommand = new MvxAsyncCommand(ShowStatsPageAsync, () => CanSeeStats);
            ShowGameListPageAsyncCommand = new MvxAsyncCommand(async () => await _navigation.Navigate<GameListViewModel>());
            ShowNotificationsPageAsyncCommand = new MvxAsyncCommand(async () => await _navigation.Navigate<NotificationsViewModel>());
        }

        public override Task Initialize()
        {
            CanSeeStats = !_cache.CachedUser.IsGuest;
            CanLogIn = _cache.CachedUser.IsGuest;
            return base.Initialize();
        }

        #endregion

        #region Commands

        public IMvxAsyncCommand LogInAsyncCommand { get; private set; }
        private async Task LogInAsync()
        {
            var person = await _navigation.Navigate<LoginViewModel, PersonModel>();

            if (person != null)
            {
                CanSeeStats = true;
                CanLogIn = false;
            }
        }

        public IMvxAsyncCommand ShowStatsPageAsyncCommand { get; private set; }
        private async Task ShowStatsPageAsync()
        {
            await _navigation.Navigate<StatsViewModel, PersonModel>(_cache.CachedUser);
        }

        public IMvxAsyncCommand ShowGameListPageAsyncCommand { get; private set; }

        public IMvxAsyncCommand ShowNotificationsPageAsyncCommand { get; private set; }

        #endregion

        #region Properties

        private bool _canSeeStats;
        public bool CanSeeStats
        {
            get => _canSeeStats;
            set => SetCanExecuteProperty(LogInAsyncCommand,ref _canSeeStats, value);
        }

        private bool _canLogIn;
        public bool CanLogIn
        {
            get => _canLogIn;
            set => SetCanExecuteProperty(ShowStatsPageAsyncCommand,ref _canLogIn, value);
        }

        #endregion

        #region PrivateMethods

        private void SetCanExecuteProperty(IMvxAsyncCommand command, ref bool storage, bool value)
        {
            storage = value;
            command.RaiseCanExecuteChanged();
        }

        #endregion
    }
}
