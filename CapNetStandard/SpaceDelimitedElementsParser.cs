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

        private void AddCurrentElementToList()
        {
            elements.Add(partialElement.ToString());
            partialElement.Clear();
        }

        private void AddToCurrentElement(char currentChar)
        {
            partialElement.Append(currentChar);
            if (currentPosition == representation.Length - 1)
            {
                elements.Add(partialElement.ToString());
            }
        }

        private abstract class States : Enumeration<States>
        {
#pragma warning disable SA1310 // Field names must not contain underscore
            public static readonly States BETWEEN_ELEMENTS = new BetweenElements();
            public static readonly States IN_SPACE_CONTAINING_ELEMENTS = new InSpaceContainingElement();
            public static readonly States IN_ELEMENTS_WITH_NO_SPACE = new InElementWithNoSpace();
#pragma warning restore SA1310 // Field names must not contain underscore

            private States(int value, string displayName)
                : base(value, displayName)
            {
            }

            public abstract States OnSpace(SpaceDelimitedElementsParser parser, char currentChar);

            public abstract States OnQuote(SpaceDelimitedElementsParser parser);

            public abstract States OnOtherCharacter(SpaceDelimitedElementsParser parser, char currentChar);

            private class BetweenElements : States
            {
                public BetweenElements()
                    : base(0, "Between elements")
                {
                }

                public override States OnOtherCharacter(SpaceDelimitedElementsParser parser, char currentChar)
                {
                    parser.AddToCurrentElement(currentChar);

                    return IN_ELEMENTS_WITH_NO_SPACE;
                }

                public override States OnQuote(SpaceDelimitedElementsParser parser)
                {
                    return IN_SPACE_CONTAINING_ELEMENTS;
                }

                public override States OnSpace(SpaceDelimitedElementsParser parser, char currentChar)
                {
                    // we're still between elements
                    return this;
                }
            }

            private class InSpaceContainingElement : States
            {
                public InSpaceContainingElement()
                    : base(1, "In space containing element")
                {
                }

                public override States OnOtherCharacter(SpaceDelimitedElementsParser parser, char currentChar)
                {
                    parser.AddToCurrentElement(currentChar);
                    return this;
                }

                public override States OnQuote(SpaceDelimitedElementsParser parser)
                {
                    parser.AddCurrentElementToList();
                    return BETWEEN_ELEMENTS;
                }

                public override States OnSpace(SpaceDelimitedElementsParser parser, char currentChar)
                {
                    parser.AddToCurrentElement(currentChar);
                    return this;
                }
            }

            private class InElementWithNoSpace : States
            {
                public InElementWithNoSpace()
                    : base(2, "In element with no space")
                {
                }

                public override States OnOtherCharacter(SpaceDelimitedElementsParser parser, char currentChar)
                {
                    parser.AddToCurrentElement(currentChar);
                    return this;
                }

                public override States OnQuote(SpaceDelimitedElementsParser parser)
                {
                    // this is an opening quote without a preceding space
                    return this;
                }

                public override States OnSpace(SpaceDelimitedElementsParser parser, char currentChar)
                {
                    parser.AddCurrentElementToList();
                    return BETWEEN_ELEMENTS;
                }
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
