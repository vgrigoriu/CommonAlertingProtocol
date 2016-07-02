namespace CAPNet.Models
{
    /// <summary>
    /// The code denoting the nature of the alert message
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// Initial information requiring attention by targeted recipients
        /// </summary>
        Alert,
        /// <summary>
        /// Updates and supercedes the earlier message(s) identified in &lt;references>
        /// </summary>
        Update,
        /// <summary>
        /// Cancels the earlier message(s) identified in &lt;references>
        /// </summary>
        Cancel,
        /// <summary>
        /// Acknowledges receipt and acceptance of the message(s) identified in &lt;references>
        /// </summary>
        Ack,
        /// <summary>
        /// Indicates rejection of the message(s) identified in &lt;references>; explanation SHOULD appear in &lt;note>
        /// </summary>
        Error
    }
}