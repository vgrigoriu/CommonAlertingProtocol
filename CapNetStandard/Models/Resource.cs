using System;

namespace CAPNet.Models
{
    /// <summary>
    /// The container for all component parts of the resource sub-element of the info sub-element of the alert element
    /// </summary>
    /// <remarks>
    ///   <list type="number">
    ///     <item>
    ///       <description>
    ///          Refers to an additional file with supplemental information related to this &lt;info> element; e.g., an image or audio file.
    ///       </description>
    ///     </item>
    ///     <item>
    ///       <description>
    ///          Multiple instances MAY occur within an &lt;info> block.
    ///       </description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class Resource
    {
        /// <summary>
        /// The text describing the type and content of the resource
        /// </summary>
        /// <remarks>
        ///  <list type="number">
        ///    <item>
        ///      <description>
        ///         The human-readable text describing the type and content, such as “map” or “photo”, of the resource file.
        ///      </description>
        ///    </item>
        ///  </list>
        /// </remarks>
        public string Description { get; set; }

        /// <summary>
        /// The identifier of the MIME content type and sub-type describing the resource file
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///          MIME content type and sub-type as described in [RFC 2046].
        ///          (As of this document, the current IANA registered MIME types are listed at http://www.iana.org/assignments/media-types/)
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public string MimeType { get; set; }

        /// <summary>
        /// The integer indicating the size of the resource
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///           Approximate size of the resource file in bytes.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///          For &lt;uri> based resources, &lt;size> SHOULD be included if available.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public int? Size { get; set; }

        /// <summary>
        /// The identifier of the hyperlink for the resource file
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///          A full absolute URI, typically a Uniform Resource Locator that can be used to retrieve the resource over the Internet
        ///          OR a relative URI to name the content of a &lt;derefUri> element if one is present in this resource block.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public Uri Uri { get; set; }

        /// <summary>
        /// The base-64 encoded data content of the resource file
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///          MAY be used either with or instead of the &lt;uri> element in messages transmitted over one-way (e.g., broadcast) data links
        ///          where retrieval of a resource via a URI is not feasible.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///          Clients intended for use with one-way data links MUST support this element.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///          This element MUST NOT be used unless the sender is certain that all direct clients are capable of processing it.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///           If messages including this element are forwarded onto a two-way network, the forwarder MUST strip the &lt;derefUri> element
        ///           and SHOULD extract the file contents and provide a &lt;uri> link to a retrievable version of the file.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///           Providers of one-way data links MAY enforce additional restrictions on the use of this element,
        ///           including message-size limits and restrictions regarding file types.
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public byte[] DereferencedUri { get; set; }

        /// <summary>
        /// The code representing the digital digest (“hash”) computed from the resource file
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///          Calculated using the Secure Hash Algorithm (SHA-1) per [FIPS 180-2].
        ///       </description>
        ///     </item>
        ///   </list>
        /// </remarks>
        public string Digest { get; set; }
    }
}
