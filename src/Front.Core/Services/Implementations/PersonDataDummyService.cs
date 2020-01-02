using System.Collections.Generic;
using Front.Core.Models;
using Front.Core.Services.Interfaces;

namespace Front.Core.Services.Implementations
{
    public class PersonDataDummyService : IPersonDataService
    {
        private Dictionary<string,PersonModel> _test;
        public PersonDataDummyService()
        {
            _test = new Dictionary<string,PersonModel>();

            var email = "what@ever.whocares";
            _test.Add(email, new PersonModel() 
            {
                CurrentLocation = new LocationModel(),
                Email = email,
                Name = "Bob",
                Nick = "bboobb",
                Password = "strongpassword",
                Stats = "You suck",
                IsGuest = false,
                AvailableGames = new List<GameModel>()
            });


        }
        public PersonModel GetPerson(PersonModel person)
        {
            if (!_test.ContainsKey(person.Email)) return null;
            if (_test[person.Email].Password == person.Password) return _test[person.Email];
            else return null;
        }

        public void RegisterPerson(PersonModel person)
        {
            _test.Add(person.Email, person);
        }

        public bool CanRegister(PersonModel person)
        {
            return !_test.ContainsKey(person.Email);
        }

    }
}
