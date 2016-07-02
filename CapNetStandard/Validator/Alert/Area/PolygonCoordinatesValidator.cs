using System.Collections.Generic;
using System.Linq;
using CAPNet.Models;

namespace CAPNet
{
    /// <summary>
    ///  The geographic polygon is represented by a whitespace-delimited list of [WGS 84] coordinate pairs.
    /// </summary>
    public class PolygonCoordinatesValidator : Validator<Polygon>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="polygon"></param>
        public PolygonCoordinatesValidator(Polygon polygon)
            : base(polygon) { }

        /// <summary>
        ///
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                var wgs84Validators = from coordinate in Entity.Coordinates
                                      select new WGS84Validator(coordinate);

                return from wgs84Validator in wgs84Validators
                       from errors in wgs84Validator.Errors
                       select errors;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return !Errors.Any();
            }
        }
    }
}
