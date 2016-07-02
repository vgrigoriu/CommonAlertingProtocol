using CAPNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CAPNet
{
    /// <summary>
    /// Multiple instances MAY occur within an info block.
    /// </summary>
    public class ResponseTypesValidator : Validator<Info>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="info"></param>
        public ResponseTypesValidator(Info info) : base(info) { }

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
                return from responseType in Entity.ResponseTypes
                       from error in GetErrors(responseType)
                       select error;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="responseType"></param>
        /// <returns></returns>
        private static IEnumerable<Error> GetErrors(ResponseType responseType)
        {
            var responseTypeValidators = from type in typeof(ResponseTypesValidator).GetTypeInfo().Assembly.DefinedTypes
                                         where typeof(IValidator<ResponseType>).GetTypeInfo().IsAssignableFrom(type)
                                         select (IValidator<ResponseType>)Activator.CreateInstance(type.AsType(), responseType);

            return from validator in responseTypeValidators
                   from error in validator.Errors
                   select error;
        }
    }
}
