using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Front.Core.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Front.Core.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        #region Init

        private readonly IMvxNavigationService _navigationService;

        public SettingsViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        #endregion

        #region Properties

        private ObservableCollection<string> _settingsList;
        public ObservableCollection<string> SettingsList
        {
            get => _settingsList;
            set => SetProperty(ref _settingsList, value);
        }


        private GameModel _selectedSetting;
        public GameModel SelectedSetting
        {
            get => _selectedSetting;
            set => SetProperty(ref _selectedSetting, value);
        }

        #endregion
    }
}
