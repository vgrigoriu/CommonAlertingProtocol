using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class SendeRequiredrValidatorTests
    {
        [Fact]
        public void SenderWithValidNameIsValid()
        {
            var alert = new Alert();
            alert.Sender = "hsas@dhs.gov";

            var senderValidator = new SenderRequiredValidator(alert);
            Assert.True(senderValidator.IsValid);
            Assert.Equal(0, senderValidator.Errors.Count());
        }

        [Fact]
        public void SenderWithNullNameIsInvalid()
        {
            var alert = new Alert();
            alert.Sender = null;

            var senderValidator = new SenderRequiredValidator(alert);
            Assert.False(senderValidator.IsValid);
            Assert.Equal(typeof(SenderRequiredError), senderValidator.Errors.ElementAt(0).GetType());
        }
    }
}
