using Hangfire;
using MakeAdsApi.Api;
using MakeAdsApi.Api.Common;
using MakeAdsApi.Api.Configurations;
using MakeAdsApi.Api.Middlewares;
using MakeAdsApi.Application;
using MakeAdsApi.Application.Common.Abstractions.Jobs;
using MakeAdsApi.Infrastructure;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers(options =>
    {
        options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
    });
    builder.Services.AddSwaggerGen();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddRouting();

    builder.Services.AddApi();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddApplication();
    builder.Services.ConfigureJwtBearer(builder.Configuration);

    builder.Services.AddDbContext<MakeAdsDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("MakeAdsDb")!));
}

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(options =>
    {
        options
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin(); // for dev purposes
    });
}

{
    app.UseMiddleware<ExceptionHandlingMiddleware>();
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.UseCors();
    app.UseHangfireDashboard();
    
    RecurringJob.AddOrUpdate<IUpdatePreSignedUrlsService>(
        x => x.UpdatePreSignedUrlsAsync(CancellationToken.None
        ), Cron.Daily);
    app.Run();
}
