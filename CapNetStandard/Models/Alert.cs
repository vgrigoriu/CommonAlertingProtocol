using System;
using System.Collections.Generic;

namespace CAPNet.Models
{
    /// <summary>
    /// The container for all component parts of the alert message.
    /// </summary>
    public class Alert
    {
        /// <summary>
        ///
        /// </summary>
        public Alert()
        {
            info = new List<Info>();
            addresses = new List<string>();
            incidents = new List<string>();
            references = new List<string>();
        }

        /// <summary>
        /// The identifier of the alert message
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///         A number or string uniquely identifying this message, assigned by the sender.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///         MUST NOT include spaces, commas or restricted characters (&lt; and &amp;).
        ///       </description>
        ///     </item>
        ///     </list>
        /// </remarks>
        public string Identifier { get; set; }

        /// <summary>
        /// The identifier of the sender of the alert message.
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///         Identifies the originator of this alert. Guaranteed by assigner to be unique globally; e.g., may be based on an Internet domain name.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///         MUST NOT include spaces, commas or restricted characters (&lt; and &amp;).
        ///       </description>
        ///     </item>
        ///     </list>
        /// </remarks>
        public string Sender { get; set; }

        /// <summary>
        /// The time and date of the origination of the alert message.
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///         The date and time SHALL be represented in the DateTime Data Type (See Implementation Notes) format (e.g., "2002-05-24T16:49:00-07:00" for 24 May 2002 at 16:49 PDT).
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///         Alphabetic timezone designators such as "Z" MUST NOT be used. The timezone for UTC MUST be represented as "-00:00".
        ///       </description>
        ///     </item>
        ///     </list>
        /// </remarks>
        public DateTimeOffset? Sent { get; set; }

        /// <summary>
        /// The code denoting the appropriate handling of the alert message
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///          Code Values:
        ///            “Actual” - Actionable by all targeted recipients
        ///            “Exercise” - Actionable only by designated exercise participants; exercise identifier SHOULD appear in &lt;note>
        ///            “System” - For messages that support alert network internal functions
        ///            “Test” - Technical testing only, all recipients disregard
        ///            “Draft” – A preliminary template or draft, not actionable in its current form
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public Status Status { get; set; }

        /// <summary>
        /// The code denoting the nature of the alert message
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///          Code Values:
        ///            “Alert” - Initial information requiring attention by targeted recipients
        ///            “Update” - Updates and supercedes the earlier message(s) identified in &lt;references>
        ///            “Cancel” - Cancels the earlier message(s) identified in &lt;references>
        ///            “Ack” - Acknowledges receipt and acceptance of the message(s) identified in &lt;references>
        ///            “Error” - Indicates rejection of the message(s) identified in &lt;references>; explanation SHOULD appear in &lt;note>
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public MessageType MessageType { get; set; }

        /// <summary>
        /// The text identifying the source of the alert message
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///          Code Values: Natural language identifier per [RFC 3066].
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///          If not present, an implicit default value of "en-US" SHALL be assumed.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///          A null value in this element SHALL be considered equivalent to “en-US.”
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public string Source { get; set; }

        /// <summary>
        /// The code denoting the intended distribution of the alert message
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///          Code Values:
        ///            “Public” - For general dissemination to unrestricted audiences
        ///            “Restricted” - For dissemination only to users with a known operational requirement (see &lt;restriction>, below)
        ///            “Private” - For dissemination only to specified addresses (see &lt;addresses>, below)
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public Scope Scope { get; set; }

        /// <summary>
        /// The text describing the rule for limiting distribution of the restricted alert message
        /// </summary>
        public string Restriction { get; set; }

        /// <summary>
        /// The group listing of intended recipients of the alert message
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///         Required when &lt;scope> is “Private”, optional when &lt;scope> is “Public” or “Restricted”.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///         Each recipient SHALL be identified by an identifier or an address.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///          Multiple space-delimited addresses MAY be included.  Addresses including whitespace MUST be enclosed in double-quotes.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public ICollection<string> Addresses
        {
            get
            {
                return addresses;
            }
        }

        /// <summary>
        /// The code denoting the special handling of the alert message
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///          Any user-defined flag or special code used to flag the alert message for special handling.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///         Multiple instances MAY occur.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public string Code { get; set; }

        /// <summary>
        /// The text describing the purpose or significance of the alert message
        /// </summary>
        /// <remarks>
        ///   <item>
        ///     <description>
        ///        The message note is primarily intended for use with &lt;status> “Exercise” and &lt;msgType> “Error”.
        ///     </description>
        ///   </item>
        /// </remarks>
        public string Note { get; set; }

        /// <summary>
        /// The group listing identifying earlier message(s) referenced by the alert message
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///          The extended message identifier(s) (in the form sender,identifier,sent) of an earlier CAP message or messages referenced by this one.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///         If multiple messages are referenced, they SHALL be separated by whitespace.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public ICollection<string> References
        {
            get
            {
                return references;
            }
        }

        /// <summary>
        /// The group listing naming the referent incident(s) of the alert message
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///          Used to collate multiple messages referring to different aspects of the same incident.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///           If multiple incident identifiers are referenced, they SHALL be separated by whitespace.  Incident names including whitespace SHALL be surrounded by double-quotes.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public ICollection<string> Incidents
        {
            get
            {
                return incidents;
            }
        }

        private readonly ICollection<Info> info;
        private readonly ICollection<string> addresses;
        private readonly ICollection<string> incidents;
        private readonly ICollection<string> references;

        /// <summary>
        /// The container for all component parts of the info sub-element of the alert message.
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///          Multiple occurrences are permitted within a single &lt;alert>.
        ///          If targeting of multiple &lt;info> blocks in the same language overlaps, information in later blocks may expand but may not override the corresponding values in earlier ones.
        ///          Each set of &lt;info> blocks containing the same language identifier SHALL be treated as a separate sequence.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///         In addition to the specified sub-elements, MAY contain one or more &lt;resource> blocks and/or one or more &lt;area> blocks.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public ICollection<Info> Info
        {
            get { return info; }
        }
    }
}
