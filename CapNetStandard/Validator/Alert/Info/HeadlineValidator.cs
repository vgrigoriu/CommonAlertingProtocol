using CAPNet.Models;
using System.Collections.Generic;

namespace CAPNet
{
    /// <summary>
    /// The text headline of the alert message is not required , but IT MUST have length less than 160 characters
    /// </summary>
    public class HeadlineValidator : Validator<Info>
    {
        private const int maxLengthHeadline = 160;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public HeadlineValidator(Info info) : base(info) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new HeadlineError();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                if (Entity.Headline == null)
                    return true;
                return Entity.Headline.Length <= maxLengthHeadline;
            }
        }
    }
}
