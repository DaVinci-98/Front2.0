using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Front.Core.Models;

namespace Front.Core.ViewModels
{
    class SettingsViewModel : BaseViewModel
    {
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
