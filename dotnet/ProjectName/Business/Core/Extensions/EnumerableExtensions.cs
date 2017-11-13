using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectName.Business.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static T PickRandom<T>(this IEnumerable<T> source) => source.PickRandom(1).Single();
        public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count) => source.Shuffle().Take(count);
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source) => source.OrderBy(x => Guid.NewGuid());

        /// <summary>
        /// Convenience method so joining strings reads better :)
        /// </summary>
        /// <param name="list"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string Join(this IEnumerable<string> list, string delimiter = ", ")
        {
            return list?.ToList().Join(delimiter);
        }

        /// <summary>
        /// Convenience method for joining dictionary key values into a string
        /// </summary>
        /// <param name="list"></param>
        /// <param name="keyValueDelimiter"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string Join(this IEnumerable<KeyValuePair<string, string>> list, string keyValueDelimiter, string delimiter = ", ")
        {
            return list?.Select(e => e.Join(keyValueDelimiter)).Join(delimiter);
        }

        /// <summary>
        /// Convenience method so joining a list of strings
        /// </summary>
        /// <param name="list"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string Join(this List<string> list, string delimiter = ", ")
        {
            return list == null ? null : string.Join(delimiter, list);
        }

        /// <summary>
        /// Convenience method so joining key value pairs
        /// </summary>
        /// <param name="pair"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string Join(this KeyValuePair<string, string> pair, string delimiter)
        {
            var results = new List<string>
            {
                pair.Key,
                pair.Value
            };

            return results.Where(e => !string.IsNullOrEmpty(e)).Join(delimiter);
        }
    }
}
