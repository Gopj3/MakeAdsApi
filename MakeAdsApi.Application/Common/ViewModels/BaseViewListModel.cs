using System.Collections.Generic;

namespace MakeAdsApi.Application.Common.ViewModels;

public record BaseViewListModel<TViewModel> where TViewModel : BaseViewModel
{
    public int TotalCount { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public bool HasNextPage { get; set; }
    public bool HasPreviousPage { get; set; }
    public IEnumerable<TViewModel> Items { get; set; }
}