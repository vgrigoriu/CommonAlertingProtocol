using System.Collections.Generic;
using System.Text;

namespace CAPNet
{
    /// <summary>
    /// This class parses a string containing space-delimited elements, e.g.
    /// «one two "three four"» will be splited into «one», «two», and «three four».
    /// </summary>
    public static class SpaceDelimitedElementsParser
    {
        private static StringBuilder partialElement;
        private static int currentPosition;
        private static List<string> elements;
        private static string representation;

        /// <summary>
        /// Multiple space-delimited elements MAY be included.
        /// Elements including whitespace MUST be enclosed in double-quotes.
        ///
        /// See the tests for examples.
        /// </summary>
        /// <param name="value">the string to parse</param>
        /// <returns>Elements in a IEnumerable&lt;string></returns>
        public static IEnumerable<string> GetElements(this string value)
        {
            representation = value;
            elements = new List<string>();
            partialElement = new StringBuilder();
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

        private static States InSpaceContainingAddressState(States currentState, char currentChar)
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

        private static States InAddressWithNoSpaceState(States currentState, char currentChar)
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

        private static States BetweenElementsState(States currentState, char currentChar)
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

        private static bool IsElementCharacter(this char tested)
        {
            return !tested.IsQuote() && !tested.IsSpace();
        }

        private static bool IsSpace(this char tested)
        {
            return tested == ' ';
        }

        private static bool IsQuote(this char tested)
        {
            return tested == '"';
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
}
