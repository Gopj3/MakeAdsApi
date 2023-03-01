using System;
using ErrorOr;
using MakeAdsApi.Application.Properties.Models;
using MediatR;

namespace MakeAdsApi.Application.Properties.Commands;

public record RegisterPropertyCommand(
    string PropertyId,
    string Address,
    Guid UserId
) : IRequest<ErrorOr<PropertyViewModel>>;