using System.Collections.Generic;

namespace CAPNet
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidator<T>
    {
        /// <summary>
        ///
        /// </summary>
        bool IsValid
        {
            get;
        }

        /// <summary>
        ///
        /// </summary>
        T Entity
        {
            get;
        }

        /// <summary>
        ///
        /// </summary>
        IEnumerable<Error> Errors
        {
            get;
        }
    }
}