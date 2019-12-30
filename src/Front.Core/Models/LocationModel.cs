using System;

namespace Front.Core.Models
{
    public class LocationModel : IEquatable<LocationModel>
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Altitude { get; set; }

        //Automatically generated POG
        //Models shouldn't have too much logic, but some comparison should be ok
        public bool Equals(LocationModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Longitude.Equals(other.Longitude) && Latitude.Equals(other.Latitude) && Altitude.Equals(other.Altitude);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((LocationModel) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Longitude.GetHashCode();
                hashCode = (hashCode * 397) ^ Latitude.GetHashCode();
                hashCode = (hashCode * 397) ^ Altitude.GetHashCode();
                return hashCode;
            }
        }
    }
}
