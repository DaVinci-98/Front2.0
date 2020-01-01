using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Navigation;

namespace Front.Core.ViewModels
{
    public class NotificationsViewModel : BaseViewModel
    {
        #region Init

        private readonly IMvxNavigationService _navigation;

        public NotificationsViewModel(IMvxNavigationService navigation)
        {
            _navigation = navigation;
        }

        #endregion
    }
}
