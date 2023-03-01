using AutoMapper;
using MakeAdsApi.Application.Common.ViewModels;
using MakeAdsApi.Domain.Entities;

namespace MakeAdsApi.Application.Mappers.Extensions;

public static class LongDateStringCreatedAtExtension
{
    public static IMappingExpression<TSource, TDest> CreatedAtToLongDateString<TSource, TDest>(
        this IMappingExpression<TSource, TDest> expression)
        where TDest : BaseViewModel
        where TSource : BaseEntity
    {
        expression.ForMember(
            x => x.CreatedAt,
            act => act.MapFrom(
                x => x.CreatedAt.ToLongDateString()
            )
        );

        return expression;
    }
}