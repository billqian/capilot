using Serilog;
using Syntop.Pilot.Application;
using Syntop.Pilot.Infrastructure;
using Syntop.Pilot.Pesistence;
using Syntop.Pilot.WebApi;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddApplicationServices(config);
builder.Services.AddInfrastructureServices(config);
builder.Services.AddPesistenceServices(config);
builder.Services.AddWebApiServices(config);

builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((context, configuration) => {
    configuration.ReadFrom.Configuration(context.Configuration);
});

var app = builder.Build();

if (app.Environment.IsDevelopment()) {

    var docPrefix = "api";
    app.UseSwagger(option => {
        option.RouteTemplate = $"{docPrefix}/" + "{documentName}/swagger.json";

    });
    app.UseSwaggerUI(option => {
        option.SwaggerEndpoint($"/{docPrefix}/v1/swagger.json", "API");
        option.RoutePrefix = docPrefix;
    });

    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();

    // Initialise and seed database
    using (var scope = app.Services.CreateScope()) {
        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
        await initialiser.InitialiseAsync();
        await initialiser.SeedAsync();
    }
}
app.UseSerilogRequestLogging();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapFallbackToFile("index.html");

app.UseAuthorization();

app.MapControllers();


app.Run();
