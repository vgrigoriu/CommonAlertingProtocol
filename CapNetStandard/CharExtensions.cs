namespace CAPNet
{
    internal static class CharExtensions
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
