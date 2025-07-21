using MeteoFetcher.Data;
using MeteoFetcher.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace MeteoFetcher.Services
{
    public class WeatherService
    {
        private readonly IConfiguration _config;
        private readonly WeatherContext _db;

        public WeatherService(IConfiguration config, WeatherContext db)
        {
            _config = config;
            _db = db;
        }

        public async Task DownloadAndSaveAsync()
        {
            var record = new WeatherRecord { DownloadedAt = DateTime.Now };
            string? url = _config["Weather:Url"];

            if (string.IsNullOrWhiteSpace(url))
            {
                record.IsSuccessful = false;
                record.ErrorMessage = "Weather URL is missing in configuration.";
                _db.WeatherRecords.Add(record);
                await _db.SaveChangesAsync();
                Console.WriteLine("Weather URL not configured. Record saved with error.");
                return;
            }

            try
            {
                using var client = new HttpClient();
                string xml = await client.GetStringAsync(url);

                var doc = new XmlDocument();
                doc.LoadXml(xml);

                string json = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
                record.JsonData = json;
                record.IsSuccessful = true;

                Console.WriteLine("Data fetched and converted to JSON.");
            }
            catch (Exception ex)
            {
                record.IsSuccessful = false;
                record.ErrorMessage = ex.Message;
                Console.WriteLine($"Error: {ex.Message}");
            }

            _db.WeatherRecords.Add(record);
            await _db.SaveChangesAsync();
            Console.WriteLine("Record saved to DB.");
        }

    }
}
