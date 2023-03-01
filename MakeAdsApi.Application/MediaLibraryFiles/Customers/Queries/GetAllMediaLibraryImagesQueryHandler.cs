using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ErrorOr;
using MakeAdsApi.Application.Common.Abstractions.Repositories;
using MakeAdsApi.Application.MediaLibraryFiles.Shared.Models;
using MediatR;

namespace MakeAdsApi.Application.MediaLibraryFiles.Customers.Queries;

public class GetAllMediaLibraryImagesQueryHandler :
    IRequestHandler<GetAllMediaLibraryImagesQuery, ErrorOr<List<MediaLibraryImageViewModel>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllMediaLibraryImagesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<List<MediaLibraryImageViewModel>>> Handle(
        GetAllMediaLibraryImagesQuery request,
        CancellationToken cancellationToken
    )
    {
        var images = await _unitOfWork.MediaLibraryImageRepository.GetByExpressionAsync(
            x => x.PropertyId == request.PropertyId && (x.UserId == request.UserId || x.UserId == null),
            cancellationToken
        );

        return _mapper.Map<List<MediaLibraryImageViewModel>>(images);
    }
}