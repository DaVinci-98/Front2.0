using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace Front.Core.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        #region Init

        private readonly IMvxNavigationService _navigation;

        public RegistrationViewModel(IMvxNavigationService navigation)
        {
            _navigation = navigation;

            CloseThisPageAsyncCommand = new MvxAsyncCommand(async () => await _navigation.Close(this));
        }

        #endregion

        #region Commands

        public IMvxAsyncCommand CloseThisPageAsyncCommand { get; private set; }

        #endregion
    }
}
