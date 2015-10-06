using System.Windows.Controls;

namespace WeatherChannelAPI
{
    public class WeatherResult
    {
        public string CityState { get; set; }
        public string Latitude { get; internal set; }
        public string Longitude { get; set; }
        public string CurrentWeather { get; set; }
        public string Elevation { get; set; }
        public string LastUpdated { get; set; }
        public string Temperature { get; internal set; }
        public string FeelsLike { get; set; }
        public string Wind { get; set; }
        public string WindSpeed { get; set; }
        public string WindDirection { get; set; }
        public string Humidity { get; set; }
        public string Visibility { get; set; }
        public string UV { get; set; }
        public string Precipitation { get; set; }

        public string WeatherIconURL { get; set; }
        public string Icon { get; set; }

      
        // can't find icon that says "calm", etc. public string relative_humidity { get; set; }
    }
}