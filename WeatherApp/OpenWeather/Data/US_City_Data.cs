using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WeatherApp.OpenWeather.Data
{
    /// <summary>
    /// Deserializes US city data from the USCities.json file.
    /// </summary>
    public class US_City_Data
    {
        public static List<string> usStates { get; set; } = new List<string>();
        public static List<string> usCities { get; set; } = new List<string>();
        public static List<string> usZipCodes { get; set; } = new List<string>();
        public static List<string> usCounties { get; set; } = new List<string>();
        [JsonProperty("zip_code")]
        public string ZipCode { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("county")]
        public string County { get; set; }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            try
            {
                if (!usStates.Contains(State))
                {
                    usStates.Add(State);
                }
                if (!usCities.Contains(City))
                {
                    usCities.Add(City);
                }
                if (!usZipCodes.Contains(ZipCode))
                {
                    usZipCodes.Add(ZipCode);
                }
                if (!usCounties.Contains(County))
                {
                    usCounties.Add(County);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during deserialization: " + ex.Message);
            }
        }
    }
}