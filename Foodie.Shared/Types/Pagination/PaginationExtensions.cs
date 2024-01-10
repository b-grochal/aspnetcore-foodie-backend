using System.Linq;

namespace Foodie.Shared.Types.Pagination
{
    public static class PaginationExtensions
    {
        //public static PagedResult<T> Paginate<T>(this IQueryable<T> source, int pageNumber, int pageSize)
        //{
        //    return new PagedResult<T>
        //    {
        //        TotalCount = source.Count(),
        //        Items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList()
        //    };
        //}
    }
}
