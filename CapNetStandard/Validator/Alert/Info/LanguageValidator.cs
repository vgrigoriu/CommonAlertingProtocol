using CAPNet.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CAPNet
{
    /// <summary>
    /// The code denoting the language of the info sub-element of the alert message validator!
    /// </summary>
    public class LanguageValidator : Validator<Info>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="info"></param>
        public LanguageValidator(Info info)
            : base(info) { }

        /// <summary>
        ///
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new LanguageError();
            }
        }

        /// <summary>
        /// Conditions of validity :
        ///     1.Code Values: Natural language identifier per [RFC 3066].
        ///     2.A null value in this element SHALL be considered equivalent to “en-US.”
        /// </summary>
        public override bool IsValid
        {
            get
            {
                if (string.IsNullOrEmpty(Entity.Language)) return true;

                return CultureIsValid();
            }
        }

        private bool CultureIsValid()
        {
            try
            {
                var resultingLanguage = new CultureInfo(Entity.Language).Name;
                return resultingLanguage.Equals(Entity.Language, StringComparison.OrdinalIgnoreCase);
            }
            catch (CultureNotFoundException)
            {
                // if the exception is caught , it means that the Language is not valid
                return false;
            }
        }
    }
}
