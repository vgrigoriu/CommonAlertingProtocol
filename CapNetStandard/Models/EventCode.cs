namespace CAPNet.Models
{
    /// <summary>
    /// A system-specific code identifying the event type of the alert message 
    /// </summary>
    public class EventCode : NamedValue
    {
        /// <summary>
        /// A system-specific code identifying the event type of the alert message 
        /// </summary>
        /// <param name="valueName">user-assigned string designating the domain of the code</param>
        /// <param name="value">a string (which may represent a number) denoting the value itself (e.g., valueName ="SAME" and value="CEM").</param>
        public EventCode(string valueName, string value)
            : base(valueName, value)
        {
        }
    }
}
