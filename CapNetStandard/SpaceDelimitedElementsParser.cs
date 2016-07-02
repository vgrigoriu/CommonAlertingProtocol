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
            var currentState = States.BETWEEN_ELEMENTS;

            for (currentPosition = 0; currentPosition < representation.Length; currentPosition++)
            {
                char currentChar = representation[currentPosition];
                if (currentState == States.BETWEEN_ELEMENTS)
                {
                    currentState = BetweenElementsState(currentState, currentChar);
                }
                else if (currentState == States.IN_ELEMENTS_WITH_NO_SPACE)
                {
                    currentState = InAddressWithNoSpaceState(currentState, currentChar);
                }
                else if (currentState == States.IN_SPACE_CONTAINING_ELEMENTS)
                {
                    currentState = InSpaceContainingAddressState(currentState, currentChar);
                }
                else
                {
                    throw new SpaceDelimitedElementsParserException($"Invalid parser state: {currentState}");
                }
            }

            return elements;
        }

        private States InSpaceContainingAddressState(States currentState, char currentChar)
        {
            if (currentChar.IsQuote())
            {
                elements.Add(partialElement.ToString());
                partialElement.Clear();
                return States.BETWEEN_ELEMENTS;
            }

            partialElement.Append(currentChar);
            if (currentPosition == representation.Length - 1)
            {
                elements.Add(partialElement.ToString());
            }

            return currentState;
        }

        private States InAddressWithNoSpaceState(States currentState, char currentChar)
        {
            if (currentChar.IsElementCharacter())
            {
                partialElement.Append(currentChar);
                if (currentPosition == representation.Length - 1)
                {
                    elements.Add(partialElement.ToString());
                }

                return currentState;
            }

            if (currentChar.IsSpace())
            {
                elements.Add(partialElement.ToString());
                partialElement.Clear();
                return States.BETWEEN_ELEMENTS;
            }

            // else: this is an opening quote without a preceding space
            return currentState;
        }

        private States BetweenElementsState(States currentState, char currentChar)
        {
            if (currentChar.IsQuote())
            {
                return States.IN_SPACE_CONTAINING_ELEMENTS;
            }

            if (currentChar.IsElementCharacter())
            {
                partialElement.Append(currentChar);
                if (currentPosition == representation.Length - 1)
                {
                    elements.Add(partialElement.ToString());
                }

                return States.IN_ELEMENTS_WITH_NO_SPACE;
            }

            // if the current element is a space, then we're still between elements
            return currentState;
        }

        private class States : Enumeration<States>
        {
#pragma warning disable SA1310 // Field names must not contain underscore
            public static readonly States BETWEEN_ELEMENTS = new States(0, "Between elements");
            public static readonly States IN_SPACE_CONTAINING_ELEMENTS = new States(1, "In space containing elements");
            public static readonly States IN_ELEMENTS_WITH_NO_SPACE = new States(2, "In elements with no space");
#pragma warning restore SA1310 // Field names must not contain underscore

            private States(int value, string displayName)
                : base(value, displayName)
            {
            }
        }
    }

#pragma warning disable SA1402 // File may only contain a single class
    internal static class CharExtensions
#pragma warning restore SA1402 // File may only contain a single class
    {
        public static bool IsElementCharacter(this char tested)
        {
            return !tested.IsQuote() && !tested.IsSpace();
        }

        public static bool IsSpace(this char tested)
        {
            return tested == ' ';
        }

        public static bool IsQuote(this char tested)
        {
            return tested == '"';
        }
    }
}
