using System;
using System.Collections.Generic;
using CAPNet.Models;

namespace CAPNet
{
    /// <summary>
    /// Urgency is always required and must have certain code values !
    /// </summary>
    public class UrgencyRequiredValidator : Validator<Info>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="info"></param>
        public UrgencyRequiredValidator(Info info)
            : base(info)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return Enum.IsDefined(typeof(Urgency), Entity.Urgency);
            }
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
                    yield return new UrgencyRequiredError();
                }
            }
        }
    }
}
