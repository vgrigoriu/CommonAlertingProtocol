using System.Collections.Generic;
using CAPNet.Models;

namespace CAPNet
{
    /// <summary>
    /// Verifies if a set of coordinates respect the WGS 84 standard !
    /// </summary>
    public class WGS84Validator : Validator<Coordinate>
    {
        private const int MinLongitude = -180;
        private const int MaxLongitude = 180;
        private const int MinLatitude = -90;
        private const int MaxLatitude = 90;

        /// <summary>
        ///
        /// </summary>
        /// <param name="coordinate"></param>
        public WGS84Validator(Coordinate coordinate)
            : base(coordinate)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                {
                    yield return new WGS84Error();
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override bool IsValid
        {
            get
            {
                var longitudeIsValid = MinLongitude <= Entity.Longitude && Entity.Longitude <= MaxLongitude;
                var latitudeIsValid = MinLatitude <= Entity.Latitude && Entity.Latitude <= MaxLatitude;

                return longitudeIsValid && latitudeIsValid;
            }
        }
    }
}
