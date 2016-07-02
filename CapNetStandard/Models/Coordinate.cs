using System;
using System.Globalization;

namespace CAPNet.Models
{
    /// <summary>
    ///  [WGS 84] coordinate pair
    /// </summary>
    public sealed class Coordinate
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="stringRepresentation"></param>
        public Coordinate(string stringRepresentation)
        {
            if (stringRepresentation == null)
            {
                throw new ArgumentNullException(nameof(stringRepresentation));
            }

            var splitCoordinate = stringRepresentation.Split(',');
            Latitude = decimal.Parse(splitCoordinate[0], CultureInfo.InvariantCulture);
            Longitude = decimal.Parse(splitCoordinate[1], CultureInfo.InvariantCulture);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public Coordinate(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// The latitude part of this coordinate, in WGS 84.
        /// </summary>
        public decimal Latitude { get; }

        /// <summary>
        /// The longitude part of this coordinate, in WGS 84.
        /// </summary>
        public decimal Longitude { get; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0},{1}",
                Latitude,
                Longitude);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (Coordinate)obj;
            return Latitude == other.Latitude && Longitude == other.Longitude;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Latitude.GetHashCode() ^ Longitude.GetHashCode();
        }
    }
}
