using CAPNet.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CAPNet
{
    /// <summary>
    /// The code representing the digital digest is calculated using the SHA-1
    /// </summary>
    public class DigestValidator : Validator<Resource>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="resource"></param>
        public DigestValidator(Resource resource) : base(resource) { }

        /// <summary>
        ///
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new DigestError();
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override bool IsValid
        {
            get
            {
                if (Entity.Digest == null) return true;

                var digestMatchesHexaDigits = Regex.Match(Entity.Digest, "^[a-fA-F0-9]{40}$");

                return digestMatchesHexaDigits.Success;
            }
        }
    }
}
