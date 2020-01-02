using System;
using System.Collections.Generic;
using System.Text;
using Front.Core.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace Front.Core.ViewModels
{
    public class StatsViewModel : BaseViewModel<PersonModel>
    {
        #region Init

        private readonly IMvxNavigationService _navigation;

        public StatsViewModel(IMvxNavigationService navigation)
        {
            _navigation = navigation;

            ResetStatsCommand = new MvxCommand(ResetStats);
        }

        public override void Prepare(PersonModel parameter)
        {
            Person = parameter;
        }

        #endregion

        #region Commands

        public IMvxCommand ResetStatsCommand { get; private set; }

        private void ResetStats()
        {
            _person.Stats = "You still suck, but we don't know about it.";
            RaisePropertyChanged(() => Person);
        }

        #endregion

        #region Properties

        private PersonModel _person;

        public PersonModel Person
        {
            get => _person;
            set => SetProperty(ref _person, value);
        }

        #endregion
    }
}
