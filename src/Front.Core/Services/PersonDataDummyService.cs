using System.Collections.Generic;
using Front.Core.Models;

namespace Front.Core.Services
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
                AvailableGames = new List<GameModel>()
            });


        }
        public PersonModel GetPerson(string email, string password)
        {
            if (_test[email].Password == password) return _test[email];
            else return null;
        }

        public bool RegisterPerson(string nick, string name, string email, string password)
        {
            if (_test.ContainsKey(email)) return false;
            else
            {
                _test.Add(email, new PersonModel()
                {
                    Nick = nick,
                    Email = email,
                    Name = name,
                    Password = password
                });
                return true;
            }
        }
    }
}
