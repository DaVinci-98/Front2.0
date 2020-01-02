using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Front.Core.Models;
using Front.Core.Services.Interfaces;
using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace Front.Core.ViewModels
{
    public class RegistrationViewModel : BaseViewModelResult<PersonModel>
    {
        #region Init

        private readonly IMvxNavigationService _navigation;
        private readonly IPersonDataService _personData;
        private readonly IUserCacheService _cache;

        public RegistrationViewModel(IMvxNavigationService navigation, IPersonDataService personData, IUserCacheService cache)
        {
            _navigation = navigation;
            _personData = personData;
            _cache = cache;

            SaveAndLoginAsyncCommand = new MvxAsyncCommand(SaveAndLoginAsync, () => CanRegister);
        }

        public override Task Initialize()
        {
            CheckPersonData();
            return base.Initialize();
        }

        #endregion

        #region Commands

        public IMvxAsyncCommand SaveAndLoginAsyncCommand { get; private set; }
        private async Task SaveAndLoginAsync()
        {
            var person = PreparePersonModel();

            _personData.RegisterPerson(person);
            _cache.SaveUser(person);
            await _navigation.Close(this, person);
        }

        #endregion

        #region Properties

        private bool _canRegister;
        public bool CanRegister
        {
            get => _canRegister;
            set => SetCanExecuteProperty(SaveAndLoginAsyncCommand, ref _canRegister, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetPersonDataProperty(ref _email, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetPersonDataProperty(ref _password, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetPersonDataProperty(ref _name, value);
        }

        private string _nick;
        public string Nick
        {
            get => _nick;
            set => SetPersonDataProperty(ref _nick, value);
        }

        #endregion

        #region PrivateMethods

        private void SetCanExecuteProperty(IMvxAsyncCommand command, ref bool storage, bool value)
        {
            storage = value;
            command.RaiseCanExecuteChanged();
        }

        private void SetPersonDataProperty(ref string storage, string value)
        {
            SetProperty(ref storage, value);
            CheckPersonData();
        }

        private void CheckPersonData()
        {
            if (string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Password) ||
                string.IsNullOrWhiteSpace(Name) ||
                string.IsNullOrWhiteSpace(Nick))
            {
                CanRegister = false;
            }
            else
            {
                CanRegister = _personData.CanRegister(new PersonModel() { Email = this.Email });
            }
        }

        private PersonModel PreparePersonModel()
        {
            var person = new PersonModel()
            {
                Name = this.Name,
                Email = this.Email,
                Nick = this.Nick,
                Password = this.Password
            };
            return person;
        }

        #endregion
    }
}
