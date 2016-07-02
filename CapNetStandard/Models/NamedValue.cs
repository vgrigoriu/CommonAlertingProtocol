namespace CAPNet.Models
{
    /// <summary>
    /// Base class for values with names (e.g. EventCode, GeoCode)
    /// </summary>
    public class NamedValue
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueName"></param>
        /// <param name="value"></param>
        protected NamedValue(string valueName, string value)
        {
            ValueName = valueName;
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// 
        /// </summary>
        public string ValueName { get; }
    }
}