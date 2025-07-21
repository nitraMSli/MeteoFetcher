using MeteoFetcher.Data;
using MeteoFetcher.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .AddEnvironmentVariables()
    .Build();

var optionsBuilder = new DbContextOptionsBuilder<WeatherContext>();
optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

using var db = new WeatherContext(optionsBuilder.Options);
db.Database.Migrate();

var weatherService = new WeatherService(config, db);

while (true)
{
    Console.WriteLine($"[{DateTime.Now}] Starting download...");
    await weatherService.DownloadAndSaveAsync();
    await Task.Delay(TimeSpan.FromHours(1));
}
