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
    public class ParametersValidator : Validator<Info>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public ParametersValidator(Info info) : base(info) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                return from parameter in Entity.Parameters
                       from error in GetErrors(parameter)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private static IEnumerable<Error> GetErrors(Parameter parameter)
        {
            var parametersValidators = from type in typeof(ParametersValidator).GetTypeInfo().Assembly.DefinedTypes
                                       where typeof(IValidator<Parameter>).GetTypeInfo().IsAssignableFrom(type)
                                       select (IValidator<Parameter>)Activator.CreateInstance(type.AsType(), parameter);

            return from validator in parametersValidators
                   from error in validator.Errors
                   select error;
        }
    }
}
