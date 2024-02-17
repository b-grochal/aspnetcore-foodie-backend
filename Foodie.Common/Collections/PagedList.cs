using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Foodie.Common.Collections
{
    public class PagedList<T>
    {
        public List<T> Items { get; }

        public int Page { get; }

        public int PageSize { get; }

        public int TotalCount { get; }

        public int TotalPages { get; }

        public bool HasNextPage => Page * PageSize < TotalCount;

        public bool HasPreviousPage => Page > 1;

        [JsonConstructor]
        public PagedList(List<T> items, int page, int pageSize, int totalCount)
        {
            Items = items;
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        }

        public static PagedList<T> Create(IQueryable<T> query, int page, int pageSize)
        {
            var totalCount = query.Count();
            var items = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return new(items, page, pageSize, totalCount);
        }

        public static PagedList<T> Create(IEnumerable<T> query, int page, int pageSize)
        {
            var totalCount = query.Count();
            var items = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return new(items, page, pageSize, totalCount);
        }
    }
}
