using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class ScopeRequiredValidatorTests
    {
        [Fact]
        public void AlertWithScopeWellDefinedIsValid()
        {
            var alert = new Alert();
            alert.Scope = Scope.Public;

            var scopeRequiredValidator = new ScopeRequiredValidator(alert);
            Assert.True(scopeRequiredValidator.IsValid);
        }

        [Fact]
        public void AlertWithScopeWrongDefinedIsInvalid()
        {
            var alert = new Alert();
            alert.Scope = (Scope)123;

            var scopeRequiredValidator = new ScopeRequiredValidator(alert);
            Assert.False(scopeRequiredValidator.IsValid);
            Assert.Equal(typeof(ScopeRequiredError), scopeRequiredValidator.Errors.ElementAt(0).GetType());
        }
    }
}
