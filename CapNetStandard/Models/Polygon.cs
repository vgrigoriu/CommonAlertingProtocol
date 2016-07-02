using System;
using System.Collections.Generic;
using System.Linq;

namespace CAPNet.Models
{
    /// <summary>
    /// The paired values of points defining a polygon that delineates the affected area of the alert message
    /// </summary>
    public class Polygon
    {
        private readonly List<Coordinate> coordinates;

        /// <summary>
        /// list of [WGS 84] coordinate pairs
        /// </summary>
        public IEnumerable<Coordinate> Coordinates => coordinates;


        /// <summary>
        ///
        /// </summary>
        /// <param name="stringRepresentation">The geographic polygon is represented by a whitespace-delimited list of [WGS 84] coordinate pairs</param>
        public Polygon(string stringRepresentation)
        {
            if (stringRepresentation == null) { throw new ArgumentNullException(nameof(stringRepresentation)); }
            var stringCoordinates = stringRepresentation.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            coordinates = (from coordinate in stringCoordinates
                           select new Coordinate(coordinate))
                          .ToList();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns>whitespace-delimited list of [WGS 84] coordinate pairs</returns>
        public override string ToString()
        {
            return string.Join(" ", coordinates);
        }
    }
}
