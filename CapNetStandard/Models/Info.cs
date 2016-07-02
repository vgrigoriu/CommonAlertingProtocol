using System;
using System.Collections.Generic;

namespace CAPNet.Models
{
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
    public class Info
    {
        /// <summary>
        ///
        /// </summary>
        public static readonly string DefaultLanguage = "en-US";

        private readonly ICollection<Parameter> parameters;

        private readonly ICollection<EventCode> eventCodes;

        private readonly ICollection<Category> categories;

        private readonly ICollection<Resource> resources;

        private readonly ICollection<Area> areas;

        private readonly ICollection<ResponseType> responseTypes;

        private string language;

        /// <summary>
        ///
        /// </summary>
        public Info()
        {
            parameters = new List<Parameter>();
            eventCodes = new List<EventCode>();
            categories = new List<Category>();
            resources = new List<Resource>();
            areas = new List<Area>();
            responseTypes = new List<ResponseType>();
        }

        /// <summary>
        /// Gets or sets the code denoting the language of the info sub-element of the alert message.
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
        public string Language
        {
            get { return string.IsNullOrWhiteSpace(language) ? DefaultLanguage : language; }
            set { language = value; }
        }

        /// <summary>
        /// The codes denoting the type of action recommended for the target audience
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///           Code Values:
        ///             “Shelter” – Take shelter in place or per &lt;instruction>
        ///             “Evacuate” – Relocate as instructed in the &lt;instruction>
        ///             “Prepare” – Make preparations per the &lt;instruction>
        ///             “Execute” – Execute a pre-planned activity identified in &lt;instruction>
        ///             “Avoid” – Avoid the subject event as per the &lt;instruction>
        ///             “Monitor” – Attend to information sources as described in &lt;instruction>
        ///             “Assess” – Evaluate the information in this message.  (This value SHOULD NOT be used in public warning applications.)
        ///             “AllClear” – The subject event no longer poses a threat or concern and any follow on action is described in &lt;instruction>
        ///             “None” – No action recommended
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///           Multiple instances MAY occur within an &lt;info> block.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public ICollection<ResponseType> ResponseTypes
        {
            get
            {
                return responseTypes;
            }
        }

        /// <summary>
        /// The codes denoting the category of the subject event of the alert message
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///          Code Values:
        ///             “Geo” - Geophysical (inc. landslide)
        ///             “Met” - Meteorological (inc. flood)
        ///             “Safety” - General emergency and public safety
        ///             “Security” - Law enforcement, military, homeland and local/private security
        ///             “Rescue” - Rescue and recovery
        ///             “Fire” - Fire suppression and rescue
        ///             “Health” - Medical and public health
        ///             “Env” - Pollution and other environmental
        ///             “Transport” - Public and private transportation
        ///             “Infra” - Utility, telecommunication, other non-transport infrastructure
        ///             “CBRNE” – Chemical, Biological, Radiological, Nuclear or High-Yield Explosive threat or attack
        ///             “Other” - Other events
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///            Multiple instances MAY occur within an &lt;info> block.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public ICollection<Category> Categories
        {
            get { return categories; }
        }

        /// <summary>
        /// The text denoting the type of the subject event of the alert message
        /// </summary>
        public string Event { get; set; }

        /// <summary>
        /// The code denoting the urgency of the subject event of the alert message
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///          The &lt;urgency>, &lt;severity>, and &lt;certainty> elements collectively distinguish less emphatic from more emphatic messages.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///           Code Values:
        ///            “Immediate” - Responsive action SHOULD be taken immediately
        ///            “Expected” - Responsive action SHOULD be taken soon (within next hour)
        ///            “Future” - Responsive action SHOULD be taken in the near future
        ///            “Past” - Responsive action is no longer required
        ///            “Unknown” - Urgency not known
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public Urgency Urgency { get; set; }

        /// <summary>
        /// The code denoting the severity of the subject event of the alert message
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///          The &lt;urgency>, &lt;severity>, and &lt;certainty> elements collectively distinguish less emphatic from more emphatic messages.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///          Code Values:
        ///            “Extreme” - Extraordinary threat to life or property
        ///            “Severe” - Significant threat to life or property
        ///            “Moderate” - Possible threat to life or property
        ///            “Minor” – Minimal to no known threat to life or property
        ///            “Unknown” - Severity unknown
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public Severity Severity { get; set; }

