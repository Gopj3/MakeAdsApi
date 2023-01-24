using System.Threading;
using System.Threading.Tasks;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.Statistics.Admin.Models;
using MediatR;

namespace MakeAdsApi.Application.Statistics.Admin.Queries;

public class GetStatisticsQueryHandler : IRequestHandler<GetStatisticsQuery, ErrorOr<StatisticsModelView>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetStatisticsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<StatisticsModelView>> Handle(GetStatisticsQuery request,
        CancellationToken cancellationToken)
    {
        return new StatisticsModelView(
            new CountStatisticsModelView(
                UsersCount: await _unitOfWork.UserRepository.CountAsync(cancellationToken),
                OfficesCount: 0,
                AdsCount: 0
            )
        );
    }
}