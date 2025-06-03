using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp.OpenWeather.Data
{
    internal class OpenWeather_US_Cities
    {
        public static Dictionary<string, List<string>> usCities = new Dictionary<string, List<string>>();

        [JsonProperty("id")] public string id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("state")] public string State { get; set; }

        [JsonProperty("country")] public string Country { get; set; }

        [JsonProperty("coord")] public Coordinates Coord { get; set; }

        public class Coordinates
        {
            [JsonProperty("lat")] public double Latitude { get; set; }
            [JsonProperty("lon")] public double Longitude { get; set; }
        }

        [OnDeserialized]
        private void Get_US_Cities(StreamingContext context)
        {
            {
                if (!usCities.ContainsKey(State))
                {
                    usCities[State] = new List<string>();
                }
                usCities[State].Add(Name);
            }
        }

    }
}
