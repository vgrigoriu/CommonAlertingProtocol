namespace CAPNet.Models
{
    /// <summary>
    /// A system-specific additional parameter associated with the alert message
    /// </summary>
    public class Parameter : NamedValue
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="valueName">user-assigned string designating the domain of the code</param>
        /// <param name="value">is a string (which may represent a number) denoting the value itself (e.g., valueName ="SAME" and value="CIV").</param>
        public Parameter(string valueName, string value)
            : base(valueName, value)
        {
        }
    }
}
