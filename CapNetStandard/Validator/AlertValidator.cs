using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CAPNet.Models;

namespace CAPNet
{
    /// <summary>
    ///
    /// </summary>
    public class AlertValidator
    {
        private readonly Alert alert;

        /// <summary>
        ///
        /// </summary>
        /// <param name="alert"></param>
        public AlertValidator(Alert alert)
        {
            this.alert = alert;
        }

        /// <summary>
        ///
        /// </summary>
        public Alert Alert
        {
            get { return alert; }
        }

        /// <summary>
        ///
        /// </summary>
        public bool IsValid
        {
            get
            {
                return !Errors.Any();
            }
        }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<Error> Errors
        {
            get
            {
                return from error in GetErrors(alert)
                       select error;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="alert"></param>
        /// <returns></returns>
        private static IEnumerable<Error> GetErrors(Alert alert)
        {
            var alertValidator = from type in typeof(AlertValidator).GetTypeInfo().Assembly.DefinedTypes
                                 where typeof(Validator<Alert>).GetTypeInfo().IsAssignableFrom(type)
                                 select (Validator<Alert>)Activator.CreateInstance(type.AsType(), alert);

            return from validator in alertValidator
                   from error in validator.Errors
                   select error;
        }
    }
}