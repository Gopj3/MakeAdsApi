using System;

namespace MakeAdsApi.Application.Common.Dtos;

public abstract record BaseDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
};