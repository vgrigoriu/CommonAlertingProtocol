using System.Collections.Generic;
using System.Linq;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public static class RestrictedCharactersExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly IEnumerable<char> RestrictedCharacters =
                                               new[] { ' ', ',', '<', '&' };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool DoesNotContainsRestrictedChars(this string str)
        {
            // in PCL, string implements only IEnumerable, not IEnumerable<char>
            // https://stackoverflow.com/questions/11557690/
            var chars = str.Cast<char>();
            return !RestrictedCharacters.Any(chars.Contains);
        }
    }
}
