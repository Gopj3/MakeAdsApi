using System;
using System.Collections.Generic;
using ErrorOr;
using MakeAdsApi.Application.MediaLibraryFiles.Shared.Models;
using MediatR;

namespace MakeAdsApi.Application.MediaLibraryFiles.Customers.Queries;

public record GetAllMediaLibraryImagesQuery(
    Guid PropertyId,
    Guid UserId
) : IRequest<ErrorOr<List<MediaLibraryImageViewModel>>>;
