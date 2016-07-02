using System;
using System.Collections.Generic;
using System.Linq;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="newItems"></param>
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> newItems)
        {
            if (collection == null) { throw new ArgumentNullException(nameof(collection)); }
            if (newItems == null) { throw new ArgumentNullException(nameof(newItems)); }

            foreach (T item in newItems)
            {
                collection.Add(item);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static string ElementsDelimitedBySpace(this IEnumerable<string> elements)
        {
            var quotedElements = elements.Select(
                element => element.Contains(" ") ? "\"" + element + "\"" : element);

            return string.Join(" ", quotedElements);
        }
    }
}
