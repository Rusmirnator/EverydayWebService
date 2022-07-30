using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everyday.Core.Shared
{
    public static class GeneralPurposeExtensions
    {
        /// <summary>
        /// Performs given action on every element of source synchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IEnumerable<T> Map<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T item in source)
            {
                action.Invoke(item);
            }
            return source;
        }

        /// <summary>
        /// Performs given action on every element of source asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> MapAsync<T>(this IEnumerable<T> source, Action<T> action)
        {
            await Task.Run(() =>
            {
                source.Map(action);
            });

            return await Task.FromResult(source);
        }
    }
}
