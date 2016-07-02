using CAPNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CAPNet
{
    /// <summary>
    /// The code denoting the category of the subject event of the alert message must have certain code values!
    /// </summary>
    public class InvalidCategoryValidator : Validator<Info>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="info"></param>
        public InvalidCategoryValidator(Info info)
            : base(info) { }

        /// <summary>
        ///
        /// </summary>
        public override bool IsValid
        {
            get
            {
                var invalidCategories = from category in Entity.Categories
                                        where !Enum.IsDefined(typeof(Category), category)
                                        select category;

                return !invalidCategories.Any();
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
                    yield return new InvalidCategoryError();
            }
        }
    }
}
