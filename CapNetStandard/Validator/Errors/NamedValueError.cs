using CAPNet.Models;

namespace CAPNet.Validator.Errors
{
    /// <summary>
    /// Generic error for any NamedValue
    /// </summary>
    /// <typeparam name="T">The class inheriting from NamedValue this is an error for</typeparam>
    public class NamedValueError<T> : Error
        where T : NamedValue
    {
        /// <summary>
        /// Provide a string representation of this error
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{typeof(T).Name} error";
        }
    }
}