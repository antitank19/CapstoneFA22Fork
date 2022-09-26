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

builder.Logging.AddLoggerConfig();

builder.Services.AddApplicationService(config);

builder.Services.AddJwtAuthenticationService(config);

builder.Services.AddScopedService();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo { Title = "Management Api", Version = "v1" });
        c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
            Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });
        c.OperationFilter<SecurityRequirementsOperationFilter>();
    }
);

builder.Services.AddCors(o => o.AddPolicy("MyPolicy",
    corsPolicyBuilder =>
    {
        corsPolicyBuilder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    })
);

builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("Admin", policy => policy.RequireClaim("Admin"));
    o.AddPolicy("Manager", policy => policy.RequireClaim("Manager"));
    o.AddPolicy("Student", policy => policy.RequireClaim("Student"));
});

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

app.ConfigMiddleware();

app.MapControllers();

app.Run();