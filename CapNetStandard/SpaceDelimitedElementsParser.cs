using System.Collections.Generic;
using System.Text;

namespace CAPNet
{
    /// <summary>
    /// This class parses a string containing space-delimited elements, e.g.
    /// «one two "three four"» will be splited into «one», «two», and «three four».
    /// </summary>
    public class SpaceDelimitedElementsParser
    {
        private readonly StringBuilder partialElement;
        private readonly List<string> elements;
        private readonly string representation;
        private int currentPosition;

        public SpaceDelimitedElementsParser(string representation)
        {
            this.representation = representation;
            partialElement = new StringBuilder();
            elements = new List<string>();
        }

        /// <summary>
        /// Multiple space-delimited elements MAY be included.
        /// Elements including whitespace MUST be enclosed in double-quotes.
        ///
        /// See the tests for examples.
        /// </summary>
        /// <returns>Elements in a IEnumerable&lt;string></returns>
        public IEnumerable<string> GetElements()
        {
            var currentState = SpaceDelimitedElementsParserState.BETWEEN_ELEMENTS;

            for (currentPosition = 0; currentPosition < representation.Length; currentPosition++)
            {
                char currentChar = representation[currentPosition];

                if (currentChar.IsQuote())
                {
                    currentState = currentState.OnQuote(this);
                }
                else if (currentChar.IsSpace())
                {
                    currentState = currentState.OnSpace(this, currentChar);
                }
                else
                {
                    currentState = currentState.OnOtherCharacter(this, currentChar);
                }
            }

            return elements;
        }

        internal void AddCurrentElementToList()
        {
            elements.Add(partialElement.ToString());
            partialElement.Clear();
        }

        internal void AddToCurrentElement(char currentChar)
        {
            partialElement.Append(currentChar);
            if (currentPosition == representation.Length - 1)
            {
                elements.Add(partialElement.ToString());
            }
        }
    }
}
