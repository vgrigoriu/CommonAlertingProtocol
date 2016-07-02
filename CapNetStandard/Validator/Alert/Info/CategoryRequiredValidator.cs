using CAPNet.Models;
using System.Collections.Generic;
using System.Linq;

namespace CAPNet
{
    /// <summary>
    ///  Multiple instances MAY occur within an info block. At least one valid category is required !
    /// </summary>
    public class CategoryRequiredValidator : Validator<Info>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="info"></param>
        public CategoryRequiredValidator(Info info)
            : base(info) { }

        /// <summary>
        ///
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return Entity.Categories.Any();
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
                    yield return new CategoryRequiredError();
            }
        }
    }
}
