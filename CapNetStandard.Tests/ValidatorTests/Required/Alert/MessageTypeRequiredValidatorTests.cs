using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class MessageTypeRequiredValidatorTests
    {
        [Fact]
        public void AlertWithMessageTypeWellDefinedIsValid()
        {
            var alert = new Alert();
            alert.MessageType = MessageType.Ack;

            var messageTypeRequiredValidator = new MessageTypeRequiredValidator(alert);
            Assert.True(messageTypeRequiredValidator.IsValid);
        }

        [Fact]
        public void AlertWithMessageTypeWrongDefinedIsInvalid()
        {
            var alert = new Alert();
            alert.MessageType = (MessageType)123;

            var messageTypeRequiredValidator = new MessageTypeRequiredValidator(alert);
            Assert.False(messageTypeRequiredValidator.IsValid);
            Assert.Equal(typeof(MessageTypeRequiredError), messageTypeRequiredValidator.Errors.ElementAt(0).GetType());
        }
    }
}
