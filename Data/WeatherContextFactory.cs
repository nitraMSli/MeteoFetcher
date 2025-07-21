using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MeteoFetcher.Data
{
    public class WeatherContextFactory : IDesignTimeDbContextFactory<WeatherContext>
    {
        public WeatherContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WeatherContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MeteoDB;Trusted_Connection=True;TrustServerCertificate=True;");
            return new WeatherContext(optionsBuilder.Options);
        }
    }
}