        /// <summary>
        /// The code denoting the certainty of the subject event of the alert message
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///          The &lt;urgency>, &lt;severity>, and &lt;lcertainty> elements collectively distinguish less emphatic from more emphatic messages.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///          Code Values:
        ///            “Observed” – Determined to have occurred or to be ongoing
        ///            “Likely” - Likely (p > ~50%)
        ///            “Possible” - Possible but not likely
        ///            “Unlikely” - Not expected to occur (p ~ 0)
        ///            “Unknown” - Certainty unknown
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///          A null value in this element SHALL be considered equivalent to “en-US.”
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public Certainty Certainty { get; set; }

        /// <summary>
        /// The text describing the intended audience of the alert message
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// The effective time of the information of the alert message
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///          The date and time SHALL be represented in the DateTime Data Type (See Implementation Notes)
        ///          format (e.g., “2002-05-24T16:49:00-07:00” for 24 May 2002 at 16: 49 PDT).
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///           Alphabetic timezone designators such as “Z” MUST NOT be used.
        ///           The timezone for UTC MUST be represented as “-00:00”.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///           If this item is not included, the effective time SHALL be assumed to be the same as in &lt;sent>.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public DateTimeOffset? Effective { get; set; }

        /// <summary>
        /// The expected time of the beginning of the subject event of the alert message
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///          The date and time SHALL be represented in the DateTime Data Type (See Implementation Notes)
        ///          format (e.g., “2002-05-24T16:49:00-07:00” for 24 May 2002 at 16: 49 PDT).
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///          Alphabetic timezone designators such as “Z” MUST NOT be used.
        ///          The timezone for UTC MUST be represented as “-00:00”.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public DateTimeOffset? Onset { get; set; }

        /// <summary>
        /// The expiry time of the information of the alert message
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///          The date and time SHALL be represented in the DateTime Data Type (See Implementation Notes)
        ///          format (e.g., “2002-05-24T16:49:00-07:00” for 24 May 2002 at 16:49 PDT).
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///           Alphabetic timezone designators such as “Z” MUST NOT be used.
        ///           The timezone for UTC MUST be represented as “-00:00”.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///          If this item is not provided, each recipient is free to set its own policy as to when the message is no longer in effect.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public DateTimeOffset? Expires { get; set; }

        /// <summary>
        /// The text naming the originator of the alert message
        /// </summary>
        /// <remarks>
        ///  <list type="number">
        ///    <item>
        ///      <description>
        ///         The human-readable name of the agency or authority issuing this alert.
        ///      </description>
        ///    </item>
        ///  </list>
        /// </remarks>
        public string SenderName { get; set; }

        /// <summary>
        /// The text headline of the alert message
        /// </summary>
        /// <remarks>
        ///  <list type="number">
        ///    <item>
        ///      <description>
        ///         A brief human-readable headline.  Note that some displays (for example, short messaging service devices) may only present this headline;
        ///         it SHOULD be made as direct and actionable as possible while remaining short.
        ///         160 characters MAY be a useful target limit for headline length.
        ///      </description>
        ///    </item>
        ///  </list>
        /// </remarks>
        public string Headline { get; set; }

        /// <summary>
        /// The text describing the subject event of the alert message
        /// </summary>
        /// <remarks>
        ///  <list type="number">
        ///    <item>
        ///      <description>
        ///         An extended human readable description of the hazard or event that occasioned this message.
        ///      </description>
        ///    </item>
        ///  </list>
        /// </remarks>
        public string Description { get; set; }

        /// <summary>
        /// The text describing the recommended action to be taken by recipients of the alert message
        /// </summary>
        /// <remarks>
        ///  <list type="number">
        ///    <item>
        ///      <description>
        ///         An extended human readable instruction to targeted recipients.
        ///         If different instructions are intended for different recipients, they should be represented by use of multiple &lt;info> blocks.
        ///      </description>
        ///    </item>
        ///  </list>
        /// </remarks>
        public string Instruction { get; set; }

