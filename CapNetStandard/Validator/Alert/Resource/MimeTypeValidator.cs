using CAPNet.Models;
using System.Collections.Generic;

namespace CAPNet
{
    /// <summary>
    /// MIME content type and sub-type are described as in [RFC 2046]
    /// </summary>
    public class MimeTypeValidator : Validator<Resource>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="resource"></param>
        public MimeTypeValidator(Resource resource) : base(resource) { }

        /// <summary>
        ///
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new MimeTypeError();
            }
        }

        private static readonly ICollection<string> topLevelMediaType = new List<string>
        {
            "text",
            "image",
            "audio",
            "video",
            "application",
            "multipart",
            "message"
        };

        /// <summary>
        ///
        /// </summary>
        public override bool IsValid
        {
            get
            {
                if (Entity.MimeType == null) return false;

                return MimeTypeIsValid();
            }
        }

        private bool MimeTypeIsValid()
        {
            if (!Entity.MimeType.Contains("/")) return false;

            var splittedMimeType = Entity.MimeType.Split('/');

            return topLevelMediaType.Contains(splittedMimeType[0]);
        }
    }
}
