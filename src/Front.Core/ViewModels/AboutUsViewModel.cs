using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace Front.Core.ViewModels
{
    public class AboutUsViewModel : BaseViewModel
    {
        #region Init

        private readonly IMvxNavigationService _navigation;

        public AboutUsViewModel(IMvxNavigationService navigation)
        {
            _navigation = navigation;
        }

        #endregion
    }
}
