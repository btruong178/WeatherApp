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
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the API key for OpenWeather. It defaults to the value provided in the OPENWEATHER_API_KEY environment variable.
        /// </summary>
        public string APIKey { get; set; } = Environment.GetEnvironmentVariable("OPENWEATHER_API_KEY");

        /// <summary>
        /// Gets or sets the base URL for the OpenWeather API.
        /// </summary>
        public string CurrentWeather_BaseUrl { get; set; } = "https://api.openweathermap.org/data/2.5/weather";

        public string Forecast_BaseUrl { get; set; } = "https://api.openweathermap.org/data/2.5/forecast";
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
        public async Task<string> Get_CurrentWeather_via_CityName()
        {
            try
            {
                string url = $"{CurrentWeather_BaseUrl}?q={CityName}&appid={APIKey}&units={Units}&lang={Language}&mode={Mode}";
                using (HttpClient client = new HttpClient())
                {
                    string response = await client.GetStringAsync(url);
                    return string.IsNullOrEmpty(response) ? throw new Exception("No response from the API.") : response;
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show($"Error constructing API URL (CityName): {ex.Message}", "API URL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        public async Task<string> Get_CurrentWeather_via_Zipcode()
        {
            try
            {
                string url = $"{CurrentWeather_BaseUrl}?zip={ZipCode}&appid={APIKey}&units={Units}&lang={Language}&mode={Mode}";
                using (HttpClient client = new HttpClient())
                {
                    string response = await client.GetStringAsync(url);
                    return string.IsNullOrEmpty(response) ? throw new Exception("No response from the API.") : response;
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show($"Error constructing API URL (ZipCode): {ex.Message}", "API URL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<string> Get_Forecast_via_CityName()
        {
            try
            {
                string url = $"{Forecast_BaseUrl}?q={CityName}&appid={APIKey}&units={Units}&lang={Language}&mode={Mode}";
                using (HttpClient client = new HttpClient())
                {
                    string response = await client.GetStringAsync(url);
                    return string.IsNullOrEmpty(response) ? throw new Exception("No response from the API.") : response;
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show($"Error constructing API URL (Forecast CityName): {ex.Message}", "API URL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public async Task<string> Get_Forecast_via_Zipcode()
        {
            try
            {
                string url = $"{Forecast_BaseUrl}?zip={ZipCode}&appid={APIKey}&units={Units}&lang={Language}&mode={Mode}";
                using (HttpClient client = new HttpClient())
                {
                    string response = await client.GetStringAsync(url);
                    return string.IsNullOrEmpty(response) ? throw new Exception("No response from the API.") : response;
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show($"Error constructing API URL (Forecast ZipCode): {ex.Message}", "API URL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
