namespace MeteoFetcher.Models
{
    public class WeatherRecord
    {
        public int Id { get; set; }
        public DateTime DownloadedAt { get; set; }
        public string? JsonData { get; set; }
        public bool IsSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
