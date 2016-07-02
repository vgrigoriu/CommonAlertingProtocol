using System.Collections.Generic;
using CAPNet.Models;
using CAPNet.Validator.Errors;

namespace CAPNet.Validator.Alert
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GeneralNamedValueValidator<T> : Validator<T>
        where T : NamedValue
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="namedValue"></param>
        public GeneralNamedValueValidator(T namedValue)
            : base(namedValue)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                {
                    yield return GetError();
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override bool IsValid => Entity.Value != null && Entity.ValueName != null;

        private static Error GetError()
        {
            return new NamedValueError<T>();
        }
    }
}
