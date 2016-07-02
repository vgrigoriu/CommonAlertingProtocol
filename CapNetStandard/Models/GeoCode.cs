namespace CAPNet.Models
{
    /// <summary>
    /// Codification of a geographical area (e.g. zip code)
    /// </summary>
    public class GeoCode : NamedValue
    {
        /// <summary>
        /// The geographic code delineating the affected area of the alert message
        /// </summary>
        /// <param name="valueName">a user-assigned string designating the domain of the code</param>
        /// <param name="value">a string (which may represent a number) denoting the value itself (e.g., valueName ="SAME" and value="006113").</param>
        public GeoCode(string valueName, string value)
            : base(valueName, value)
        {
        }
    }
}
