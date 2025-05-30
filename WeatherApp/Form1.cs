using DotNetEnv;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using WeatherApp.OpenWeather;
using WeatherApp.OpenWeather.Data;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        // GUI components
        private ComboBox cmbCity;
        private Button btnGetWeather;
        private Label lblWeather;

        // API components
        private List<OpenWeather_Cities> openWeatherCities;
        private OpenWeather_API openWeatherAPI;
        private WeatherResponse weatherResponse;

        // List of available cities for filtering
        private readonly List<string> cities = new List<string>{};

        public Form1()
        {
            _ = Env.Load();
            InitializeComponent();
            InitializeCities();
            // GUI Initialization
            InitializeGUIComponents();
            CenterControl(lblWeather);
            Resize += Form1_Resize;
            MinimumSize = new System.Drawing.Size(800, 500);
        }
        private void InitializeCities()
        {
            string jsonCitiesString = File.ReadAllText(Environment.GetEnvironmentVariable("CITY_DATA_FILEPATH"));
            openWeatherCities = JsonConvert.DeserializeObject<List<OpenWeather_Cities>>(jsonCitiesString);
            
            cities.AddRange(OpenWeather_Cities.Cities);
            cities.Sort();
        }
        
        private void InitializeGUIComponents()
        {
            // ComboBox for selecting/searching the city.
            cmbCity = new ComboBox
            {
                Location = new System.Drawing.Point(20, 20),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDown,
                AutoCompleteMode = AutoCompleteMode.SuggestAppend,
                AutoCompleteSource = AutoCompleteSource.CustomSource
            };

            // Populate the ComboBox with a list of cities and set up autocomplete.
            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
            ac.AddRange(cities.ToArray());
            cmbCity.AutoCompleteCustomSource = ac;

            // Add the cities to the ComboBox items.
            cmbCity.Items.AddRange(cities.ToArray());
            if (cmbCity.Items.Count == 0)
            {
                Console.WriteLine("cities is empty");
            }
            else
            {
                //cmbCity.SelectedIndex = 1;
            }


                // Handle the selection change event to close the dropdown when a city is selected
                //cmbCity.SelectionChangeCommitted += CmdCity_SelectionChangeCommitted;

                // Button to get the weather information
                btnGetWeather = new Button
                {
                    Text = "Get Weather",
                    Location = new System.Drawing.Point(230, 20)
                };
            btnGetWeather.Click += BtnGetWeather_Click;


            // Label to display weather info
            lblWeather = new Label
            {
                Text = "Weather info will display here",
                Location = new System.Drawing.Point(20, 60),
                AutoSize = true,
                MaximumSize = new Size(300, 0)
            };

            // Add the controls to the form
            Controls.Add(cmbCity);
            Controls.Add(btnGetWeather);
            Controls.Add(lblWeather);
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

        private void Form1_Resize(object sender, EventArgs e)
        {
            CenterControl(lblWeather);
        }
        private void CenterControl(Control ctrl)
        {
            int x = (ClientSize.Width - ctrl.Width) / 2;
            int y = (ClientSize.Height - ctrl.Height) / 2;
            ctrl.Location = new System.Drawing.Point(x, y);
        }
    }
}
