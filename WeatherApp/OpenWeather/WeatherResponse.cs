using Newtonsoft.Json;

namespace WeatherApp.OpenWeather
{
    /// <summary>
    /// Represents the weather response from the OpenWeather API.
    /// </summary>
    internal class WeatherResponse
    {
        /// <summary>
        /// Gets or sets the main weather data.
        /// </summary>
        [JsonProperty("main")]
        public Main main { get; set; }

        /// <summary>
        /// Contains details about the main weather conditions.
        /// </summary>
        public class Main
        {
            /// <summary>
            /// Gets or sets the temperature.
            /// </summary>
            [JsonProperty("temp")]
            public double Temp { get; set; }

            /// <summary>
            /// Gets or sets the perceived temperature.
            /// </summary>
            [JsonProperty("feels_like")]
            public double Feels_Like { get; set; }

            /// <summary>
            /// Gets or sets the minimum recorded temperature.
            /// </summary>
            [JsonProperty("temp_min")]
            public double Temp_Min { get; set; }

            /// <summary>
            /// Gets or sets the maximum recorded temperature.
            /// </summary>
            [JsonProperty("temp_max")]
            public double Temp_Max { get; set; }

            /// <summary>
            /// Gets or sets the humidity percentage.
            /// </summary>
            [JsonProperty("humidity")]
            public int Humidity { get; set; }
        }
    }
}