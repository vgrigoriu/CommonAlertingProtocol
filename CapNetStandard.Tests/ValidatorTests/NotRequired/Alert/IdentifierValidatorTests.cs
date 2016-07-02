using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class IdentifierValidatorTests
    {
        [Fact]
        public void IdentifierWithValidNameIsValid()
        {
            var alert = new Alert();
            alert.Identifier = "43b080713727";

            var identifierValidator = new IdentifierValidator(alert);
            Assert.True(identifierValidator.IsValid);
        }

        [Fact]
        public void IdentifierWithCommaIsInvalid()
        {
            var alert = new Alert();
            alert.Identifier = "43b080713727,";

            var identifierValidator = new IdentifierValidator(alert);
            Assert.False(identifierValidator.IsValid);
            Assert.Equal(typeof(IdentifierError), identifierValidator.Errors.ElementAt(0).GetType());
            Assert.Equal(1, identifierValidator.Errors.Count());
        }
    }
}
