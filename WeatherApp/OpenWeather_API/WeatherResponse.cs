using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.OpenWeather_API
{
    internal class WeatherResponse
    {
        [JsonProperty("main")] public Main main { get; set; }
        public class Main
            {
                [JsonProperty("temp")] public double Temp { get; set; }

                [JsonProperty("feels_like")] public double Feels_Like { get; set; }

                [JsonProperty("temp_min")] public double Temp_Min { get; set; }

                [JsonProperty("temp_max")] public double Temp_Max { get; set; }

                [JsonProperty("pressure")] public int Pressure { get; set; }

                [JsonProperty("humidity")] public int Humidity { get; set; }
            }

    }
}
