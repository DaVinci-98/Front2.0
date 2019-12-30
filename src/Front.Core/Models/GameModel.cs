using System.Collections.Generic;

namespace Front.Core.Models
{
    public class GameModel
    {
        public string Name { get; set; }
        public string GameId { get; set; }
        public List<BeaconModel> Beacons { get; set; }
        public string Map { get; set; }
    }
}
