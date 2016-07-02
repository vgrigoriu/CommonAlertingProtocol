using CAPNet.Models;
using Xunit;

namespace CAPNet
{
    public class IdentifierRequiredValidatorTests
    {
        [Fact]
        public void AlertWithIdentifierNullIsInvalid()
        {
            var alert = new Alert();
            alert.Identifier = null;

            var identifierRequiredValidator = new IdentifierRequiredValidator(alert);
            Assert.False(identifierRequiredValidator.IsValid);
        }

        [Fact]
        public void AlertWithIdentifierNotNullIsValid()
        {
            var alert = new Alert();
            alert.Identifier = "43b080713727";

            var identifierRequiredValidator = new IdentifierRequiredValidator(alert);
            Assert.True(identifierRequiredValidator.IsValid);
        }
    }
}
