namespace CourseGenerator.DAL.Pagination
{
    public interface IPagedList
    {
        int TotalPages { get; }
        int TotalCount { get; }
        int PageIndex { get; }
        int PageSize { get; }
        bool HavePreviousPage { get; }
        bool HaveNextPage { get; }
    }
}
