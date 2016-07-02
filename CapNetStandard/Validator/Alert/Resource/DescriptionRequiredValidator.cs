using System.Collections.Generic;
using CAPNet.Models;

namespace CAPNet
{
    /// <summary>
    /// The text describing the type and content of the resource file is Required!
    /// </summary>
    public class ResourceDescriptionRequiredValidator : Validator<Resource>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="resource"></param>
        public ResourceDescriptionRequiredValidator(Resource resource)
            : base(resource)
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
                    yield return new ResourceDescriptionRequiredError();
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return !string.IsNullOrEmpty(Entity.Description);
            }
        }
    }
}
