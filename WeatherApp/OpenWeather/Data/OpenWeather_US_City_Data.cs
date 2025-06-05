using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp.OpenWeather.Data
{
    /// <summary>
    /// Deserializes US city data from OpenWeather and stores cities grouped by their state.
    /// </summary>
    internal class OpenWeather_US_City_Data
    {
        /// <summary>
        /// A dictionary mapping state abbreviations to a list of city names.
        /// </summary>
        public static Dictionary<string, List<string>> usCities = new Dictionary<string, List<string>>();

        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        [JsonProperty("id")]
        public string id { get; set; }

        /// <summary>
        /// Gets or sets the name of the city.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the state abbreviation.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the coordinates of the city.
        /// </summary>
        [JsonProperty("coord")]
        public Coordinates Coord { get; set; }

        /// <summary>
        /// Represents geographic coordinates.
        /// </summary>
        public class Coordinates
        {
            /// <summary>
            /// Gets or sets the latitude.
            /// </summary>
            [JsonProperty("lat")]
            public double Latitude { get; set; }

            /// <summary>
            /// Gets or sets the longitude.
            /// </summary>
            [JsonProperty("lon")]
            public double Longitude { get; set; }
        }

        /// <summary>
        /// Called after deserialization to organize US cities by state.
        /// </summary>
        /// <param name="context">The streaming context.</param>
        [OnDeserialized]
        private void Get_US_Cities(StreamingContext context)
        {
            if (!usCities.ContainsKey(State))
            {
                usCities[State] = new List<string>();
            }
            usCities[State].Add(Name);
        }
    }
}