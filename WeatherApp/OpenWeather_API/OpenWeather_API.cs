using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp.OpenWeather_API
{
    internal class OpenWeather_API
    {
        public OpenWeather_API(string apiKey, string cityName)
        {
            APIKey = apiKey;
            CityName = cityName;
        }

        public string APIKey { get; set; }
        public string CityName { get; set; }
        public string BaseUrl { get; set; } = "https://api.openweathermap.org/data/2.5/weather";
        public string Units { get; set; } = "imperial";
        public string Language { get; set; } = "en";
        public string Mode { get; set; } = "json";

        public string API_Call_Url()
        {
            return $"{BaseUrl}?q={CityName}&appid={APIKey}&units={Units}&lang={Language}&mode={Mode}";
        }

        public string API_Call_Output()
        {
            try
            {
                string url = API_Call_Url();
                using (var client = new HttpClient())
                {
                    string response = client.GetStringAsync(url).Result;
                    if (string.IsNullOrEmpty(response))
                    {
                        throw new Exception("No response from the API.");
                    }
                    // Set the timeout to 10 seconds
                    client.Timeout = TimeSpan.FromSeconds(10);
                    return response;
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "API Call Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
    }
}
