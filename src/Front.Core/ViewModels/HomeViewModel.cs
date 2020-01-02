using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Front.Core.Models;
using Front.Core.Services.Interfaces;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace Front.Core.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region Init

        private readonly IMvxNavigationService _navigation;
        private readonly IUserCacheService _cache;

        public HomeViewModel(IMvxNavigationService navigation, IUserCacheService cache)
        {
            _navigation = navigation;
            _cache = cache;

            LogInAsyncCommand = new MvxAsyncCommand(LogInAsync, () => CanLogIn);
            ShowAboutUsPageAsyncCommand = new MvxAsyncCommand(async () => await _navigation.Navigate<AboutUsViewModel>());
            ShowSettingsPageAsyncCommand = new MvxAsyncCommand(async () => await _navigation.Navigate<SettingsViewModel>());
        }

        public override Task Initialize()
        {
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
                CanLogIn = false;
            }
        }
        public IMvxAsyncCommand ShowAboutUsPageAsyncCommand { get; private set; }

        public IMvxAsyncCommand ShowSettingsPageAsyncCommand { get; private set; }

        #endregion


        #region Properties


        private bool _canLogIn;
        public bool CanLogIn
        {
            get => _canLogIn;
            set => SetCanExecuteProperty(LogInAsyncCommand, ref _canLogIn, value);
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
