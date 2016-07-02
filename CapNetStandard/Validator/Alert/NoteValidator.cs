using CAPNet.Models;
using System.Collections.Generic;

namespace CAPNet
{
    /// <summary>
    ///The message note is primarily intended for use with status “Exercise” and msgType “Error”
    /// </summary>
    public class NoteValidator : Validator<Alert>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="alert"></param>
        public NoteValidator(Alert alert)
            : base(alert) { }

        /// <summary>
        ///
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new NoteError();
            }
        }

        /// <summary>
        /// Note is used when status is Exercise or MessageType is Error
        /// </summary>
        public override bool IsValid
        {
            get
            {
                // if Status is Exercise or MessageType Error, Note should be not null
                // or not empty in order that the overall condition be true
                var statusIsNotExercise = Entity.Status != Status.Exercise;
                var messageTypeIsNotError = Entity.MessageType != MessageType.Error;

                if (statusIsNotExercise && messageTypeIsNotError) return true;

                return !string.IsNullOrEmpty(Entity.Note);
            }
        }
    }
}
