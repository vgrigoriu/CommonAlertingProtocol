using CAPNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CAPNet
{
    /// <summary>
    /// Validates component parts of the area sub-element of the info sub-element of the alert message
    /// </summary>
    public class AreaValidator : Validator<Info>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="info"></param>
        public AreaValidator(Info info)
            : base(info) { }

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

        /// <summary>
        ///
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                return from area in Entity.Areas
                       from error in GetErrors(area)
                       select error;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        private static IEnumerable<Error> GetErrors(Area area)
        {
            var areaValidators = from type in typeof(AreaValidator).GetTypeInfo().Assembly.DefinedTypes
                                 where typeof(IValidator<Area>).GetTypeInfo().IsAssignableFrom(type)
                                 select (IValidator<Area>)Activator.CreateInstance(type.AsType(), area);

            return from validator in areaValidators
                   from error in validator.Errors
                   select error;
        }
    }
}
