namespace CAPNet.Models
{
    /// <summary>
    /// The code denoting the type of action recommended for the target audience
    /// </summary>
    public enum ResponseType
    {
        /// <summary>
        /// Take shelter in place or per instruction
        /// </summary>
        Shelter = 1,
        /// <summary>
        /// Relocate as instructed in the instruction
        /// </summary>
        Evacuate,
        /// <summary>
        /// Make preparations per the instruction
        /// </summary>
        Prepare,
        /// <summary>
        /// Execute a pre-planned activity identified in instruction
        /// </summary>
        Execute,
        /// <summary>
        /// Avoid the subject event as per the instruction
        /// </summary>
        Avoid,
        /// <summary>
        /// Attend to information sources as described in instruction
        /// </summary>
        Monitor,
        /// <summary>
        /// Evaluate the information in this message.  (This value SHOULD NOT be used in public warning applications.)
        /// </summary>
        Assess,
        /// <summary>
        /// The subject event no longer poses a threat or concern and any follow on action is described in instruction
        /// </summary>
        AllClear,
        /// <summary>
        /// No action recommended
        /// </summary>
        None
    }
}
