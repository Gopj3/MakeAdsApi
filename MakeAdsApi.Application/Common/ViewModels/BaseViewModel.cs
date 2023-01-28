using System;
using MakeAdsApi.Domain.Entities;

namespace MakeAdsApi.Application.Common.ViewModels;

public abstract class BaseViewModel
{
    public Guid Id { get; set; }
    public string CreatedAt { get; set; }
    public string UpdatedAt { get; set; }
}