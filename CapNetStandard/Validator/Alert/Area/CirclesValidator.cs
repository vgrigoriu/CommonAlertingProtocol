using CAPNet.Models;
using System.Collections.Generic;
using System.Linq;

namespace CAPNet
{
    /// <summary>
    /// Validator of the multiple instances that MAY occur within an area block.
    /// </summary>
    public class CirclesValidator : Validator<Area>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="area"></param>
        public CirclesValidator(Area area) : base(area) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                var circlesValidators = from circle in Entity.Circles
                                        select new CircleValidator(circle);

                return from circleValidator in circlesValidators
                       from error in circleValidator.Errors
                       select error;
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
