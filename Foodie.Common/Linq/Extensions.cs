using Foodie.Common.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Foodie.Common.Extensions
{
    public static class Extensions
    {
        // TODO: Remove the method, assign new values insted
        public static ICollection<T> Merge<T>(this ICollection<T> list, IEnumerable<T> items)
        {
            list.Clear();

            foreach (var item in items)
                list.Add(item);

            return list;
        }

        public static PagedList<T> Paginate<T>(this IQueryable<T> queryable, int page, int pageSize)
        {
            return PagedList<T>.Create(queryable, page, pageSize);
        }
    }
}
