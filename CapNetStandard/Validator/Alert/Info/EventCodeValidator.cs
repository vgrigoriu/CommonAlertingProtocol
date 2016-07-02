using CAPNet.Models;
using CAPNet.Validator.Alert;

namespace CAPNet
{
    /// <summary>
    /// A system-specific code identifying the event type of the alert message mut have value and valueName not null !
    /// </summary>
    public class EventCodeValidator : GeneralNamedValueValidator<EventCode>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="eventCode"></param>
        public EventCodeValidator(EventCode eventCode)
            : base(eventCode)
        {
        }
    }
}
