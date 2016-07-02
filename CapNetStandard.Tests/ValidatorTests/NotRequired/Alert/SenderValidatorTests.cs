using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet.Tests.ValidatorTests
{
    public class SenderValidatorTests
    {
        [Fact]
        public void AlertWithSenderValidIsValid()
        {
            var alert = new Alert();
            alert.Sender = "trinet@caltech.edu";

            var senderValidator = new SenderValidator(alert);
            Assert.True(senderValidator.IsValid);
        }

        [Fact]
        public void AlertWithSenderContainingCommaIsInvalid()
        {
            var alert = new Alert();
            alert.Sender = "trinet@caltech.edu,";

            var senderValidator = new SenderValidator(alert);
            Assert.False(senderValidator.IsValid);
            Assert.Equal(typeof(SenderError), senderValidator.Errors.ElementAt(0).GetType());
        }
    }
}
