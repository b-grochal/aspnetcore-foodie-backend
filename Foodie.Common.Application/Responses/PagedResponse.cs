using System.Collections.Generic;

namespace Foodie.Common.Application.Responses
{
    public abstract class PagedResponse<TResult>
    {
        public IEnumerable<TResult> Items { get; set; }
        public int Page { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious => Page > 1;
        public bool HasNext => Page < TotalPages;
    }
}
