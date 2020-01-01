using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Navigation;

namespace Front.Core.ViewModels
{
    public class RootViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private bool _firstTime;

        public RootViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            _firstTime = true;
        }

        public override async void ViewAppearing()
        {
            base.ViewAppearing();

            if (_firstTime)
            {
                await _navigationService.Navigate<MenuViewModel>();
                await _navigationService.Navigate<HomeViewModel>();

                _firstTime = false;
            }
        }
    }
}
