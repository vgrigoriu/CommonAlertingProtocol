using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet.Tests.ValidatorTests
{
    public class NoteValidatorTests
    {
        [Fact]
        public void AlertWithNoteAndStatusExerciseIsValid()
        {
            var alert = new Alert();
            alert.Note = "maxOccurs";
            alert.Status = Status.Exercise;

            var noteValidator = new NoteValidator(alert);
            Assert.True(noteValidator.IsValid);
        }

        [Fact]
        public void AlertWithNoteAndMessageTypeErrorIsValid()
        {
            var alert = new Alert();
            alert.Note = "maxOccurs";
            alert.MessageType = MessageType.Error;

            var noteValidator = new NoteValidator(alert);
            Assert.True(noteValidator.IsValid);
        }

        [Fact]
        public void AlertWithNoteNullAndMessageTypeErrorIsInvalid()
        {
            var alert = new Alert();
            alert.Note = null;
            alert.MessageType = MessageType.Error;

            var noteValidator = new NoteValidator(alert);
            Assert.False(noteValidator.IsValid);
            Assert.Equal(typeof(NoteError), noteValidator.Errors.ElementAt(0).GetType());
        }

        [Fact]
        public void AlertWithNoteNullAndStatusExerciseIsInvalid()
        {
            var alert = new Alert();
            alert.Note = null;
            alert.Status = Status.Exercise;

            var noteValidator = new NoteValidator(alert);
            Assert.False(noteValidator.IsValid);
            Assert.Equal(typeof(NoteError), noteValidator.Errors.ElementAt(0).GetType());
        }

        [Fact]
        public void AlertWithNoteNullAndMessageTypeDifferentFromErrorIsValid()
        {
            var alert = new Alert();
            alert.Note = null;
            alert.MessageType = MessageType.Cancel;

            var noteValidator = new NoteValidator(alert);
            Assert.True(noteValidator.IsValid);
        }

        [Fact]
        public void AlertWithNoteNullAndStatusDifferentFromExerciseIsValid()
        {
            var alert = new Alert();
            alert.Note = null;
            alert.MessageType = MessageType.Cancel;

            var noteValidator = new NoteValidator(alert);
            Assert.True(noteValidator.IsValid);
        }
    }
}
