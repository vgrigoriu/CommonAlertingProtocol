using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet.Tests.ValidatorTests
{
    public class RestrictionValidatorTests
    {
        [Fact]
        public void AlertWithScopeDifferentFromRestrictedAndRestrictionNullIsValid()
        {
            var alert = new Alert();
            alert.Scope = Scope.Public;
            alert.Restriction = null;
            
            var restrictionValidator = new RestrictionValidator(alert);
            Assert.True(restrictionValidator.IsValid);
        }

        [Fact]
        public void AlertWithScopeRestrictedAndRestrictionIsValid()
        {
            var alert = new Alert();
            alert.Scope = Scope.Restricted;
            alert.Restriction = "Draft";

            var restrictionValidator = new RestrictionValidator(alert);
            Assert.True(restrictionValidator.IsValid);
        }

        [Fact]
        public void AlertWithScopeRestrictedAndRestrictionNullIsInvalid()
        {
            var alert = new Alert();
            alert.Scope = Scope.Restricted;
            alert.Restriction = null;

            var restrictionValidator = new RestrictionValidator(alert);
            Assert.False(restrictionValidator.IsValid);

            var restrictionErrors = from error in restrictionValidator.Errors
                                    where error.GetType() == typeof(RestrictionError)
                                    select error;
            Assert.NotEmpty(restrictionErrors);
        }

        [Fact]
        public void AlertWithScopeDifferentFromRestrictedAndRestrictionIsInvalid()
        {
            var alert = new Alert();
            alert.Scope = Scope.Public;
            alert.Restriction = "Draft";

            var restrictionValidator = new RestrictionValidator(alert);
            Assert.False(restrictionValidator.IsValid);

            var restrictionErrors = from error in restrictionValidator.Errors
                                    where error.GetType() == typeof(RestrictionError)
                                    select error;
            Assert.NotEmpty(restrictionErrors);
        }
    }
}
