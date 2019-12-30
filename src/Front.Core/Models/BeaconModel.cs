using System.Collections.Generic;

namespace Front.Core.Models
{
    public class BeaconModel
    {
        public string Name { get; set; }
        public LocationModel Location { get; set; }
        public List<string> Notes { get; set; }
        public bool Checked { get; set; }

        //There should be an interface for managing "gameplay", but It's way too much work for this
        public bool CheckBeacon(LocationModel location)
        {
            if (location == Location)
            {
                Checked = true;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
