using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Shared.Types.Pagination
{
    public static class PaginationExtensions
    {
        public static IEnumerable<T> Paginate<T>(this IQueryable<T> source, int pageNumber, int pageSize)
        {
            return source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
