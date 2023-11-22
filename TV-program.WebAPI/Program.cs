using TV_program.Service.IoC;
using TV_program.Service.Settings;

var configuration = new ConfigurationBuilder()
.AddJsonFile("appsettings.json", optional: false)
.Build();

var settings = TV_programSettingsReader.Read(configuration);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

DbContextConfigurator.ConfigureService(builder.Services, settings);
SerilogConfigurator.ConfigureService(builder);
SwaggerConfigurator.ConfigureServices(builder.Services);

var app = builder.Build();

SerilogConfigurator.ConfigureApplication(app);
SwaggerConfigurator.ConfigureApplication(app);
DbContextConfigurator.ConfigureApplication(app);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
