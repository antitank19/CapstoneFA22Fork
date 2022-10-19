using Microsoft.AspNetCore.OData;
using Utilities.MiddlewareExtension;
using Utilities.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);


//AddExpenseHistory odata to api
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var config = builder.Configuration;

builder.Services.AddRegisteredService(config);

builder.Services.AddCors(o =>
{
    o.AddPolicy(name: "AllowAnyOrigin", corsPolicyBuilder =>
    {
        corsPolicyBuilder
            .WithOrigins(config.GetValue<string>("Cors:AllowedOrigins"))
            .SetIsOriginAllowed(x => _ = true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

builder.Logging.AddLoggerConfig();

builder.Services.AddApplicationService(config);

builder.Services.AddJwtAuthenticationService(config);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerService();

//builder.Services.AddCustomCorsService();

builder.Services.AddAuthorizationService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAnyOrigin");

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.ConfigMiddleware(config);

app.MapControllers();

app.Run();