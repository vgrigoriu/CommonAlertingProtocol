using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CAPNet.Models;

namespace CAPNet
{
    /// <summary>
    /// Multiple instances MAY occur within an info block.
    /// </summary>
    public class EventCodesValidator : Validator<Info>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="info"></param>
        public EventCodesValidator(Info info)
            : base(info)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                return from eventCode in Entity.EventCodes
                       from error in GetErrors(eventCode)
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
        /// <param name="eventCode"></param>
        /// <returns></returns>
        private static IEnumerable<Error> GetErrors(EventCode eventCode)
        {
            var eventCodeValidators = from type in typeof(EventCodesValidator).GetTypeInfo().Assembly.DefinedTypes
                                      where typeof(IValidator<EventCode>).GetTypeInfo().IsAssignableFrom(type)
                                      select (IValidator<EventCode>)Activator.CreateInstance(type.AsType(), eventCode);

            return from validator in eventCodeValidators
                   from error in validator.Errors
                   select error;
        }
    }
}
