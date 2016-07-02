using CAPNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CAPNet
{
    /// <summary>
    /// Must validate the container for all component parts of the info sub-element of the alert message !
    /// </summary>
    public class InfoValidator : Validator<Alert>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="alert"></param>
        public InfoValidator(Alert alert)
            : base(alert) { }

        /// <summary>
        ///
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                return from info in Entity.Info
                       from error in GetErrors(info)
                       select error;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private static IEnumerable<Error> GetErrors(Info info)
        {
            var infoValidators = from type in typeof(InfoValidator).GetTypeInfo().Assembly.DefinedTypes
                                 where typeof(IValidator<Info>).GetTypeInfo().IsAssignableFrom(type)
                                 select (IValidator<Info>)Activator.CreateInstance(type.AsType(), info);

            return from validator in infoValidators
                   from error in validator.Errors
                   select error;
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
