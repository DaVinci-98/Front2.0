using System.Collections.Generic;

namespace Front.Core.Models
{
    public class PersonModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Nick { get; set; }
        public string Stats { get; set; }
        public bool IsGuest { get; set; }

        public LocationModel CurrentLocation { get; set; }
        public List<GameModel> AvailableGames { get; set; }
    }
}
