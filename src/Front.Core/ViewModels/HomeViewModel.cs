using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace Front.Core.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region Init

        private readonly IMvxNavigationService _navigation;

        public HomeViewModel(IMvxNavigationService navigation)
        {
            _navigation = navigation;

            ShowLoginPageAsyncCommand = new MvxAsyncCommand(async () => await _navigation.Navigate<LoginViewModel>());
            ShowAboutUsPageAsyncCommand = new MvxAsyncCommand(async () => await _navigation.Navigate<AboutUsViewModel>());
            ShowSettingsPageAsyncCommand = new MvxAsyncCommand(async () => await _navigation.Navigate<SettingsViewModel>());
        }

        #endregion

        #region Commands

        public IMvxAsyncCommand ShowLoginPageAsyncCommand { get; private set; }

        //Quitting from app is not recommended
        //public IMvxAsyncCommand Quit { get; private set; }

        public IMvxAsyncCommand ShowAboutUsPageAsyncCommand { get; private set; }

        public IMvxAsyncCommand ShowSettingsPageAsyncCommand { get; private set; }

        #endregion
    }
}
