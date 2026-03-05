namespace app.Models;

public class PaginationResult<T>
{
    public List<T> Items { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }

    public PaginationResult()
    {
        Items = new List<T>();
    }

    public bool HasPreviousPage => CurrentPage > 1;
    public bool HasNextPage => CurrentPage < TotalPages;
}
