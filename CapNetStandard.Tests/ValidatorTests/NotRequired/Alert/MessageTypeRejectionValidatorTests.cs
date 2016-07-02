using CAPNet.Models;
using Xunit;

using System.Linq;

namespace CAPNet.Tests.ValidatorTests
{
    public class MessageTypeRejectionValidatorTests
    {
        [Fact]
        public void MsgTypeWithErrorThatHasExplanationInNoteIsValid()
        {
            var alert = new Alert();
            alert.MessageType = MessageType.Error;
            alert.Note = "DescriptiveError";

            var msgTypeRejectionValidator = new MessageTypeRejectionValidator(alert);
            Assert.True(msgTypeRejectionValidator.IsValid);
        }

        [Fact]
        public void MsgTypeWithErrorThatHasExplanationInNoteNullIsInvalid()
        {
            var alert = new Alert();
            alert.MessageType = MessageType.Error;
            alert.Note = null;

            var msgTypeRejectionValidator = new MessageTypeRejectionValidator(alert);
            Assert.False(msgTypeRejectionValidator.IsValid);
            Assert.Equal(typeof(MessageTypeRejectionError), msgTypeRejectionValidator.Errors.ElementAt(0).GetType());
        }

        [Fact]
        public void MsgTypeWithNoErrorThatHasExplanationInNoteIsValid()
        {
            var alert = new Alert();
            alert.MessageType = MessageType.Cancel;
            alert.Note = "Descriptive Explanation";

            var msgTypeRejectionValidator = new MessageTypeRejectionValidator(alert);
            Assert.True(msgTypeRejectionValidator.IsValid);
        }

        [Fact]
        public void MsgTypeWithNoErrorThatHasNotExplanationInNoteIsValid()
        {
            var alert = new Alert();
            alert.MessageType = MessageType.Cancel;
            alert.Note = null;

            var msgTypeRejectionValidator = new MessageTypeRejectionValidator(alert);
            Assert.True(msgTypeRejectionValidator.IsValid);
        }
    }
}
