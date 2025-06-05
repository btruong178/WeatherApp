using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp.OpenWeather
{
    /// <summary>
    /// Provides methods for accessing the OpenWeather API.
    /// </summary>
    public class OpenWeather_API
    {
        /// <summary>
        /// Gets or sets the name of the city for which the weather is requested.
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// Gets or sets the API key for OpenWeather. It defaults to the value provided in the OPENWEATHER_API_KEY environment variable.
        /// </summary>
        public string APIKey { get; set; } = Environment.GetEnvironmentVariable("OPENWEATHER_API_KEY");

        /// <summary>
        /// Gets or sets the base URL for the OpenWeather API.
        /// </summary>
        public string BaseUrl { get; set; } = "https://api.openweathermap.org/data/2.5/weather";

        /// <summary>
        /// Gets or sets the units parameter for the API call. Defaults to "imperial".
        /// </summary>
        public string Units { get; set; } = "imperial";

        /// <summary>
        /// Gets or sets the language parameter for the API call. Defaults to "en".
        /// </summary>
        public string Language { get; set; } = "en";

        /// <summary>
        /// Gets or sets the mode parameter for the API call. Defaults to "json".
        /// </summary>
        public string Mode { get; set; } = "json";

        /// <summary>
        /// Constructs the API call URL.
        /// </summary>
        /// <returns>A string representing the full API call URL.</returns>
        public string API_Call_Url()
        {
            return $"{BaseUrl}?q={CityName}&appid={APIKey}&units={Units}&lang={Language}&mode={Mode}";
        }

        /// <summary>
        /// Asynchronously calls the API and retrieves the response.
        /// </summary>
        /// <returns>A task that returns the API response as a string.</returns>
        public async Task<string> API_Call_Output()
        {
            try
            {
                string url = API_Call_Url();
                using (HttpClient client = new HttpClient())
                {
                    string response = await client.GetStringAsync(url);
                    return string.IsNullOrEmpty(response) ? throw new Exception("No response from the API.") : response;
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show($"Error: {ex.Message}", "API Call Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
