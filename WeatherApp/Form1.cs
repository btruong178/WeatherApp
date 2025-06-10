using DotNetEnv;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WeatherApp.OpenWeather;
using WeatherApp.OpenWeather.Data;

namespace WeatherApp
{
    public partial class HomePage : Form
    {
        /// <summary>
        /// Represents a collection of U.S. cities supported by the OpenWeather API.
        /// </summary>
        /// <remarks>This list contains city information that can be used for weather-related queries. It
        /// is intended to store instances of <see cref="US_City_Data"/>, which encapsulate details about
        /// individual cities.</remarks>
        private List<US_City_Data> USCityData;
        /// <summary>
        /// Stores an instance of the OpenWeather API client for making weather requests.
        /// </summary>W
        private OpenWeather_API openWeatherAPI;
        /// <summary>
        /// Structure to hold the weather response data from the OpenWeather API.
        /// </summary>
        private WeatherResponse weatherResponse;
        private readonly Dictionary<string, string> defaultValues = new Dictionary<string, string>
        {
            { "City", "- - - - - - - - - - - - - - -" },
            { "State", "- -" },
            { "ZipCode", "- - - - -" },
            { "County", "- - - - - - - - - -" }
        };
        /// <summary>
        /// Initializes a new instance of the <see cref="HomePage"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor performs the following actions: 
        /// 1. Loads environment variables using the <see cref="Env.Load(string, LoadOptions)"/> method.
        /// 2. Initializes the form components.
        /// 3. Sets up the Data by calling <see cref="InitializeData"/>.
        /// If an error occurs during initialization, a message box is displayed
        /// with the error details.
        /// </remarks>
        public HomePage()
        {
            try
            {
                _ = Env.Load();
                InitializeComponent();
                InitializeData();
                InitializeSelectionGUI();
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error during initialization: " + ex.Message);
            }
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            _ = btnGetWeather.Focus();
        }

        private void InitializeData()
        {
            string jsonCitiesString = File.ReadAllText(Environment.GetEnvironmentVariable("CITY_DATA_FILEPATH"));
            USCityData = JsonConvert.DeserializeObject<List<US_City_Data>>(jsonCitiesString);

        }

        private void InitializeSelectionGUI()
        {
            void InitializeStateCmboxLocal()
            {
                try
                {
                    cmbStates.Items.Clear();
                    cmbStates.Items.AddRange(USCityData.Select(x => x.State).Distinct().OrderBy(s => s)
                        .Prepend(defaultValues["State"]).ToArray());
                    cmbStates.SelectedIndex = 0;
                    cmbStates.AutoCompleteCustomSource.AddRange(USCityData.Select(x => x.State).Distinct().OrderBy(s => s).ToArray());
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show("Error in \"InitializeStateComboBox\" function: " + ex.Message);
                }
            }

            void InitializeCityCmboxLocal()
            {
                try
                {
                    cmbCity.Items.Clear();
                    cmbCity.Items.AddRange(USCityData.Select(x => x.City).Distinct().OrderBy(c => c)
                        .Prepend(defaultValues["City"]).ToArray());
                    cmbCity.SelectedIndex = 0;
                    cmbCity.AutoCompleteCustomSource.AddRange(USCityData.Select(x => x.City).Distinct().OrderBy(c => c).ToArray());
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show("Error in \"InitializeCityComboBox\" function: " + ex.Message);
                }
            }

            void InitializeZipCmboxLocal()
            {
                try
                {
                    cmbZipCode.Items.Clear();
                    cmbZipCode.Items.AddRange(USCityData.Select(x => x.ZipCode).Distinct().OrderBy(z => z)
                        .Prepend(defaultValues["ZipCode"]).ToArray());
                    cmbZipCode.SelectedIndex = 0;
                    cmbZipCode.AutoCompleteCustomSource.AddRange(USCityData.Select(x => x.ZipCode).Distinct().OrderBy(z => z).ToArray());
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show("Error in \"InitializeZipComboBox\" function: " + ex.Message);
                }
            }

            void InitializeCountyCmboxLocal()
            {
                try
                {
                    cmbCounty.Items.Clear();
                    cmbCounty.Items.AddRange(USCityData.Select(x => x.County).Distinct().OrderBy(c => c)
                        .Prepend(defaultValues["County"]).ToArray());
                    cmbCounty.SelectedIndex = 0;
                    cmbCounty.AutoCompleteCustomSource.AddRange(USCityData.Select(x => x.County).Distinct().OrderBy(c => c).ToArray());
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show("Error in \"InitializeCountyComboBox\" function: " + ex.Message);
                }
            }

            // Call local initialization methods.
            InitializeStateCmboxLocal();
            InitializeCityCmboxLocal();
            InitializeZipCmboxLocal();
            InitializeCountyCmboxLocal();
        }

