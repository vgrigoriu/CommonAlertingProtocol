using System.Collections.Generic;
using CAPNet.Models;

namespace CAPNet
{
    /// <summary>
    /// Addresses is required when scope is Private !
    /// </summary>
    public class AddressesRequiredWhenScopePrivateValidator : Validator<Alert>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="alert"></param>
        public AddressesRequiredWhenScopePrivateValidator(Alert alert)
            : base(alert)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public override bool IsValid
        {
            get
            {
                var scopeIsNotPrivate = Entity.Scope != Scope.Private;
                var addressesIsNotEmpty = Entity.Addresses.Count != 0;

                return scopeIsNotPrivate || addressesIsNotEmpty;
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
                    yield return new AddressesRequiredWhenScopeError();
                }
            }
        }
    }
}
