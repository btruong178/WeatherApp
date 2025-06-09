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
    public partial class HomePage : Form
    {
        /// <summary>
        /// Represents a collection of U.S. cities supported by the OpenWeather API.
        /// </summary>
        /// <remarks>This list contains city information that can be used for weather-related queries. It
        /// is intended to store instances of <see cref="OpenWeather_US_City_Data"/>, which encapsulate details about
        /// individual cities.</remarks>
        private List<OpenWeather_US_City_Data> openWeatherUSData;
        /// <summary>
        /// Stores an instance of the OpenWeather API client for making weather requests.
        /// </summary>W
        private OpenWeather_API openWeatherAPI;
        /// <summary>
        /// Structure to hold the weather response data from the OpenWeather API.
        /// </summary>
        private WeatherResponse weatherResponse;
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
                InitializeComboBoxes();
                //Load += HomePage_Load;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during initialization: " + ex.Message);
            }
        }

        //private void HomePage_Load(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        btnGetWeather.Focus();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error in \"HomePage_Load\" function: " + ex.Message);
        //    }
        //}
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            btnGetWeather.Focus();
        }

        private void InitializeData()
        {
            string jsonCitiesString = File.ReadAllText(Environment.GetEnvironmentVariable("CITY_DATA_FILEPATH"));
            openWeatherUSData = JsonConvert.DeserializeObject<List<OpenWeather_US_City_Data>>(jsonCitiesString);
        }
        private void InitializeComboBoxes()
        {
            try
            {
                string[] StateSortedData = OpenWeather_US_City_Data.usStates.OrderBy(s => s).Prepend("- -").ToArray();
                string[] CitySortedData = OpenWeather_US_City_Data.usCities.OrderBy(c => c).Prepend("- - - - - - - - - - - - - - -").ToArray();

                cmbStates.Items.Clear();
                cmbCity.Items.Clear();

                cmbStates.Items.AddRange(StateSortedData);
                cmbCity.Items.AddRange(CitySortedData);

                cmbStates.SelectedIndex = 0;
                cmbCity.SelectedIndex = 0;

                cmbStates.AutoCompleteCustomSource.AddRange(StateSortedData);
                cmbCity.AutoCompleteCustomSource.AddRange(CitySortedData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in \"InitializeComboBoxes\" function: " + ex.Message);
            }
        }
        private async void BtnGetWeather_Click(object sender, EventArgs e)
        {
            try
            {
                // Logic eventually
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in \"BtnGetWeather_Click\" function: " + ex.Message);
                return;
            }
        }
        private void SelectionChangeCommitted_FocusToButton(object sender, EventArgs e)
        {
            _ = btnGetWeather.Focus();
        }
        private void SelectedCityChanged_UpdateStateChoices(object sender, EventArgs e)
        {
            try
            {
                // Only Show states that belong to that city (In case city has duplicates)
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in \"SelectedCityChanged_UpdateStateChoices\" function: " + ex.Message);
            }
        }
        private void SelectedStateChanged_UpdateCityChoices(object sender, EventArgs e)
        {
            try
            {
                string stateKey = cmbStates.SelectedItem.ToString();
                cmbCity.Items.Clear();
                if (stateKey.Equals("- -"))
                {
                    cmbCity.Items.AddRange(OpenWeather_US_City_Data.usCities.OrderBy(c => c).Prepend("- - - - - - - - - - - - - - -").ToArray());
                }
                else if (OpenWeather_US_City_Data.usDictionary.ContainsKey(stateKey))
                {
                    cmbCity.Items.AddRange(OpenWeather_US_City_Data.usDictionary[stateKey].OrderBy(c => c).ToArray());
                }
                    cmbCity.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in \"SelectedStateChanged_UpdateCityChoices\" function: " + ex.Message);
            }
        }


    }
}
