using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp.OpenWeather
{
    public class OpenWeather_API
    {
        public string CityName { get; set; }
        public string APIKey { get; set; } = Environment.GetEnvironmentVariable("OPENWEATHER_API_KEY");
        public string BaseUrl { get; set; } = "https://api.openweathermap.org/data/2.5/weather";
        public string Units { get; set; } = "imperial";
        public string Language { get; set; } = "en";
        public string Mode { get; set; } = "json";

        public string API_Call_Url()
        {
            return $"{BaseUrl}?q={CityName}&appid={APIKey}&units={Units}&lang={Language}&mode={Mode}";
        }

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
