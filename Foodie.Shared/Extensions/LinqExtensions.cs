using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Shared.Extensions
{
    public static class LinqExtensions
    {
        public static ICollection<T> AddIfNotExists<T>(this ICollection<T> list, IEnumerable<T> items)
        {
            foreach(T item in items)
            {
                if(!list.Contains(item))
                    list.Add(item);
            }
            return list;
        }
    }
}
