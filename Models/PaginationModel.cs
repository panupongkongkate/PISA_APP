namespace PISA_APP.Models;

public class PaginationModel
{
    public int CurrentPage { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public int TotalItems { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
    public int StartItem => TotalItems == 0 ? 0 : (CurrentPage - 1) * PageSize + 1;
    public int EndItem => Math.Min(CurrentPage * PageSize, TotalItems);

    public static readonly int[] PageSizeOptions = { 5, 10, 25, 50, 100 };

    public List<int> GetPageNumbers()
    {
        var pages = new List<int>();
        int start = Math.Max(1, CurrentPage - 2);
        int end = Math.Min(TotalPages, CurrentPage + 2);

        if (start > 1)
        {
            pages.Add(1);
            if (start > 2)
                pages.Add(-1); // Represents ellipsis
        }

        for (int i = start; i <= end; i++)
        {
            pages.Add(i);
        }

        if (end < TotalPages)
        {
            if (end < TotalPages - 1)
                pages.Add(-1); // Represents ellipsis
            pages.Add(TotalPages);
        }

        return pages;
    }
}