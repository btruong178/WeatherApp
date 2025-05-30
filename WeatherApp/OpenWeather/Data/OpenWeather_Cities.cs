using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace WeatherApp.OpenWeather.Data
{
    internal class OpenWeather_Cities
    {
        // Removed 'readonly' modifier to fix CS0106 and CS8370 errors  
        public static List<string> Cities { get; } = new List<string>();

        [JsonProperty("id")] private string id { get; set; }

        [JsonProperty("country")] private string Country { get; set; }

        [JsonProperty("name")] private string Name { get; set; }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Country) && !string.IsNullOrEmpty(id))
            {
                if (Country == "US")
                {
                    Cities.Add(Name);
                }
            }
        }
    }
}
