namespace CAPNet.Models
{
    /// <summary>
    /// The code denoting the appropriate handling of the alert message
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Actionable by all targeted recipients
        /// </summary>
        Actual,
        /// <summary>
        /// Actionable only by designated exercise participants; exercise identifier SHOULD appear in note
        /// </summary>
        Exercise,
        /// <summary>
        /// For messages that support alert network internal functions
        /// </summary>
        System,
        /// <summary>
        /// Technical testing only, all recipients disregard
        /// </summary>
        Test,
        /// <summary>
        /// A preliminary template or draft, not actionable in its current form
        /// </summary>
        Draft
    }
}