        /// <summary>
        /// The identifier of the hyperlink associating additional information with the alert message
        /// </summary>
        /// <remarks>
        ///  <list type="number">
        ///    <item>
        ///      <description>
        ///         A full, absolute URI for an HTML page or other text resource with additional or reference information regarding this alert.
        ///      </description>
        ///    </item>
        ///  </list>
        /// </remarks>
        public Uri Web { get; set; }

        /// <summary>
        /// The text describing the contact for follow-up and confirmation of the alert message
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// System-specific additional parameters associated
        /// with the alert message (OPTIONAL)
        /// </summary>
        /// <remarks>
        ///  <list type="number">
        ///    <item>
        ///      <description>
        ///         Any system-specific datum, in the form:
        ///            &lt;parameter>
        ///              &lt;valueName>valueName&lt;/valueName>
        ///              &lt;value>value&lt;/value>
        ///            &lt;/parameter>
        ///            where the content of “valueName” is a user-assigned string designating the domain of the code,
        ///            and the content of “value” is a string (which may represent a number) denoting the value itself (e.g., valueName ="SAME" and value="CIV").
        ///      </description>
        ///    </item>
        ///    <item>
        ///      <description>
        ///         Values of “valueName” that are acronyms SHOULD be represented in all capital letters without periods (e.g., SAME, FIPS, ZIP).
        ///      </description>
        ///    </item>
        ///     <item>
        ///      <description>
        ///         Multiple instances MAY occur within an &lt;info> block.
        ///      </description>
        ///    </item>
        ///  </list>
        /// </remarks>
        public ICollection<Parameter> Parameters
        {
            get { return parameters; }
        }

        /// <summary>
        /// A system-specific codes identifying the event type of the alert message
        /// </summary>
        /// <remarks>
        ///  <list type="number">
        ///    <item>
        ///      <description>
        ///         Any system-specific datum, in the form:
        ///            &lt;parameter>
        ///              &lt;valueName>valueName&lt;/valueName>
        ///              &lt;value>value&lt;/value>
        ///            &lt;/parameter>
        ///            where the content of “valueName” is a user-assigned string designating the domain of the code,
        ///            and the content of “value” is a string (which may represent a number) denoting the value itself (e.g., valueName ="SAME" and value="CEM").
        ///      </description>
        ///    </item>
        ///    <item>
        ///      <description>
        ///         Values of “valueName” that are acronyms SHOULD be represented in all capital letters without periods (e.g., SAME, FIPS, ZIP)..
        ///      </description>
        ///    </item>
        ///     <item>
        ///      <description>
        ///         Multiple instances MAY occur within an &lt;info> block.
        ///      </description>
        ///    </item>
        ///  </list>
        /// </remarks>
        public ICollection<EventCode> EventCodes
        {
            get { return eventCodes; }
        }

        /// <summary>
        /// Refers to additional files with supplemental information related to this info element
        /// </summary>
        /// <remarks>
        ///  <list type="number">
        ///    <item>
        ///      <description>
        ///         Refers to an additional file with supplemental information related to this &lt;info> element; e.g., an image or audio file.
        ///      </description>
        ///    </item>
        ///    <item>
        ///      <description>
        ///         Multiple instances MAY occur within an &lt;info> block.
        ///      </description>
        ///    </item>
        ///  </list>
        /// </remarks>
        public ICollection<Resource> Resources
        {
            get { return resources; }
        }

        /// <summary>
        /// The container for all component parts of the area sub-element of the info sub-element of the alert message
        /// </summary>
        /// <remarks>
        ///  <list type="number">
        ///    <item>
        ///      <description>
        ///         Multiple occurrences permitted, in which case the target area for the &lt;info> block is the union of all the included &lt;area> blocks.
        ///      </description>
        ///    </item>
        ///    <item>
        ///      <description>
        ///          MAY contain one or multiple instances of &lt;polygon>, &lt;circle> or &lt;geocode>.
        ///          If multiple &lt;polygon>, &lt;circle> or &lt;geocode>  elements are included,
        ///          the area described by this &lt;area> block is represented by the union of all the included elements.
        ///      </description>
        ///    </item>
        ///  </list>
        /// </remarks>
        public ICollection<Area> Areas
        {
            get { return areas; }
        }
    }
}
