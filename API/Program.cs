using Microsoft.AspNetCore.OData;
using Utilities.MiddlewareExtension;
using Utilities.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);

//AddExpenseHistory odata to api
builder.Services.AddControllers(
//    options =>
//{
//    IEnumerable<ODataOutputFormatter> outputFormatters =
//        options.OutputFormatters.OfType<ODataOutputFormatter>()
//            .Where(foramtter => foramtter.SupportedMediaTypes.Count == 0);

//    foreach (var outputFormatter in outputFormatters)
//    {
//        outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/odata"));
//    }

//}
    )
    .AddOData(o => o.EnableQueryFeatures());
//.AddNewtonsoftJson(options =>
//{
//    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
//    options.UseCamelCasing(true);
//    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
//});
//.AddJsonOptions(options =>
//{
//    options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
//    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

//})
//o.Select().Filter().Count().OrderBy().Expand());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var config = builder.Configuration;

builder.Services.AddRegisteredService(config);

builder.Logging.AddLoggerConfig();

builder.Services.AddApplicationService(config);

builder.Services.AddJwtAuthenticationService(config);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerService();

builder.Services.AddCustomCorsService();

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

app.UseCustomCorsService();

app.ConfigMiddleware(config);

app.MapControllers();

app.Run();