using CAPNet.Models;
using System;
using System.Collections.Generic;

namespace CAPNet
{
    /// <summary>
    /// The code denoting the certainty of the subject event of the alert message is REQUIRED and should have certain code values !
    /// </summary>
    public class CertaintyRequiredValidator : Validator<Info>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="info"></param>
        public CertaintyRequiredValidator(Info info) : base(info) { }

        /// <summary>
        ///
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return (Enum.IsDefined(typeof(Certainty), this.Entity.Certainty));
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
                    yield return new CertaintyRequiredError();
            }
        }
    }
}
