using MakeAdsApi.Api;
using MakeAdsApi.Api.Middlewares;
using MakeAdsApi.Application;
using MakeAdsApi.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddSwaggerGen();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddRouting(options => options.LowercaseUrls = true);

    builder.Services.AddApi();
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);

    builder.Services.AddDbContext<MakeAdsDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("MakeAdsDb")!));
}

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

{
    app.UseMiddleware<ExceptionHandlingMiddleware>();
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.UseCors();

    app.Run();
}