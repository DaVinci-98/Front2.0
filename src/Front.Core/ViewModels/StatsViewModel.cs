using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Navigation;

namespace Front.Core.ViewModels
{
    public class StatsViewModel : BaseViewModel
    {
        #region Init

        private readonly IMvxNavigationService _navigation;

        public StatsViewModel(IMvxNavigationService navigation)
        {
            _navigation = navigation;
        }

        #endregion
    }
}
