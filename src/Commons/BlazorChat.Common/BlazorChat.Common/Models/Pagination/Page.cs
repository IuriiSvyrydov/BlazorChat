using System.Runtime.CompilerServices;

namespace BlazorChat.Common.Models.Pagination;

public class Page
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalRowCount { get; set; }
    public int TotalCount => (int)Math.Ceiling((double)TotalRowCount / PageSize);
    public int Skip => (CurrentPage - 1) * PageSize;

    public Page(): this(0)
    {
        
    }

    public Page(int totalCount):this(1,10,totalCount)
    {
        
    }

    public Page(int pageSize, int totalRowCount): this(1,pageSize,totalRowCount)
    {
        
    }

    public Page(int currentPage,int pageSize,int totalRowCount){
        if (currentPage<1)
        {
            throw new ArgumentException("Invalid page number");
        }
        if (pageSize < 1)
        {
            throw new ArgumentException("Invalid page size");
        }

        TotalRowCount = totalRowCount;
        CurrentPage = currentPage;
        PageSize = pageSize;
    }
}