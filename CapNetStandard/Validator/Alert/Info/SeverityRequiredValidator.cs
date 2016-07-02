using CAPNet.Models;
using System;
using System.Collections.Generic;

namespace CAPNet
{
    /// <summary>
    /// Severity is always required and must have certain code values !
    /// </summary>
    public class SeverityRequiredValidator : Validator<Info>
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="info"></param>
        public SeverityRequiredValidator(Info info) : base(info) { }

        /// <summary>
        ///
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return Enum.IsDefined(typeof(Severity),Entity.Severity);
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
                     yield return new SeverityRequiredError();
            }
        }
    }
}
