using DotNetEnv;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WeatherApp.OpenWeather;
using WeatherApp.OpenWeather.Data;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        // API components
        private List<OpenWeather_Cities> openWeatherCities;
        private List<OpenWeather_US_Cities> openWeatherUSCities;
        private OpenWeather_API openWeatherAPI;
        private WeatherResponse weatherResponse;

        // List of available cities for filtering
        private readonly List<string> cities = new List<string> { };

        public Form1()
        {
            try
            {
                _ = Env.Load();
                InitializeComponent();
                InitializeCities();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during initialization: " + ex.Message);
            }
        }

        private void InitializeCities()
        {
            //string jsonCitiesString = File.ReadAllText(Environment.GetEnvironmentVariable("CITY_DATA_FILEPATH"));
            //openWeatherCities = JsonConvert.DeserializeObject<List<OpenWeather_Cities>>(jsonCitiesString);

            //cities.AddRange(OpenWeather_Cities.Cities);
            //cities.Sort();
            //cmbCity.DataSource = cities;

            string jsonCitiesString = File.ReadAllText(Environment.GetEnvironmentVariable("CITY_DATA_FILEPATH"));
            openWeatherUSCities = JsonConvert.DeserializeObject<List<OpenWeather_US_Cities>>(jsonCitiesString);

            string text = "";
            foreach (var eachObject in openWeatherUSCities)
            {
                if (!string.IsNullOrEmpty(eachObject.Name) && 
                    !string.IsNullOrEmpty(eachObject.State) && 
                    !string.IsNullOrEmpty(eachObject.Country))
                {
                    text += $"{eachObject.Name}, {eachObject.State}, {eachObject.Country}\n";
                }
            }
            Console.WriteLine(text);

        }
        private void CmdCity_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _ = btnGetWeather.Focus();
        }
        private async void BtnGetWeather_Click(object sender, EventArgs e)
        {
            openWeatherAPI = new OpenWeather_API();
            string city = cmbCity.Text;
            openWeatherAPI.CityName = city;
            try
            {
                string jsonResponse = await openWeatherAPI.API_Call_Output();
                weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(jsonResponse);
                lblWeather.Text = $"Weather in {city}:\n" +
                                  $"Temperature: {weatherResponse.main.Temp} °F\n" +
                                  $"Feels Like: {weatherResponse.main.Feels_Like} °F\n" +
                                  $"Min Temperature: {weatherResponse.main.Temp_Min} °F\n" +
                                  $"Max Temperature: {weatherResponse.main.Temp_Max} °F\n" +
                                  $"Humidity: {weatherResponse.main.Humidity}%";
                Console.WriteLine($"API Url: {openWeatherAPI.API_Call_Url()}");
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show($"Error: {ex.Message}", "API Call Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
