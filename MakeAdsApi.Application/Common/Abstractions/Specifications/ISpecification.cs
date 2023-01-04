using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MakeAdsApi.Application.Common.Abstractions.Specifications;

public class ISpecification<T> where T: class
{
    Expression<Func<T, bool>> Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get; }
    Expression<Func<T, object>> OrderBy { get; }
    Expression<Func<T, object>> OrderByDescending { get; }
}