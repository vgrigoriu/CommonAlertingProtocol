using System;

namespace CAPNet
{
    /// <summary>
    /// Exception that can be thrown when parsing a list of space-delimited elements
    /// </summary>
    public class SpaceDelimitedElementsParserException : Exception
    {
        /// <summary>
        ///
        /// </summary>
        public SpaceDelimitedElementsParserException()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        public SpaceDelimitedElementsParserException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public SpaceDelimitedElementsParserException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}