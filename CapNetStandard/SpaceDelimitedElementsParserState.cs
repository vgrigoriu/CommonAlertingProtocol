namespace CAPNet
{
    internal abstract class SpaceDelimitedElementsParserState : Enumeration<SpaceDelimitedElementsParserState>
    {
#pragma warning disable SA1310 // Field names must not contain underscore
        public static readonly SpaceDelimitedElementsParserState BETWEEN_ELEMENTS = new BetweenElements();
        public static readonly SpaceDelimitedElementsParserState IN_SPACE_CONTAINING_ELEMENTS = new InSpaceContainingElement();
        public static readonly SpaceDelimitedElementsParserState IN_ELEMENTS_WITH_NO_SPACE = new InElementWithNoSpace();
#pragma warning restore SA1310 // Field names must not contain underscore

        private SpaceDelimitedElementsParserState(int value, string displayName)
            : base(value, displayName)
        {
        }

        public abstract SpaceDelimitedElementsParserState OnSpace(SpaceDelimitedElementsParser parser, char currentChar);

        public abstract SpaceDelimitedElementsParserState OnQuote(SpaceDelimitedElementsParser parser);

        public abstract SpaceDelimitedElementsParserState OnOtherCharacter(SpaceDelimitedElementsParser parser, char currentChar);

        private class BetweenElements : SpaceDelimitedElementsParserState
        {
            public BetweenElements()
                : base(0, "Between elements")
            {
            }

            public override SpaceDelimitedElementsParserState OnOtherCharacter(SpaceDelimitedElementsParser parser, char currentChar)
            {
                parser.AddToCurrentElement(currentChar);

                return IN_ELEMENTS_WITH_NO_SPACE;
            }

            public override SpaceDelimitedElementsParserState OnQuote(SpaceDelimitedElementsParser parser)
            {
                return IN_SPACE_CONTAINING_ELEMENTS;
            }

            public override SpaceDelimitedElementsParserState OnSpace(SpaceDelimitedElementsParser parser, char currentChar)
            {
                // we're still between elements
                return this;
            }
        }

        private class InSpaceContainingElement : SpaceDelimitedElementsParserState
        {
            public InSpaceContainingElement()
                : base(1, "In space containing element")
            {
            }

            public override SpaceDelimitedElementsParserState OnOtherCharacter(SpaceDelimitedElementsParser parser, char currentChar)
            {
                parser.AddToCurrentElement(currentChar);
                return this;
            }

            public override SpaceDelimitedElementsParserState OnQuote(SpaceDelimitedElementsParser parser)
            {
                parser.AddCurrentElementToList();
                return BETWEEN_ELEMENTS;
            }

            public override SpaceDelimitedElementsParserState OnSpace(SpaceDelimitedElementsParser parser, char currentChar)
            {
                parser.AddToCurrentElement(currentChar);
                return this;
            }
        }

        private class InElementWithNoSpace : SpaceDelimitedElementsParserState
        {
            public InElementWithNoSpace()
                : base(2, "In element with no space")
            {
            }

            public override SpaceDelimitedElementsParserState OnOtherCharacter(SpaceDelimitedElementsParser parser, char currentChar)
            {
                parser.AddToCurrentElement(currentChar);
                return this;
            }

            public override SpaceDelimitedElementsParserState OnQuote(SpaceDelimitedElementsParser parser)
            {
                // this is an opening quote without a preceding space
                return this;
            }

            public override SpaceDelimitedElementsParserState OnSpace(SpaceDelimitedElementsParser parser, char currentChar)
            {
                parser.AddCurrentElementToList();
                return BETWEEN_ELEMENTS;
            }
        }
    }
}
