namespace CAPNet.Models
{
    /// <summary>
    /// The code denoting the category of the subject event of the alert message.
    /// </summary>
    public enum Category
    {
        /// <summary>
        /// Geophysical (inc. landslide)
        /// </summary>
        Geo,
        /// <summary>
        ///  Meteorological (inc. flood)
        /// </summary>
        Met,
        /// <summary>
        /// General emergency and public safety
        /// </summary>
        Safety,
        /// <summary>
        /// Law enforcement, military, homeland and local/private security
        /// </summary>
        Security,
        /// <summary>
        /// Rescue and recovery
        /// </summary>
        Rescue,
        /// <summary>
        /// Fire suppression and rescue
        /// </summary>
        Fire,
        /// <summary>
        /// Medical and public health
        /// </summary>
        Health,
        /// <summary>
        /// Pollution and other environmental
        /// </summary>
        Env,
        /// <summary>
        /// Public and private transportation
        /// </summary>
        Transport,
        /// <summary>
        /// Utility, telecommunication, other non-transport infrastructure
        /// </summary>
        Infra,
        /// <summary>
        /// Chemical, Biological, Radiological, Nuclear or High-Yield Explosive threat or attack
        /// </summary>
        CBRNE,
        /// <summary>
        /// Other events
        /// </summary>
        Other
    }
}