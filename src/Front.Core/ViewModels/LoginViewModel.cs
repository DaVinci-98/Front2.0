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
    public class LoginViewModel : BaseViewModelResult<PersonModel>
    {
        #region Init

        private readonly IMvxNavigationService _navigation;
        private readonly IPersonDataService _personData;
        private readonly IUserCacheService _cache;

        public LoginViewModel(IMvxNavigationService navigation, IPersonDataService personData, IUserCacheService cache)
        {
            _navigation = navigation;
            _personData = personData;
            _cache = cache;

            RegisterPersonAsyncCommand = new MvxAsyncCommand(RegisterPersonAsync);
            LoginAsyncCommand = new MvxAsyncCommand(LoginAsync);
        }

        #endregion

        #region Commands

        public IMvxAsyncCommand RegisterPersonAsyncCommand { get; private set; }
        private async Task RegisterPersonAsync()
        {
            var person = await _navigation.Navigate<RegistrationViewModel, PersonModel>();
            if (person != null)
            {
                _cache.SaveUser(person);
                await _navigation.Close(this, person);
            }
        }

        public IMvxAsyncCommand LoginAsyncCommand { get; private set; }
        private async Task LoginAsync()
        {
            var person = new PersonModel()
            {
                Email = this.Email,
                Password = this.Password
            };
            person = _personData.GetPerson(person);
            if (person != null)
            {
                _cache.SaveUser(person);
                await _navigation.Close(this, person);
            }
        }

        #endregion

        #region Properties

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        #endregion
    }
}
