using CAPNet.Models;
using System.Collections.Generic;

namespace CAPNet
{
    /// <summary>
    /// The identifier of sender must not include spaces , commas or restricted characters !
    /// </summary>
    public class SenderValidator : Validator<Alert>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="alert"></param>
        public SenderValidator(Alert alert)
            : base(alert) { }

        /// <summary>
        ///
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new SenderError();
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return Entity.Sender.DoesNotContainsRestrictedChars();
            }
        }
    }
}
