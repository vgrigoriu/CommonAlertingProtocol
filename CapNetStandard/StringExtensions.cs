using System.Collections.Generic;

namespace CAPNet
{
    public static class StringExtensions
    {
        public static IEnumerable<string> GetElements(this string representation)
        {
            return new SpaceDelimitedElementsParser(representation).GetElements();
        }
    }
}
