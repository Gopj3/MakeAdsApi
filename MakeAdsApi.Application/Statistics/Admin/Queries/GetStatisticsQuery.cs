using ErrorOr;
using MakeAdsApi.Application.Statistics.Admin.Models;
using MediatR;

namespace MakeAdsApi.Application.Statistics.Admin.Queries;

public record GetStatisticsQuery() : IRequest<ErrorOr<StatisticsModelView>>;
