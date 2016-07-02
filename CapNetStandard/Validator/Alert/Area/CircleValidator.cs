using System.Collections.Generic;
using System.Linq;
using CAPNet.Models;

namespace CAPNet
{
    /// <summary>
    /// The circular area is represented by a central point given as a [WGS 84] coordinate pair followed by a space character and a radius value in kilometers.
    /// </summary>
    public class CircleValidator : Validator<Circle>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="circle"></param>
        public CircleValidator(Circle circle)
            : base(circle)
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
                var wgs84Validator = new WGS84Validator(Entity.Center);
                return !wgs84Validator.Errors.Any();
            }
        }
    }
}
