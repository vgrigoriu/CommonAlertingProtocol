using CAPNet.Models;
using System.Collections.Generic;

namespace CAPNet
{
    /// <summary>
    /// Verifies if a set of coordinates respect the WGS 84 standard !
    /// </summary>
    public class WGS84Validator : Validator<Coordinate>
    {
        private const int minLongitude = -180;
        private const int maxLongitude = 180;
        private const int minLatitude = -90;
        private const int maxLatitude = 90;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordinate"></param>
        public WGS84Validator(Coordinate coordinate) : base(coordinate) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new WGS84Error();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                var longitudeIsValid = minLongitude <= Entity.Longitude && Entity.Longitude <= maxLongitude;
                var latitudeIsValid = minLatitude <= Entity.Latitude && Entity.Latitude <= maxLatitude;

                return longitudeIsValid && latitudeIsValid;
            }
        }
    }
}
