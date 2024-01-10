namespace Foodie.Common.Application.Queries
{
    public abstract class PagedQuery
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
