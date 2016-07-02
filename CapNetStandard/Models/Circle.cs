using System;
using System.Globalization;

namespace CAPNet.Models
{
    /// <summary>
    /// The paired values of a point and radius delineating the affected area of the alert message
    /// </summary>
    public class Circle
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="stringRepresentation">The circular area is represented by a central point
        ///  given as a [WGS 84] coordinate pair followed by a space character and a radius value
        ///  in kilometers.</param>
        public Circle(string stringRepresentation)
        {
            if (stringRepresentation == null)
            {
                throw new ArgumentNullException(nameof(stringRepresentation));
            }

            var circleCenterAndRadius = stringRepresentation.Split(' ');
            Center = new Coordinate(circleCenterAndRadius[0]);
            Radius = decimal.Parse(circleCenterAndRadius[1], CultureInfo.InvariantCulture);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        public Circle(Coordinate center, decimal radius)
        {
            Center = center;
            Radius = radius;
        }

        /// <summary>
        /// radius value in kilometers
        /// </summary>
        public decimal Radius { get; }

        /// <summary>
        /// [WGS 84] coordinate pair
        /// </summary>
        public Coordinate Center { get; }

        /// <summary>
        ///
        /// </summary>
        /// <returns>central point given as a [WGS 84] coordinate pair followed by a space character and a radius value in kilometers</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0} {1}", Center, Radius);
        }
    }
}
