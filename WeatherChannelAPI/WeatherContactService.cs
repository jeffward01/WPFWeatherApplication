using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeatherChannelAPI
{
    public class WeatherChannelService
    {
        public static WeatherResult GetWeatherFor(string input)
        {
            using (WebClient webClient = new WebClient())
            {
                //Grab userInformation file from Github
                string json = webClient.DownloadString("https://api.wunderground.com/21e1dadd00a6746a/conditions/" + input + ".json");

                //Instatize UserInforamtion
                WeatherResult myWeather = new WeatherResult();

                //Convert JSON to user-able variables
                JObject o = JObject.Parse(json);

                myWeather.CityState = o["current_observation"]["display_location"]["full"].ToString();
                myWeather.Latitude = o["current_observation"]["display_location"]["latitude"].ToString();
                myWeather.Longitude = o["current_observation"]["display_location"]["longitude"].ToString();
                myWeather.CurrentWeather = o["current_observation"]["observation_location"]["weather"].ToString();
                myWeather.Elevation = o["current_observation"]["display_location"]["full"].ToString();
                myWeather.LastUpdated = o["current_observation"]["display_location"]["full"].ToString();
                myWeather.Temperature = o["current_observation"]["display_location"]["temperature_string"].ToString();
                myWeather.FeelsLike = o["current_observation"]["estimated"]["feelslike_string"].ToString();
                myWeather.Wind = o["current_observation"]["observation_location"]["wind_string"].ToString();
                myWeather.WindDirection = o["current_observation"]["display_location"]["temperature_string"].ToString();
                myWeather.WindSpeed = o["current_observation"]["observation_location"]["wind_mph"].ToString();
                myWeather.Humidity = o["current_observation"]["observation_location"]["relative_humidity"].ToString();
                myWeather.Visibility = o["current_observation"]["observation_location"]["visibility_mi"].ToString();
                myWeather.UV = o["current_observation"]["UV"].ToString();
                myWeather.Precipitation = o["current_observation"]["observation_location"]["precip_today_string"].ToString();

                //

                return myWeather;
            }
        }
    }
}
