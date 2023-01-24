namespace MakeAdsApi.Application.Statistics.Admin.Models;

public record CountStatisticsModelView(
    int UsersCount,
    int OfficesCount,
    int AdsCount
);