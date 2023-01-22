using System.Collections.Generic;

namespace MakeAdsApi.Application.Common.ViewModels;

public class BaseViewListModel<T> where T : BaseViewModel
{
    public int TotalCount { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public bool HasNextPage { get; set; }
    public bool HasPreviousPage { get; set; }
    public IEnumerable<T> Items { get; set; }
    
    public BaseViewListModel(
        IEnumerable<T> items,
        int totalCount,
        int page,
        int pageSize,
        bool hasNextPage,
        bool hasPreviousPage)
    {
        Items = items;
        TotalCount = totalCount;
        Page = page;
        PageSize = pageSize;
        HasNextPage = hasNextPage;
        HasPreviousPage = hasPreviousPage;
    }
}
