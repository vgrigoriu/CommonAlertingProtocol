using CAPNet.Models;
using System.Collections.Generic;

namespace CAPNet
{
    /// <summary>
    /// Explanation of the MsgType Error SHOULD appear in note !
    /// </summary>
    public class MessageTypeRejectionValidator : Validator<Alert>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="alert"></param>
        public MessageTypeRejectionValidator(Alert alert)
            : base(alert) { }

        /// <summary>
        ///
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new MessageTypeRejectionError();
            }
        }

        /// <summary>
        /// Message Type that is Error should have description in note
        /// </summary>
        public override bool IsValid
        {
            get
            {
                var messageTypeIsNotError = !Entity.MessageType.Equals(MessageType.Error);
                var noteIsNotNullOrEmpty = !string.IsNullOrEmpty(Entity.Note);

                return messageTypeIsNotError || noteIsNotNullOrEmpty;
            }
        }
    }
}
