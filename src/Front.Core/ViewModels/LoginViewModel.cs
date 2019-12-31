using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace Front.Core.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        #region Init

        private readonly IMvxNavigationService _navigation;

        public LoginViewModel(IMvxNavigationService navigation)
        {
            _navigation = navigation;

            ShowRegistrationPageAsyncCommand = new MvxAsyncCommand(async () => await _navigation.Navigate<RegistrationViewModel>());
        }

        #endregion

        #region Commands

        public IMvxAsyncCommand ShowRegistrationPageAsyncCommand { get; private set; }

        #endregion
    }
}
