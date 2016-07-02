namespace CAPNet.Models
{
    /// <summary>
    /// The code denoting the intended distribution of the alert message
    /// </summary>
    public enum Scope
    {
        /// <summary>
        /// For general dissemination to unrestricted audiences
        /// </summary>
        Public,
        /// <summary>
        /// For dissemination only to users with a known operational requirement
        /// </summary>
        Restricted,
        /// <summary>
        /// For dissemination only to specified addresses
        /// </summary>
        Private
    }
}