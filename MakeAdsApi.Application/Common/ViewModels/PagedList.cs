using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MakeAdsApi.Application.Common.ViewModels;

public class PagedList<T> : List<T>
    where T : class
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;

    public PagedList(List<T> items, int count, int pageNumber, int pageSize)
    {
        TotalCount = count;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);

        AddRange(items);
    }

    public static async Task<PagedList<T>> ToPagedListAsync(IQueryable<T> source, int pageNumber, int pageSize,
        CancellationToken cancellationToken = default)
    {
        var count = await source.CountAsync(cancellationToken);
        List<T> items = await source.Skip((pageNumber) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

        return new PagedList<T>(items, count, pageNumber, pageSize);
    }
}