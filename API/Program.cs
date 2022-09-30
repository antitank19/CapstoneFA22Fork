using Microsoft.AspNetCore.OData;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Utilities.MiddlewareExtension;
using Utilities.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*
builder.Services.AddControllers();
*/
//Add odata to api
builder.Services.AddControllers()
    .AddOData(o=>o.EnableQueryFeatures());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var config = builder.Configuration;

builder.Services.AddRegisteredService(config);

builder.Logging.AddLoggerConfig();

builder.Services.AddApplicationService(config);

builder.Services.AddJwtAuthenticationService(config);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerService();
   
builder.Services.AddCorsService();

builder.Services.AddAuthorizationService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.ConfigMiddleware(config);

app.MapControllers();

app.Run();