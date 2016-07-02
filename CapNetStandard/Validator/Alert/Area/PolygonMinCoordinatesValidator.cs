using CAPNet.Models;
using System.Collections.Generic;
using System.Linq;

namespace CAPNet
{
    /// <summary>
    /// A minimum of 4 coordinate pairs MUST be prese
    /// </summary>
    public class PolygonMinCoordinatesValidator : Validator<Polygon>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="polygon"></param>
        public PolygonMinCoordinatesValidator(Polygon polygon)
            : base(polygon) { }

        /// <summary>
        /// A polygon that has 4 coordinate pairs is valid
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return Entity.Coordinates.Count() >= 4;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new PolygonMinCoordinatesError();
            }
        }
    }
}
