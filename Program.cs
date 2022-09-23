using apicampaign.Helpers;
using apicampaign.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;

// var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
// logger.Debug("init main");
// try
// {
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

// NLog: Setup NLog for Dependency injection
//builder.Logging.ClearProviders();
builder.Host.UseNLog();

//builder.Services.AddDbContext<onlinecampaignContext>(opt => opt.UseInMemoryDatabase("ONLINECAMPAIGN"));
builder.Services.AddDbContext<onlinecampaignContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CampaignDbConnectionString")));
// api versioning
builder.Services.AddApiVersioning(opt =>
                                    {
                                        opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                                        opt.AssumeDefaultVersionWhenUnspecified = true;
                                        opt.ReportApiVersions = true;
                                        opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                                                        new HeaderApiVersionReader("x-api-version"),
                                                                                        new MediaTypeApiVersionReader("x-api-version"));
                                    });
// Add ApiExplorer to discover versions
builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentityServer()
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApis())
                .AddInMemoryClients(Config.GetClients());

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

var app = builder.Build();
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseDeveloperExceptionPage();
    // app.UseSwagger();
    // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi v1"));
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<NLog.Web.NLogRequestPostedBodyMiddleware>();

app.Run();
// }
// catch (Exception exception)
// {
//     // NLog: catch setup errors
//     logger.Error(exception, "Stopped program because of exception");
//     throw;
// }
// finally
// {
//     // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
//     NLog.LogManager.Shutdown();
// }
