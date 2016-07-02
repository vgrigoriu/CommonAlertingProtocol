using System.Collections.Generic;
using System.Text;

namespace CAPNet
{
    /// <summary>
    ///
    /// </summary>
    public static class SpaceDelimitedElementsParser
    {
#pragma warning disable S1450 // Private fields only used as local variables in methods should become local variables
        // Looks like we could remove this and replace it with a parameter / return value. This should also
        // fix the if / else if constructions below.
        private static States currentState;
#pragma warning restore S1450 // Private fields only used as local variables in methods should become local variables
        private static StringBuilder partialElement;
        private static int currentPosition;
        private static List<string> elements;
        private static string representation;

        private enum States
        {
            BETWEEN_ELEMENTS = 0,
            IN_SPACE_CONTAINING_ELEMENTS = 1,
            IN_ELEMENTS_WITH_NO_SPACE = 2
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value">Multiple space-delimited elements MAY be included.
        /// Elements including whitespace MUST be enclosed in double-quotes.</param>
        /// <returns>Elements in a IEnumerable&lt;string></returns>
        public static IEnumerable<string> GetElements(this string value)
        {
            representation = value;
            elements = new List<string>();
            partialElement = new StringBuilder();
            currentState = States.BETWEEN_ELEMENTS;

            for (currentPosition = 0; currentPosition < representation.Length; currentPosition++)
            {
                char currentChar = representation[currentPosition];
                switch (currentState)
                {
                    case States.BETWEEN_ELEMENTS:
                        BetweenElementsState(currentChar);
                        break;

                    case States.IN_ELEMENTS_WITH_NO_SPACE:
                        InAddressWithNoSpaceState(currentChar);
                        break;

                    case States.IN_SPACE_CONTAINING_ELEMENTS:
                        InSpaceContainingAddressState(currentChar);
                        break;
                    default:
                        throw new SpaceDelimitedElementsParserException($"Invalid parser state: {currentState}");
                }
            }

            return elements;
        }

        private static void InSpaceContainingAddressState(char currentChar)
        {
            if (currentChar.IsElementCharacterOrSpace())
            {
                partialElement.Append(currentChar);
                if (currentPosition == representation.Length - 1)
                {
                    elements.Add(partialElement.ToString());
                }
            }
#pragma warning disable S126 // "if ... else if" constructs should end with "else" clause
            else if (currentChar.IsQuote())
#pragma warning restore S126 // "if ... else if" constructs should end with "else" clause
            {
                elements.Add(partialElement.ToString());
                partialElement.Clear();
                currentState = States.BETWEEN_ELEMENTS;
            }
        }

        private static void InAddressWithNoSpaceState(char currentChar)
        {
            if (currentChar.IsElementCharacter())
            {
                partialElement.Append(currentChar);
                if (currentPosition == representation.Length - 1)
                {
                    elements.Add(partialElement.ToString());
                }
            }
#pragma warning disable S126 // "if ... else if" constructs should end with "else" clause
            else if (currentChar.IsSpace())
#pragma warning restore S126 // "if ... else if" constructs should end with "else" clause
            {
                elements.Add(partialElement.ToString());
                partialElement.Clear();
                currentState = States.BETWEEN_ELEMENTS;
            }
        }

        private static void BetweenElementsState(char currentChar)
        {
            if (currentChar.IsQuote())
            {
                currentState = States.IN_SPACE_CONTAINING_ELEMENTS;
            }
#pragma warning disable S126 // "if ... else if" constructs should end with "else" clause
            else if (currentChar.IsElementCharacter())
#pragma warning restore S126 // "if ... else if" constructs should end with "else" clause
            {
                currentState = States.IN_ELEMENTS_WITH_NO_SPACE;
                partialElement.Append(currentChar);
                if (currentPosition == representation.Length - 1)
                {
                    elements.Add(partialElement.ToString());
                }
            }
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

        private static bool IsElementCharacterOrSpace(this char tested)
        {
            return tested.IsElementCharacter() || tested.IsSpace();
        }
    }
}
