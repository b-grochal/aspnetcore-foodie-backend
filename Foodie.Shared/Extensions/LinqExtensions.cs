using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Shared.Extensions
{
    public static class LinqExtensions
    {
        public static ICollection<T> Merge<T>(this ICollection<T> list, IEnumerable<T> items)
        {
            list.Clear();

            foreach (var item in items)
                list.Add(item);

            return list;
        }
    }
}
