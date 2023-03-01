using AutoMapper;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Domain.Entities;

namespace MakeAdsApi.Application.Mappers.Extensions;

public static class IgnoreUpdatedAtExtension
{
    public static IMappingExpression<TSource, TDest> IgnoreUpdatedAt<TSource, TDest>(
        this IMappingExpression<TSource, TDest> expression)
        where TDest : BaseViewModel
        where TSource : BaseEntity
    {
        expression.ForMember(
            x => x.UpdatedAt,
            act => act.Ignore()
        );

        return expression;
    }
}