        private void UpdateDependentComboBoxes()
        {
            // Start with the full data set.
            IEnumerable<US_City_Data> filteredData = USCityData;

            // Get current selections (assuming your default values are set for unselected options)
            string selectedCity = cmbCity.SelectedItem?.ToString() ?? defaultValues["City"];
            string selectedState = cmbStates.SelectedItem?.ToString() ?? defaultValues["State"];
            string selectedZip = cmbZipCode.SelectedItem?.ToString() ?? defaultValues["ZipCode"];
            string selectedCounty = cmbCounty.SelectedItem?.ToString() ?? defaultValues["County"];

            // Filter data if a meaningful selection has been made.
            if (!selectedCity.Equals(defaultValues["City"]))
            {
                filteredData = filteredData.Where(x => x.City.Equals(selectedCity, StringComparison.OrdinalIgnoreCase));
            }
            if (!selectedState.Equals(defaultValues["State"]))
            {
                filteredData = filteredData.Where(x => x.State.Equals(selectedState, StringComparison.OrdinalIgnoreCase));
            }
            if (!selectedZip.Equals(defaultValues["ZipCode"]))
            {
                filteredData = filteredData.Where(x => x.ZipCode.Equals(selectedZip, StringComparison.OrdinalIgnoreCase));
            }
            if (!selectedCounty.Equals(defaultValues["County"]))
            {
                filteredData = filteredData.Where(x => x.County.Equals(selectedCounty, StringComparison.OrdinalIgnoreCase));
            }

            // Update each ComboBox with filtered, distinct values.
            // For each, prepend the default value.
            string[] updatedCities = filteredData.Select(x => x.City).Distinct().OrderBy(x => x).Prepend(defaultValues["City"]).ToArray();
            string[] updatedStates = filteredData.Select(x => x.State).Distinct().OrderBy(x => x).Prepend(defaultValues["State"]).ToArray();
            string[] updatedZips = filteredData.Select(x => x.ZipCode).Distinct().OrderBy(x => x).Prepend(defaultValues["ZipCode"]).ToArray();
            string[] updatedCounties = filteredData.Select(x => x.County).Distinct().OrderBy(x => x).Prepend(defaultValues["County"]).ToArray();

            cmbCity.Items.Clear();
            cmbCity.Items.AddRange(updatedCities);
            cmbStates.Items.Clear();
            cmbStates.Items.AddRange(updatedStates);
            cmbZipCode.Items.Clear();
            cmbZipCode.Items.AddRange(updatedZips);
            cmbCounty.Items.Clear();
            cmbCounty.Items.AddRange(updatedCounties);

            if (cmbCity.Items.Contains(selectedCity))
            {
                cmbCity.SelectedItem = selectedCity;
            }
            else
            {
                cmbCity.SelectedIndex = 0;
            }
            if (cmbStates.Items.Contains(selectedState))
            {
                cmbStates.SelectedItem = selectedState;
            }
            else
            {
                cmbStates.SelectedIndex = 0;
            }

            if (cmbZipCode.Items.Contains(selectedZip))
            {
                cmbZipCode.SelectedItem = selectedZip;
            }
            else
            {
                cmbZipCode.SelectedIndex = 0;
            }

            if (cmbCounty.Items.Contains(selectedCounty))
            {
                cmbCounty.SelectedItem = selectedCounty;
            }
            else
            {
                cmbCounty.SelectedIndex = 0;
            }
        }
        private void SelectionChangedCommitted_UpdateSelections(object sender, EventArgs e)
        {
            UpdateDependentComboBoxes();
        }
        private void SelectionChangeCommitted_FocusToButton(object sender, EventArgs e)
        {
            _ = btnGetWeather.Focus();
        }
        private async void BtnGetWeather_Click(object sender, EventArgs e)
        {
            try
            {
                openWeatherAPI = new OpenWeather_API();
                string city = cmbCity.SelectedItem.ToString();
                string zipCode = cmbZipCode.SelectedItem.ToString();
                string apiResponse = string.Empty;
                if (city.Equals(defaultValues["City"]) && zipCode.Equals(defaultValues["ZipCode"]))
                {
                    _ = MessageBox.Show("Please select a valid city or zipcode");
                    return;
                }
                if (!zipCode.Equals(defaultValues["ZipCode"]))
                {
                    openWeatherAPI.ZipCode = zipCode;
                    apiResponse = await openWeatherAPI.API_Call_ZipCode_Output();
                }
                else if (!city.Equals(defaultValues["City"]))
                {
                    openWeatherAPI.CityName = city;
                    apiResponse = await openWeatherAPI.API_Call_CityName_Output();
                }

                weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(apiResponse);
                lblWeather.Text = $"Temperature: {weatherResponse.main.Temp}°F\n" +
                                        $"Feels Like: {weatherResponse.main.Feels_Like}°F\n" +
                                        $"Min Temperature: {weatherResponse.main.Temp_Min}°F\n" +
                                        $"Max Temperature: {weatherResponse.main.Temp_Max}°F\n" +
                                        $"Humidity: {weatherResponse.main.Humidity}%\n";

            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Error in \"BtnGetWeather_Click\" function: " + ex.Message);
                return;
            }
        }
    }
}
