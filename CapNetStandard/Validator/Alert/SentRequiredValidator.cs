using CAPNet.Models;
using System.Collections.Generic;

namespace CAPNet
{
    /// <summary>
    /// The time and date of the origination of the alert message is always required !
    /// </summary>
    public class SentRequiredValidator : Validator<Alert>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="alert"></param>
        public SentRequiredValidator(Alert alert)
            : base(alert) { }

        /// <summary>
        ///
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new SentRequiredError();
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return Entity.Sent != null;
            }
        }
    }
}
