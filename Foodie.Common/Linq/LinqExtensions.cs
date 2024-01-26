using System.Collections.Generic;

namespace Foodie.Common.Extensions
{
    public static class LinqExtensions
    {
        // TODO: Remove the method, assign new values insted
        public static ICollection<T> Merge<T>(this ICollection<T> list, IEnumerable<T> items)
        {
            list.Clear();

            foreach (var item in items)
                list.Add(item);

            return list;
        }
    }
}
