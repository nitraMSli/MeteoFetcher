using Microsoft.EntityFrameworkCore;
using MeteoFetcher.Models;

namespace MeteoFetcher.Data
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options) { }

        public DbSet<WeatherRecord> WeatherRecords { get; set; }
    }
}
